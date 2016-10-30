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

[<Emit("alert($0)")>]
let alert (x: string) : unit = jsNative

[<Emit("console.log($0)")>]
let log (message:string) : unit = jsNative

[<Emit("jQuery($0)")>]
let el (cssSelector:string) = jsNative


let elH (elementId:string) = el("#"+elementId)

let setElementValue (elementId:string) (text:string) =
    (elH (elementId))?``val``( text ) |> ignore

let checkRadio (elementId:string) =
    (elH (elementId))?prop("checked",true) |> ignore

[<Emit("jQuery()")>]
let jQ () = jsNative

