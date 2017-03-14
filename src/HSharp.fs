module HSharp
open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

open Browser.Support

open Microsoft.FSharp.Reflection

type ISite = interface end
type IEndPoint = interface end

type IApplicationCore = 
    abstract member isDebug: bool
    abstract member scheduled: (ISite option) -> (IEndPoint option) -> unit

type IApplication = 
    inherit IApplicationCore
    abstract member getEndPointFromUrl: string -> IEndPoint option
    abstract member render: (ISite option) -> (IEndPoint option) -> unit
    abstract member getSiteFromUrl: string -> ISite option

type ISite2 = 
    abstract member path: string

type IPage = 
    abstract member path: string
    abstract member site : ISite option
    abstract member render: unit -> unit

type IApplicationV2 = 
    inherit IApplicationCore
    abstract member getPages : unit -> (IPage array)
    abstract member getSites : unit -> (ISite2 array)

type ApplicationV2EndPoint(page:IPage) =
    member m.Page = page
    interface IEndPoint

type ApplicationV2Site(site:ISite2) =
    member m.Site = site
    interface ISite

type ApplicationV2Wrapper(app:IApplicationV2) =
    member m.ApplicationV2 = app
    member m.w = m :> IApplication
    interface IApplication with
        member this.isDebug = app.isDebug
        member this.getSiteFromUrl url = 
            app.getSites() 
            |> Array.tryFind( fun p -> locationHasPart url )
            |> Microsoft.FSharp.Core.Option.map ( fun p -> ApplicationV2Site(p) :> ISite )

        member this.getEndPointFromUrl url = 
            let site = this.w.getSiteFromUrl url
            let potentialPages = app.getPages() |> Array.where( fun p -> locationHasPart p.path )
            let page = 
                let pageWithSite = potentialPages |> Array.tryFind( fun p -> p.site = site )   
                if pageWithSite.IsNone then
                    potentialPages |> Array.tryHead
                else pageWithSite
            page |> Microsoft.FSharp.Core.Option.map ( fun p -> ApplicationV2EndPoint(p) :> IEndPoint )
        member this.render (site:ISite option) (endPoint:IEndPoint option) =
            let page = ( endPoint.Value :?> ApplicationV2EndPoint ).Page
            page.render()
        member this.scheduled (site:ISite option) (endPoint:IEndPoint option) = app.scheduled site endPoint        

let logD isDebug message =
    if isDebug then log message
let logO isDebug message value = 
    logD isDebug (message + ":")
    if isDebug then logO value
    logD isDebug "----------------------------------------------------------------------------------"

let startApplication (application:IApplication) =
    let isDebug = application.isDebug
    let logD message =
        if isDebug then log message
    let logDF formatString args = 
        logD (sprintf formatString args)
    let currentUrl = getCurrentUrl ()
    logDF "Application started @ %A" currentUrl
    let site = application.getSiteFromUrl currentUrl
    logDF "@ Site %A" site
    let endpoint = application.getEndPointFromUrl currentUrl
    logDF "@ EndPoint %A" endpoint
    application.render site endpoint
    logD "Rendered"

    let rec scheduler () = 
        //logD "Running scheduled task..."
        application.scheduled site endpoint
        //logD "... done"
        setTimeout scheduler 1000

    logD "Scheduling the task for the very first time"
    setTimeout scheduler 1000

    logD "start done"
