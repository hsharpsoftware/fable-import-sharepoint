module Dropzone.Support
open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Import.Browser
open Fable.Core.JsInterop
open Browser.Support
open HSharp
// http://www.fssnip.net/9l
open Microsoft.FSharp.Reflection

[<Emit("Dropzone")>]
let Dropzone: unit = jsNative

[<Emit("RSVP")>]
let RSVP: unit = jsNative

let mutable filesToRemove: obj array = Array.empty

//let Dropzone = JsInterop.importAll<obj> "../dropzone.js" 
let createHiddenInput dropDiv =
    let hidden = document.createElement("input")   
    hidden?``type`` <- "hidden"
    hidden?value <- ""
    dropDiv?appendChild(hidden) |> ignore
    hidden


let createDropzoneFormWithButtons (dropzoneName: string) (url: string) (dropDiv: HTMLElement) =    
    let dropForm = document.createElement("form")
    dropForm?action  <- url
    dropForm?``method`` <- "POST"
    dropForm.setAttribute("class", "dropzone")
    dropForm.setAttribute("id", dropzoneName)

    let div = document.createElement("div")
    div.setAttribute("class", "fallback")
    
    let input = document.createElement("input")
    input?name <- "file"
    input?``type`` <- "file"
    input?multiple <- true

    div.appendChild(input) |> ignore
    dropForm.appendChild(div) |> ignore

    dropDiv.appendChild(dropForm) |> ignore

    let center = document.createElement("center")

    let submit = document.createElement("button")
    submit.id <- "upload-all"
    submit.textContent <- "Submit valid files"

    let remove = document.createElement("button")
    remove.id <- "remove-invalid"
    remove.textContent <- "Remove invalid files"

    center.appendChild(submit) |> ignore
    center.appendChild(remove) |> ignore
    dropDiv.appendChild(center) |> ignore

let addRemoveLink file dropzone =
    let removeLink = Dropzone?createElement("<center><a href=\"\">Remove file</a></center>")
    removeLink?addEventListener("click", fun e -> 
                                               e?preventDefault() |> ignore
                                               e?stopPropagation() |> ignore
                                               dropzone?removeFile(file) |> ignore
                                               filesToRemove <- filesToRemove |> Array.except file) |> ignore
    removeLink


let actionOnInit dropzone  =
    let submitButton = document.querySelector("#upload-all");
    let removeButton = document.querySelector("#remove-invalid");
    submitButton?addEventListener("click", fun e -> 
                                               e?preventDefault() |> ignore
                                               e?stopPropagation() |> ignore
                                               dropzone?processQueue() |> ignore) |> ignore
    removeButton?addEventListener("click", fun e -> 
                                               e?preventDefault() |> ignore
                                               e?stopPropagation() |> ignore
                                               filesToRemove |> Array.iter(fun file -> dropzone?removeFile(file) |> ignore )
                                               filesToRemove <- [||]) |> ignore
    dropzone?on("addedfile", fun file -> file?previewElement?appendChild(addRemoveLink file dropzone) |> ignore) |> ignore |> ignore


[<Emit("done()")>]
let doneOnSuccess: unit = jsNative

[<Emit("done($0)")>]
let doneOnError (errorMessage: string) : unit = jsNative

let accept conditionFuncToAccept file ``done`` =
      async {
          let input = document.querySelector("#serverResponseInput")
          let! result = conditionFuncToAccept file?name input
          let m =  (input?value).ToString().Contains("OK:")
          match m with
          | true ->
              doneOnSuccess
          | false ->
             let inputValue: string = (input?value).ToString()
             doneOnError inputValue
             filesToRemove <- filesToRemove |> Array.append [|file|]
             input?value <- "" |> ignore
      }

let actionOnAccept getReportFunc =
    accept getReportFunc

