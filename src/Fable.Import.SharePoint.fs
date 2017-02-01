namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module Microsoft =
    module Office =
        module Server =
            module ReputationModel =
                type [<AllowNullLiteral>] [<Import("Office.Server.ReputationModel.Reputation","Microsoft")>] Reputation() =
                    static member setLike(context: SP.ClientContext, listId: string, itemId: float, like: bool): unit = jsNative
                    static member setRating(context: SP.ClientContext, listId: string, itemId: float, rating: float): unit = jsNative



module Define =
    type [<Import("*","Define")>] Globals =
        static member loadScript(url: string, successCallback: Func<unit, unit>, errCallback: Func<unit, unit>): unit = jsNative
        static member require(req: string, callback: Function): unit = jsNative
        static member require(req: ResizeArray<string>, callback: Function): unit = jsNative
        static member define(name: string, deps: ResizeArray<string>, def: Function): unit = jsNative



module Verify =
    type [<Import("*","Verify")>] Globals =
        static member ArgumentType(arg: string, expected: obj): unit = jsNative



module BrowserStorage =
    type [<AllowNullLiteral>] CachedStorage =
        abstract length: float with get, set
        abstract getItem: key: string -> string
        abstract setItem: key: string * value: string -> unit
        abstract removeItem: key: string -> unit
        abstract clead: unit -> unit

    type [<Import("*","BrowserStorage")>] Globals =
        static member local with get(): CachedStorage = jsNative and set(v: CachedStorage): unit = jsNative
        static member session with get(): CachedStorage = jsNative and set(v: CachedStorage): unit = jsNative



module BrowserDetection =
    type [<Import("*","BrowserDetection")>] Globals =
        static member browseris with get(): Browseris = jsNative and set(v: Browseris): unit = jsNative



module CSSUtil =
    type [<Import("*","CSSUtil")>] Globals =
        static member HasClass(elem: HTMLElement, className: string): bool = jsNative
        static member AddClass(elem: HTMLElement, className: string): unit = jsNative
        static member RemoveClass(elem: HTMLElement, className: string): unit = jsNative
        static member pxToFloat(pxString: string): float = jsNative
        static member pxToNum(px: string): float = jsNative
        static member numToPx(n: float): string = jsNative
        static member getCurrentEltStyleByNames(elem: HTMLElement, styleNames: ResizeArray<string>): string = jsNative
        static member getCurrentStyle(elem: HTMLElement, cssStyle: string): string = jsNative
        static member getCurrentStyleCorrect(element: HTMLElement, camelStyleName: string, dashStyleName: string): string = jsNative
        static member getOpacity(element: HTMLElement): float = jsNative
        static member setOpacity(element: HTMLElement, value: float): unit = jsNative



module DOM =
    type [<Import("*","DOM")>] Globals =
        static member rightToLeft with get(): bool = jsNative and set(v: bool): unit = jsNative
        static member cancelDefault(evt: Event): unit = jsNative
        static member AbsLeft(el: HTMLElement): float = jsNative
        static member AbsTop(el: HTMLElement): float = jsNative
        static member CancelEvent(evt: Event): unit = jsNative
        static member GetElementsByName(nae: string): NodeList = jsNative
        static member GetEventCoords(evt: Event): obj = jsNative
        static member GetEventSrcElement(evt: Event): HTMLElement = jsNative
        static member GetInnerText(el: HTMLElement): string = jsNative
        static member PreventDefaultNavigation(evt: Event): unit = jsNative
        static member SetEvent(eventName: string, eventFunc: Function, el: HTMLElement): unit = jsNative



module Encoding =
    type [<Import("*","Encoding")>] Globals =
        static member EncodeScriptQuote(str: string): string = jsNative
        static member HtmlEncode(str: string): string = jsNative
        static member HtmlDecode(str: string): string = jsNative
        static member AttrQuote(str: string): string = jsNative
        static member ScriptEncode(str: string): string = jsNative
        static member ScriptEncodeWithQuote(str: string): string = jsNative
        static member CanonicalizeUrlEncodingCase(str: string): string = jsNative



