module Browser.Support

open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Import.Browser
open Fable.Core.JsInterop

// http://www.fssnip.net/9l
open Microsoft.FSharp.Reflection

[<Emit("console.log($0)")>]
let log (message:string) : unit = jsNative

[<Emit("console.log($0)")>]
let logO (value:obj) : unit = jsNative

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

let getUrlWithoutParams() : string =
    let urlWithoutParams = window.location.href.Replace(window.location.search, "")
   
    urlWithoutParams

let getIndexOfUrlPart (part : string) : int =
    let urlWithoutParams = getUrlWithoutParams().ToLower()
    let index = urlWithoutParams.IndexOf(part.ToLower())
    index
    

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

[<Emit("jQuery($0)")>]
let el (cssSelector:string) = jsNative

[<Emit("this")>]
let this () = jsNative

let elH (elementId:string) = el("#"+elementId)

[<Emit("($0).text()")>]
let text el = jsNative

let toString obj =
    obj.ToString()

let setElementHValue (elementId:string) (text:string) =
    (elH (elementId))?``val``( text ) |> ignore

let setElementValue (selector:string) (text:string) =
    (el (selector))?``val``( text ) |> ignore

let getElementValue (selector: string) =
    let s = selector+" option:selected"
    (el (s)) |> text |> toString

let getElementHValue (elementId: string) =
    (elH (elementId)) |> text |> toString

let checkHRadio (elementId:string) =
    (elH (elementId))?prop("checked",true) |> ignore

let checkRadio (selector:string) =
    (el (selector))?prop("checked",true) |> ignore

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

[<Emit("jQuery.getScript($0, $1)")>]
let getScript (src: string) (callback: unit->unit) = jsNative

[<Emit("jQuery.getScript($0).done($1).fail($2)")>]
let getScriptWithFail (src: string) (successCallback: string->string->unit) (failCallback: obj->obj->obj->unit) = jsNative


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
                  
let getInnerText(el: Element): string = 
    (el?innerText).ToString()

let readonlyAll el = 
    el?find("*")?prop("contentEditable", false) |> ignore
    el?find("*")?prop("disabled", true) |> ignore

let querySelector (query: string) =
    logO query
    document.querySelector(query)
    
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

let host =
    window.location.host

let links =
    document.getElementsByTagName("a")

let getElementById (id: string) =
    document.getElementById(id)

let getElementsByClass (className: string) =
    document.getElementsByClassName(className)

let getElementsByName (name: string) =
    document.getElementsByName(name)    

let getChildrenByClass (className: string) (parent: Element) = 
    parent.getElementsByClassName(className)

let getHostname (el: Element) = 
    (el?hostname).ToString()

let getPathname (el: Element) =
    (el?pathname).ToString()

let createParamLinkPostfix (linkDescription: string) (paramValue: string) (url: string) (paramName: string) (source: bool) =
  let path = 
      match source with
      | false -> url + "?"+ paramName + "=" + paramValue
      | true -> url + "?"+ paramName + "=" + paramValue + "&Source=" + location.href
      
  let link = document.createElement("a")
  link.setAttribute("href", path)
  link.textContent <- linkDescription
  link

let createLinkElement (linkDescription: string) (url: string) =
  let link = document.createElement("a")
  link.setAttribute("href", url)
  link.textContent <- linkDescription
  link

let getSelectedText el =
  (el?text()  ).ToString()

let createSimpleLink (linkDescription: string)  (url: string) (source: bool) =
  let path = 
      match source with
      | false -> url
      | true -> url + "?Source=" + location.href
      
  let link = document.createElement("a")
  link.setAttribute("href", path)
  link.textContent <- linkDescription
  link

let createLineBreak =
  document.createElement("br")

let createTextElement (value: string) =
  document.createTextNode(value)

let createInput (value: string) (t: string) =
  let input = document.createElement("input")
  input?``type`` <- t
  input?value <- value
  input


let createTable =
  let t = document.createElement_table()
  t.id <- "boardsTable"
  t.border <- "1"
  t

let createRow (table : HTMLTableElement) =
  table.insertRow(-1.0)

let createColumn (row : HTMLTableRowElement) content=
  let cell = row.insertCell(-1.0)
  cell.appendChild(content) |> ignore
  cell

let getUrlParamValue (paramName : string) =
  let result =
    location.search.Substring(1).Split('&')    
    |> Array.map(fun x -> x.Split('=')) 
    |> Array.find(fun y -> y.[0]=paramName)

  result.[1]

let createButton (text: string) =
    let submit = document.createElement("button")
    submit.textContent <- text
    submit

let createDiv (id: string) = 
    let div = document.createElement("div")
    div.id <- id
    div

let addButton (name: string) (parent) (onClick) =
    let submit = createButton name
    submit.id <- name
    submit?addEventListener("click", onClick) |> ignore
    parent?appendChild(submit) |> ignore

let addHeading (value: string) (parent) = 
    let h = document.createElement("h3")
    let t = document.createTextNode(value)
    h?appendChild(t) |> ignore
    parent?appendChild(h) |> ignore

let getQueryParameterValue (name: string) =
    let query = location.search.Substring(1)
    let prms = query.Split('&')
    let paramValue =
            prms 
            |> Array.filter(fun x -> 
                                  let pair = x.Split('=')
                                  pair.[0].Equals(name))
            |> Array.map(fun x -> x.Split('=').[1])
    match paramValue.Length with
    | 0 -> ""
    | _ -> paramValue.[0]

let confirm (message: string) =
    window.confirm(message)

let sliceUrlFrom(start: string) =
    let urlParts = location.href.Split('/')
    let length = (urlParts |> Array.findIndex(fun x -> x.Equals(start)))+1
    let res = (Array.sub urlParts 0 length |> Array.fold ( fun acc i -> acc + "/" + i ) "" ).Trim( '/' ) 
    res

let clearElementChildren(el: HTMLElement) =
    (el.id |> elH)?empty() |> ignore
    el

let getInputValueLength (input: HTMLElement) =
    let iEl = input :?> HTMLInputElement
    let res = iEl.value
    logO res
    res.Length

let after html el = el?after(html)
    
let dateTimeToStringSafe (d:System.DateTime) = 
    let res = d.ToString("dd.MM.yyyy")
    if res = "null" then "" else res

let nearestRow el = 
    try 
        el?parents("tr")
    with
    | ex -> 
        log (sprintf "nearestRow FAILED for %A [%A]" el ex )
        null

let closest sel el = 
    el?closest(sel)