module Browser.Support

open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Import.Browser
open Fable.Core.JsInterop

// http://www.fssnip.net/9l
open Microsoft.FSharp.Reflection

let onDocumentReady (callback:unit->unit) : unit =
    document.onreadystatechange <- fun _ -> 
        if document.readyState = "complete" then
            callback ()
        null

let windowParentLocation =
    try 
        Some(window.parent.location.href)
    with
    | _ -> None

let getIndexOfUrlPart (part : string) : int =
    window.location.href.IndexOf(part)

let locationHasPart (part : string) =
    getIndexOfUrlPart part > -1

let getCurrentUrl () =
    window.location.href

let setCurrentUrl (url:string) =
    window.location.href <- url

let parentHasPart (part : string) =
    let parent = windowParentLocation
    match parent with
    | Some(loc) -> loc.IndexOf(part) > -1
    | _ -> false

let reloadPage() =
  window.location.reload(false)

[<Emit("alert($0)")>]
let alert (x: string) : unit = jsNative

[<Emit("console.log($0)")>]
let log (message:string) : unit = jsNative

[<Emit("console.log($0)")>]
let logO (value:obj) : unit = jsNative

[<Emit("jQuery($0)")>]
let el (cssSelector:string) = jsNative

let elH (elementId:string) = el("#"+elementId)

let setElementHValue (elementId:string) (text:string) =
    (elH (elementId))?``val``( text ) |> ignore

let setElementValue (selector:string) (text:string) =
    (el (selector))?``val``( text ) |> ignore

let checkRadio (elementId:string) =
    (elH (elementId))?prop("checked",true) |> ignore

[<Emit("jQuery()")>]
let jQ () = jsNative

type ajaxParameters = {
    beforeSend : obj -> unit
    ``type`` : string
    url : string
    data : string
    dataType : string
    success : string -> unit
}

[<Emit("jQuery.ajax($0)")>]
let ajax (parameter:ajaxParameters) = jsNative


let postJSON url data callback =
    ajax(
        let beforeSend (xhrObj) =
            xhrObj?setRequestHeader("Content-Type","application/json") |> ignore
            xhrObj?setRequestHeader("Accept","application/json")  |> ignore
    
        {
            beforeSend = beforeSend
            ``type`` = "POST"
            url = url     
            data = data
            dataType = "json"
            success = callback
        }
    )

let showAll el = 
    el?find("*")?show() |> ignore
    el?show() |> ignore

let change (func : unit->unit) el = el?change( fun () -> func() )
let submit (func : unit->unit) el = el?submit( fun () -> func() )
let attr value el :string = el?attr(value).ToString()
let hide el = el?hide()
let show el = el?show()
let append (value: obj) el = el?append(value)
let parent el = el?parent()
let remove el = el?remove()
[<Emit("setTimeout($0,$1)")>]
let setTimeout (callback:unit->unit) (miliseconds) = jsNative
let prop (value : string*'A) el = 
                  let name, v = value
                  el?prop(name,v)              

let readonlyAll el = 
    el?find("*")?prop("contentEditable", false) |> ignore
    el?find("*")?prop("disabled", true) |> ignore
    
[<Emit("RegExp($0)")>]
let RegExp (par:string) = jsNative

let matchRuleShort (str:string) (rule:string) : bool =
    downcast ( RegExp ("^" + rule?split("*")?join(".*").ToString() + "$" ) )?test(str)

let find (selector : string) el = 
    el?find(selector)              

let last el = el?last()
let first el = el?first()

let toStringSafe v =
    if v = null then
        ""
    else
        let vs = v.ToString()
        if vs="null" then "" else vs


    

let has (containedOrSelector:string) el = el?has(containedOrSelector)

[<Emit("$0.length")>]
let length el : int = jsNative

let disable el =
    el |> prop ("disabled", true) |> ignore

let enable el = 
    el |> prop ("disabled", false) |> ignore

let enableOrDisable enabled el = 
    el |> prop ("disabled", (not enabled) ) |> ignore

let on (event:string) (func : unit->unit) el = el?on( event, fun () -> func() )
    
let width param el = 
    el?width(param) |> ignore

[<Emit("$0.id")>]
let idP el : int = jsNative

let empty el = el?empty() |> ignore

let pathname =
  window.location.pathname

let hostname =
  window.location.hostname

let links =
  document.getElementsByTagName("a")

let getHostname (el: Element) = 
  (el?hostname).ToString()

let getPathname (el: Element) = 
  (el?pathname).ToString()