module IE8Support =
    type [<Import("*","IE8Support")>] Globals =
        static member arrayIndexOf(array: ResizeArray<'T>, item: 'T, ?startIdx: float): float = jsNative
        static member attachDOMContentLoaded(handler: Function): unit = jsNative
        static member getComputedStyle(domObj: HTMLElement, camelStyleName: string, dashStyleName: string): string = jsNative
        static member stopPropagation(evt: Event): unit = jsNative



module StringUtil =
    type [<Import("*","StringUtil")>] Globals =
        static member BuildParam(stPattern: string, [<ParamArray>] ``params``: obj[]): string = jsNative
        static member ApplyStringTemplate(str: string, [<ParamArray>] ``params``: obj[]): string = jsNative



module TypeUtil =
    type [<Import("*","TypeUtil")>] Globals =
        static member IsArray(value: obj): bool = jsNative
        static member IsNullOrUndefined(value: obj): bool = jsNative



module Nav =
    type [<Import("*","Nav")>] Globals =
        static member ajaxNavigate with get(): AjaxNavigate = jsNative and set(v: AjaxNavigate): unit = jsNative
        static member convertRegularURLtoMDSURL(webUrl: string, fullPath: string): string = jsNative
        static member isMDSUrl(url: string): bool = jsNative
        static member isPageUrlValid(url: string): bool = jsNative
        static member isPortalTemplatePage(url: string): bool = jsNative
        static member getAjaxLocationWindow(): string = jsNative
        static member getSource(?defaultSource: string): string = jsNative
        static member getUrlKeyValue(keyName: string, bNoDecode: bool, url: string, bCaseInsensitive: bool): string = jsNative
        static member getWindowLocationNoHash(hre: string): string = jsNative
        static member goToHistoryLink(el: HTMLAnchorElement, strVersion: string): unit = jsNative
        static member getGoToLinkUrl(el: HTMLAnchorElement): string = jsNative
        static member goToLink(el: HTMLAnchorElement): unit = jsNative
        static member goToLinkOrDialogNewWindow(el: HTMLAnchorElement): unit = jsNative
        static member goToDiscussion(url: string): unit = jsNative
        static member onClickHook(evt: Event, topElm: HTMLElement): unit = jsNative
        static member pageUrlValidation(url: string, alertString: string): string = jsNative
        static member parseHash(hash: string): obj = jsNative
        static member navigate(url: string): unit = jsNative
        static member removeMDSQueryParametersFromUrl(url: string): string = jsNative
        static member urlFromHashBag(hashObject: obj): string = jsNative
        static member wantsNewTab(evt: Event): bool = jsNative



module URI_Encoding =
    type [<Import("*","URI_Encoding")>] Globals =
        static member encodeURIComponent(str: string, ?bAsUrl: bool, ?bForFilterQuery: bool, ?bForCallback: bool): string = jsNative
        static member escapeUrlForCallback(str: string): string = jsNative



module ListModule =
    module Util =
        type [<Import("Util","ListModule")>] Globals =
            static member createViewEditUrl(renderCtx: SPClientTemplates.RenderContext, listItem: IListItem, ?useEditFormUrl: bool, ?appendSource: bool): string = jsNative
            static member createItemPropertiesTitle(renderCtx: SPClientTemplates.RenderContext, listItem: IListItem): string = jsNative
            static member clearSelectedItemsDict(context: obj): unit = jsNative
            static member ctxInitItemState(context: obj): unit = jsNative
            static member getAttributeFromItemTable(itemTableParam: HTMLElement, strAttributeName: string, strAttributeOldName: string): string = jsNative
            static member getSelectedItemsDict(context: obj): obj = jsNative
            static member removeOnlyPagingArgs(url: string): string = jsNative
            static member removePagingArgs(url: string): string = jsNative
            static member showAttachmentRows(): unit = jsNative



module SPThemeUtils =
    type [<Import("*","SPThemeUtils")>] Globals =
        static member ApplyCurrentTheme(): unit = jsNative
        static member WithCurrentTheme(resultCallback: Function): unit = jsNative
        static member UseClientSideTheming(): bool = jsNative
        static member Suspend(): unit = jsNative

