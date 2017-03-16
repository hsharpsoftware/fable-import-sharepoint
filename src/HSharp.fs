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

type IApplication = 
    inherit IApplicationCore
    abstract member getEndPointFromUrl: string -> IEndPoint option
    abstract member render: (ISite option) -> (IEndPoint option) -> unit
    abstract member getSiteFromUrl: string -> ISite option
    abstract member scheduled: (ISite option) -> (IEndPoint option) -> unit

type ISite2 = 
    abstract member path: string

type ILocalized = 
    abstract member path: string

type IPage = 
    inherit ILocalized
    abstract member render: unit -> unit

type IScheduledTask = 
    inherit ILocalized
    abstract member run: unit -> unit

type IApplicationV2 = 
    inherit IApplicationCore
    abstract member getPages : unit -> (IPage array)
    abstract member getSites : unit -> (string array)
    abstract member getScheduledTasks : unit -> (IScheduledTask array)

type ApplicationV2EndPoint(page:IPage, task:IScheduledTask option) =
    member m.Page = page
    member m.ScheduledTask = task
    interface IEndPoint

type ApplicationV2Site(site:string) =
    member m.Site = site
    interface ISite

let logD isDebug message =
    if isDebug then log message
let logO isDebug message value = 
    logD isDebug (message + ":")
    if isDebug then logO value
    logD isDebug "----------------------------------------------------------------------------------"

type ApplicationV2Wrapper(app:IApplicationV2) =
    member m.ApplicationV2 = app
    member m.w = m :> IApplication
    interface IApplication with
        member this.isDebug = app.isDebug
        member this.getSiteFromUrl(url: string) = 
            app.getSites()
            |> Array.tryFind locationHasPart 
            |> Microsoft.FSharp.Core.Option.map ( fun p -> ApplicationV2Site(p) :> ISite)

        member this.getEndPointFromUrl url = 
            let site = this.w.getSiteFromUrl url

            let potentialPages = app.getPages() |> Array.where( fun p -> locationHasPart (p.path.Split('*')).[1] )
            let potentialScheduledTasks = app.getScheduledTasks() |> Array.where( fun p -> locationHasPart (p.path.Split('*')).[1] )
            let page = 
                let pageWithSite = potentialPages |> Array.tryFind( fun p -> p.path.Contains((site.Value).ToString()) )   
                if pageWithSite.IsNone then
                    potentialPages |> Array.tryHead
                else pageWithSite
            let task = 
                let taskWithSite = potentialScheduledTasks |> Array.tryFind( fun p -> p.path.Contains((site.Value).ToString()))   
                if taskWithSite.IsNone then
                    potentialScheduledTasks |> Array.tryHead
                else taskWithSite
            page |> Microsoft.FSharp.Core.Option.map ( fun p -> ApplicationV2EndPoint(p, task) :> IEndPoint )
        member this.render (site:ISite option) (endPoint:IEndPoint option) =
            let s = (if site.IsSome then site.Value else (ApplicationV2Site("") :> ISite)) :?> ApplicationV2Site 
            if endPoint.IsSome then                
                let ep = endPoint.Value :?> ApplicationV2EndPoint
                let isTheSameSite = s.Site.Equals((ep.Page.path.Split('*')).[0])
                if isTheSameSite then
                    let page = ( endPoint.Value :?> ApplicationV2EndPoint ).Page
                    page.render()
        member this.scheduled (site:ISite option) (endPoint:IEndPoint option) = 
            if endPoint.IsSome then
                let task = ( endPoint.Value :?> ApplicationV2EndPoint ).ScheduledTask
                task |> Microsoft.FSharp.Core.Option.iter( fun t -> t.run() )



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
