module HSharp
open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

open Browser.Support

open Microsoft.FSharp.Reflection

[<Literal>]
let PathAsterixSeparator = "*"

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

type ILocalized = 
    abstract member path: string

type IPage = 
    inherit ILocalized
    abstract member render: unit -> unit

type IScheduledTask = 
    inherit ILocalized
    abstract member run: unit -> unit
    abstract member runOnce: unit -> unit

type IApplicationV2 = 
    inherit IApplicationCore
    abstract member getPages : unit -> (IPage array)
    abstract member getSites : unit -> (string array)
    abstract member getScheduledTasks : unit -> (IScheduledTask array)

type ApplicationV2EndPoint(page:IPage option, task:IScheduledTask option) =
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
    let splitByPathAsterixSeparator (p:string) = 
        let pathAsterixSeparatorForSplit = PathAsterixSeparator.ToCharArray().[0]
        p.Split(pathAsterixSeparatorForSplit)

    let runIfMatch which what (endPoint:IEndPoint option) = 
        let runOnEp  (ep:IEndPoint) = 
            (ep :?> ApplicationV2EndPoint) |> which |> Microsoft.FSharp.Core.Option.iter (what)
        endPoint 
        |> Microsoft.FSharp.Core.Option.iter (runOnEp)

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

            let localPart (p:ILocalized) = (splitByPathAsterixSeparator p.path).[1]
            let potentialPages = app.getPages() |> Array.where( localPart >> locationHasPart )
            let potentialScheduledTasks = app.getScheduledTasks() |> Array.where( localPart >> locationHasPart )

            let findByPathAndConvert x = 
                let convert1 arr =
                    let convertOne x : ILocalized = upcast x
                    arr 
                    |> Array.map (convertOne)

                let findByPath (potentials:ILocalized array):ILocalized option = 
                    let localizedWithSite = potentials |> Array.tryFind( fun p -> p.path.Contains((site.Value).ToString()) )   
                    if localizedWithSite.IsNone then
                        potentials |> Array.tryHead
                    else localizedWithSite
                x |> convert1 |> findByPath |> Microsoft.FSharp.Core.Option.map ( fun p -> downcast p)

            let page = potentialPages |> findByPathAndConvert
            let task = potentialScheduledTasks |> findByPathAndConvert
            if page.IsNone && task.IsNone then 
                None
            else
                Some(upcast ApplicationV2EndPoint(page, task))
        member this.render (site:ISite option) (endPoint:IEndPoint option) =
            endPoint |> runIfMatch (fun ep->ep.Page) (fun page->page.render())
            endPoint |> runIfMatch (fun ep->ep.ScheduledTask) (fun task->task.runOnce())
        member this.scheduled (site:ISite option) (endPoint:IEndPoint option) = 
            endPoint |> runIfMatch (fun ep->ep.ScheduledTask) (fun task->task.run())
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
        application.scheduled site endpoint
        setTimeout scheduler 1000

    logD "Scheduling the task for the very first time"
    setTimeout scheduler 1000

    logD "start done"
