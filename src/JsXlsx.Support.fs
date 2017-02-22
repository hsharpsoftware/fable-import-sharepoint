module Xlsx.Support

open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Import.Browser
open Fable.Core.JsInterop

// http://www.fssnip.net/9l
open Microsoft.FSharp.Reflection

open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS

type [<AllowNullLiteral>] IProperties =
    abstract LastAuthor: string option with get, set
    abstract Author: string option with get, set
    abstract CreatedDate: DateTime option with get, set
    abstract ModifiedDate: DateTime option with get, set
    abstract Application: string option with get, set
    abstract AppVersion: string option with get, set
    abstract Company: string option with get, set
    abstract DocSecurity: string option with get, set
    abstract Manager: string option with get, set
    abstract HyperlinksChanged: bool option with get, set
    abstract SharedDoc: bool option with get, set
    abstract LinksUpToDate: bool option with get, set
    abstract ScaleCrop: bool option with get, set
    abstract Worksheets: float option with get, set
    abstract SheetNames: ResizeArray<string> option with get, set

and [<AllowNullLiteral>] IParsingOptions =
    abstract cellFormula: bool option with get, set
    abstract cellHTML: bool option with get, set
    abstract cellNF: bool option with get, set
    abstract cellStyles: bool option with get, set
    abstract cellDates: bool option with get, set
    abstract sheetStubs: bool option with get, set
    abstract sheetRows: float option with get, set
    abstract bookDeps: bool option with get, set
    abstract bookFiles: bool option with get, set
    abstract bookProps: bool option with get, set
    abstract bookSheets: bool option with get, set
    abstract bookVBA: bool option with get, set
    abstract password: string option with get, set
    abstract bookType: string option with get, set
    abstract ``type``: string option with get, set

and [<AllowNullLiteral>] IWorkBook =
    abstract Sheets: obj with get, set
    abstract SheetNames: ResizeArray<string> with get, set
    abstract Props: IProperties with get, set

and [<AllowNullLiteral>] IWorkSheet =
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: cell: string -> IWorkSheetCell with get, set

and [<AllowNullLiteral>] IWorkSheetCell =
    abstract t: string with get, set
    abstract v: string with get, set
    abstract r: string option with get, set
    abstract h: string option with get, set
    abstract w: string option with get, set
    abstract f: string option with get, set
    abstract c: string option with get, set
    abstract z: string option with get, set
    abstract l: string option with get, set
    abstract s: string option with get, set

and [<AllowNullLiteral>] ICell =
    abstract c: float with get, set
    abstract r: float with get, set

and [<AllowNullLiteral>] IRange =
    abstract s: ICell with get, set
    abstract e: ICell with get, set

and [<AllowNullLiteral>] IUtils =
    abstract sheet_to_json: worksheet: IWorkSheet * ?opts: obj -> ResizeArray<'T>
    abstract sheet_to_csv: worksheet: IWorkSheet * ?options: obj -> string
    abstract sheet_to_formulae: worksheet: IWorkSheet -> obj
    abstract encode_cell: cell: ICell -> obj
    abstract encode_range: s: ICell * e: ICell -> obj
    abstract decode_cell: address: string -> ICell
    abstract decode_range: range: string -> IRange

type [<Erase>]Globals =
    [<Global>] static member utils with get(): IUtils = jsNative and set(v: IUtils): unit = jsNative

(*
/* bookType can be 'xlsx' or 'xlsm' or 'xlsb' or 'ods' */
var wopts = { bookType:'xlsx', bookSST:false, type:'binary' };
*)
let wopts  =
    createObj [
        "bookType" ==> "xlsx"
        "bookSST" ==> false
        "type" ==> "binary"
    ]

let newWorkBook () =
    createObj [
        "SheetNames" ==> [||]
        "Sheets" ==> []
    ] :?> IWorkBook


[<Emit("XLSX.write($0,$1)")>]
let writeXLSX (workbook:IWorkBook) (wopts) = jsNative

[<Emit("saveAs(new Blob([s2ab($0)],{type:\"application/octet-stream\"}), $1)")>]
let saveAs blob fileName : unit = jsNative