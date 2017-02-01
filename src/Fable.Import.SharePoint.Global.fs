namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

type [<AllowNullLiteral>] [<Import("*","JSRequest")>] JSRequest() =
    member __.QueryString with get(): obj = jsNative and set(v: obj): unit = jsNative
    member __.FileName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.PathName with get(): string = jsNative and set(v: string): unit = jsNative
    static member EnsureSetup(): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","_spPageContextInfo")>] _spPageContextInfo() =
    member __.alertsEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.allowSilverlightPrompt with get(): string = jsNative and set(v: string): unit = jsNative
    member __.clientServerTimeDelta with get(): float = jsNative and set(v: float): unit = jsNative
    member __.crossDomainPhotosEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.currentCultureName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.currentLanguage with get(): float = jsNative and set(v: float): unit = jsNative
    member __.currentUICultureName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.layoutsUrl with get(): string = jsNative and set(v: string): unit = jsNative
    member __.pageListId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.pageItemId with get(): float = jsNative and set(v: float): unit = jsNative
    member __.pagePersonalizationScope with get(): string = jsNative and set(v: string): unit = jsNative
    member __.serverRequestPath with get(): string = jsNative and set(v: string): unit = jsNative
    member __.siteAbsoluteUrl with get(): string = jsNative and set(v: string): unit = jsNative
    member __.siteClientTag with get(): string = jsNative and set(v: string): unit = jsNative
    member __.siteServerRelativeUrl with get(): string = jsNative and set(v: string): unit = jsNative
    member __.systemUserKey with get(): string = jsNative and set(v: string): unit = jsNative
    member __.tenantAppVersion with get(): string = jsNative and set(v: string): unit = jsNative
    member __.userId with get(): float = jsNative and set(v: float): unit = jsNative
    member __.webAbsoluteUrl with get(): string = jsNative and set(v: string): unit = jsNative
    member __.webLanguage with get(): float = jsNative and set(v: float): unit = jsNative
    member __.webLogoUrl with get(): string = jsNative and set(v: string): unit = jsNative
    member __.webPermMasks with get(): obj = jsNative and set(v: obj): unit = jsNative
    member __.webServerRelativeUrl with get(): string = jsNative and set(v: string): unit = jsNative
    member __.webTemplate with get(): string = jsNative and set(v: string): unit = jsNative
    member __.webTitle with get(): string = jsNative and set(v: string): unit = jsNative
    member __.webUIVersion with get(): float = jsNative and set(v: float): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","AjaxNavigate")>] AjaxNavigate() =
    member __.update(url: string, updateParts: obj, fullNavigate: bool, anchorName: string): unit = jsNative
    member __.add_navigate(handler: Function): unit = jsNative
    member __.remove_navigate(handler: Function): unit = jsNative
    member __.submit(formToSubmit: HTMLFormElement): unit = jsNative
    member __.getParam(paramName: string): string = jsNative
    member __.getSavedFormAction(): string = jsNative
    member __.get_href(): string = jsNative
    member __.get_hash(): string = jsNative
    member __.get_search(): string = jsNative
    member __.convertMDSURLtoRegularURL(mdsPath: string): string = jsNative

and [<AllowNullLiteral>] [<Import("*","Browseris")>] Browseris() =
    member __.firefox with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.firefox36up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.firefox3up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.firefox4up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie55up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie5up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie7down with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie8down with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie9down with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie8standard with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie8standardUp with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ie9standardUp with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ipad with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.windowsphone with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.chrome with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.chrome7up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.chrome8up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.chrome9up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.iever with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.mac with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.major with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.msTouch with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.isTouch with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.nav with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.nav6 with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.nav6up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.nav7up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.osver with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.safari with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.safari125up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.safari3up with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.verIEFull with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.w3c with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.webKit with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.win with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.win8AppHost with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.win32 with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.win64bit with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.winnt with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.armProcessor with get(): bool = jsNative and set(v: bool): unit = jsNative

and [<AllowNullLiteral>] ContextInfo =
    inherit SPClientTemplates.RenderContext
    abstract AllowGridMode: bool with get, set
    abstract BasePermissions: obj with get, set
    abstract BaseViewID: obj with get, set
    abstract CascadeDeleteWarningMessage: string with get, set
    abstract ContentTypesEnabled: bool with get, set
    abstract CurrentSelectedItems: bool with get, set
    abstract CurrentUserId: float with get, set
    abstract EnableMinorVersions: bool with get, set
    abstract ExternalDataList: bool with get, set
    abstract HasRelatedCascadeLists: bool with get, set
    abstract HttpPath: string with get, set
    abstract HttpRoot: string with get, set
    abstract LastSelectableRowIdx: float with get, set
    abstract LastSelectedItemIID: float with get, set
    abstract LastRowIndexSelected: float with get, set
    abstract RowFocusTimerID: float with get, set
    abstract ListData: obj with get, set
    abstract ListSchema: SPClientTemplates.ListSchema with get, set
    abstract ModerationStatus: float with get, set
    abstract PortalUrl: string with get, set
    abstract RecycleBinEnabled: float with get, set
    abstract SelectAllCbx: HTMLElement with get, set
    abstract SendToLocationName: string with get, set
    abstract SendToLocationUrl: string with get, set
    abstract StateInitDone: bool with get, set
    abstract TableCbxFocusHandler: Function with get, set
    abstract TableMouseoverHandler: Function with get, set
    abstract TotalListItems: float with get, set
    abstract WorkflowsAssociated: bool with get, set
    abstract clvp: obj with get, set
    abstract ctxId: float with get, set
    abstract ctxType: obj with get, set
    abstract dictSel: obj with get, set
    abstract displayFormUrl: string with get, set
    abstract editFormUrl: string with get, set
    abstract imagesPath: string with get, set
    abstract inGridMode: bool with get, set
    abstract inGridFullRender: bool with get, set
    abstract isForceCheckout: bool with get, set
    abstract isModerated: bool with get, set
    abstract isPortalTemplate: bool with get, set
    abstract isVersions: bool with get, set
    abstract isWebEditorPreview: bool with get, set
    abstract leavingGridMode: bool with get, set
    abstract loadingAsyncData: bool with get, set
    abstract listBaseType: float with get, set
    abstract listName: string with get, set
    abstract listTemplate: string with get, set
    abstract listUrlDir: string with get, set
    abstract newFormUrl: string with get, set
    abstract onRefreshFailed: Function with get, set
    abstract overrideDeleteConfirmation: string with get, set
    abstract overrideFilterQstring: string with get, set
    abstract recursiveView: bool with get, set
    abstract rootFolderForDisplay: string with get, set
    abstract serverUrl: string with get, set
    abstract verEnabled: bool with get, set
    abstract view: string with get, set
    abstract queryString: string with get, set
    abstract IsClientRendering: bool with get, set
    abstract wpq: string with get, set
    abstract rootFolder: string with get, set
    abstract IsAppWeb: bool with get, set
    abstract NewWOPIDocumentEnabled: bool with get, set
    abstract NewWOPIDocumentUrl: string with get, set
    abstract AllowCreateFolder: bool with get, set
    abstract CanShareLinkForNewDocument: bool with get, set
    abstract noGroupCollapse: bool with get, set
    abstract SiteTemplateId: float with get, set
    abstract ExcludeFromOfflineClient: bool with get, set

and [<AllowNullLiteral>] MQuery =
    [<Emit("$0($1...)")>] abstract Invoke: selector: string * ?context: obj -> MQueryResultSetElements
    [<Emit("$0($1...)")>] abstract Invoke: element: HTMLElement -> MQueryResultSetElements
    [<Emit("$0($1...)")>] abstract Invoke: ``object``: MQueryResultSetElements -> MQueryResultSetElements
    [<Emit("$0($1...)")>] abstract Invoke: ``object``: MQueryResultSet<'T> -> MQueryResultSet<'T>
    [<Emit("$0($1...)")>] abstract Invoke: ``object``: 'T -> MQueryResultSet<'T>
    [<Emit("$0($1...)")>] abstract Invoke: elementArray: ResizeArray<HTMLElement> -> MQueryResultSetElements
    [<Emit("$0($1...)")>] abstract Invoke: array: ResizeArray<'T> -> MQueryResultSet<'T>
    [<Emit("$0($1...)")>] abstract Invoke: unit -> MQueryResultSet<'T>
    abstract throttle: fn: Function * interval: float * shouldOverrideThrottle: bool -> Function
    abstract extend: target: obj * [<ParamArray>] objs: obj[] -> obj
    abstract extend: deep: bool * target: obj * [<ParamArray>] objs: obj[] -> obj
    abstract makeArray: obj: obj -> ResizeArray<obj>
    abstract isDefined: obj: obj -> bool
    abstract isNotNull: obj: obj -> bool
    abstract isUndefined: obj: obj -> bool
    abstract isNull: obj: obj -> bool
    abstract isUndefinedOrNull: obj: obj -> bool
    abstract isDefinedAndNotNull: obj: obj -> bool
    abstract isString: obj: obj -> bool
    abstract isBoolean: obj: obj -> bool
    abstract isFunction: obj: obj -> bool
    abstract isArray: obj: obj -> bool
    abstract isNode: obj: obj -> bool
    abstract isElement: obj: obj -> bool
    abstract isMQueryResultSet: obj: obj -> bool
    abstract isNumber: obj: obj -> bool
    abstract isObject: obj: obj -> bool
    abstract isEmptyObject: obj: obj -> bool
    abstract ready: callback: Func<unit, unit> -> unit
    abstract contains: container: HTMLElement * contained: HTMLElement -> bool
    abstract proxy: fn: Func<obj, obj> * context: obj * [<ParamArray>] args: obj[] -> Function
    abstract proxy: context: obj * name: string * [<ParamArray>] args: obj[] -> obj
    abstract every: obj: ResizeArray<'T> * fn: Func<'T, float, bool> * ?context: obj -> bool
    abstract every: obj: MQueryResultSet<'T> * fn: Func<'T, float, bool> * ?context: obj -> bool
    abstract every: obj: ResizeArray<'T> * fn: Func<'T, bool> * ?context: obj -> bool
    abstract every: obj: MQueryResultSet<'T> * fn: Func<obj, bool> * ?context: obj -> bool
    abstract some: obj: ResizeArray<'T> * fn: Func<'T, float, bool> * ?context: obj -> bool
    abstract some: obj: MQueryResultSet<'T> * fn: Func<'T, float, bool> * ?context: obj -> bool
    abstract some: obj: ResizeArray<'T> * fn: Func<'T, bool> * ?context: obj -> bool
    abstract some: obj: MQueryResultSet<'T> * fn: Func<'T, bool> * ?context: obj -> bool
    abstract filter: obj: ResizeArray<'T> * fn: Func<'T, float, bool> * ?context: obj -> ResizeArray<'T>
    abstract filter: obj: MQueryResultSet<'T> * fn: Func<'T, float, bool> * ?context: obj -> MQueryResultSet<'T>
    abstract filter: obj: ResizeArray<'T> * fn: Func<'T, bool> * ?context: obj -> ResizeArray<'T>
    abstract filter: obj: MQueryResultSet<'T> * fn: Func<'T, bool> * ?context: obj -> MQueryResultSet<'T>
    abstract forEach: obj: ResizeArray<'T> * fn: Func<'T, float, unit> * ?context: obj -> unit
    abstract forEach: obj: MQueryResultSet<'T> * fn: Func<'T, float, unit> * ?context: obj -> unit
    abstract forEach: obj: ResizeArray<'T> * fn: Func<'T, unit> * ?context: obj -> unit
    abstract forEach: obj: MQueryResultSet<'T> * fn: Func<'T, unit> * ?context: obj -> unit
    abstract map: array: ResizeArray<'T> * callback: Func<'T, float, 'U> -> ResizeArray<'U>
    abstract map: array: MQueryResultSet<'T> * callback: Func<'T, float, 'U> -> MQueryResultSet<'U>
    abstract map: array: ResizeArray<'T> * callback: Func<'T, 'U> -> ResizeArray<'U>
    abstract map: array: MQueryResultSet<'T> * callback: Func<'T, 'U> -> MQueryResultSet<'U>
    abstract indexOf: obj: ResizeArray<'T> * ``object``: 'T * ?startIndex: float -> float
    abstract lastIndexOf: obj: ResizeArray<'T> * ``object``: 'T * ?startIndex: float -> float
    abstract data: element: HTMLElement * key: string * value: obj -> obj
    abstract data: element: HTMLElement * key: string -> obj
    abstract data: element: HTMLElement -> obj
    abstract removeData: element: HTMLElement * ?name: string -> MQueryResultSetElements
    abstract hasData: element: HTMLElement -> bool

and [<AllowNullLiteral>] MQueryResultSetElements =
    inherit MQueryResultSet<HTMLElement>
    abstract append: node: HTMLElement -> MQueryResultSetElements
    abstract append: mQuerySet: MQueryResultSetElements -> MQueryResultSetElements
    abstract append: html: string -> MQueryResultSetElements
    abstract bind: eventType: string * handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract unbind: eventType: string * handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract trigger: eventType: string -> MQueryResultSetElements
    abstract one: eventType: string * handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract detach: unit -> MQueryResultSetElements
    abstract find: selector: string -> MQueryResultSetElements
    abstract closest: selector: string * ?context: obj -> MQueryResultSetElements
    abstract offset: unit -> obj
    abstract offset: coordinates: obj -> MQueryResultSetElements
    abstract filter: selector: string -> MQueryResultSetElements
    abstract filter: fn: Func<HTMLElement, float, bool> * ?context: obj -> MQueryResultSetElements
    abstract filter: fn: Func<HTMLElement, bool> * ?context: obj -> MQueryResultSetElements
    abstract not: selector: string -> MQueryResultSetElements
    abstract parent: ?selector: string -> MQueryResultSetElements
    abstract offsetParent: ?selector: string -> MQueryResultSetElements
    abstract parents: ?selector: string -> MQueryResultSetElements
    abstract parentsUntil: ?selector: string * ?filter: string -> MQueryResultSetElements
    abstract parentsUntil: ?element: HTMLElement * ?filter: string -> MQueryResultSetElements
    abstract position: unit -> obj
    abstract attr: attributeName: string -> string
    abstract attr: attributeName: string * value: obj -> MQueryResultSetElements
    abstract attr: map: obj -> MQueryResultSetElements
    abstract attr: attributeName: string * func: Func<float, obj, obj> -> MQueryResultSetElements
    abstract addClass: classNames: string -> MQueryResultSetElements
    abstract removeClass: classNames: string -> MQueryResultSetElements
    abstract css: propertyName: string -> string
    abstract css: propertyNames: ResizeArray<string> -> string
    abstract css: properties: obj -> MQueryResultSetElements
    abstract css: propertyName: string * value: obj -> MQueryResultSetElements
    abstract css: propertyName: obj * value: obj -> MQueryResultSetElements
    abstract remove: ?selector: string -> MQueryResultSetElements
    abstract children: ?selector: string -> MQueryResultSetElements
    abstract empty: unit -> MQueryResultSetElements
    abstract first: unit -> MQueryResultSetElements
    abstract data: key: string * value: obj -> MQueryResultSetElements
    abstract data: obj: obj -> MQueryResultSetElements
    abstract data: key: string -> obj
    abstract removeData: key: string -> MQueryResultSetElements
    abstract map: callback: Func<HTMLElement, float, obj> -> MQueryResultSetElements
    abstract map: callback: Func<HTMLElement, obj> -> MQueryResultSetElements
    abstract blur: unit -> MQueryResultSetElements
    abstract blur: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract change: unit -> MQueryResultSetElements
    abstract change: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract click: unit -> MQueryResultSetElements
    abstract click: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract dblclick: unit -> MQueryResultSetElements
    abstract dblclick: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract error: unit -> MQueryResultSetElements
    abstract error: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract focus: unit -> MQueryResultSetElements
    abstract focus: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract focusin: unit -> MQueryResultSetElements
    abstract focusin: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract focusout: unit -> MQueryResultSetElements
    abstract focusout: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract keydown: unit -> MQueryResultSetElements
    abstract keydown: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract keypress: unit -> MQueryResultSetElements
    abstract keypress: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract keyup: unit -> MQueryResultSetElements
    abstract keyup: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract load: unit -> MQueryResultSetElements
    abstract load: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mousedown: unit -> MQueryResultSetElements
    abstract mousedown: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mouseenter: unit -> MQueryResultSetElements
    abstract mouseenter: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mouseleave: unit -> MQueryResultSetElements
    abstract mouseleave: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mousemove: unit -> MQueryResultSetElements
    abstract mousemove: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mouseout: unit -> MQueryResultSetElements
    abstract mouseout: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mouseover: unit -> MQueryResultSetElements
    abstract mouseover: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract mouseup: unit -> MQueryResultSetElements
    abstract mouseup: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract resize: unit -> MQueryResultSetElements
    abstract resize: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract scroll: unit -> MQueryResultSetElements
    abstract scroll: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract select: unit -> MQueryResultSetElements
    abstract select: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract submit: unit -> MQueryResultSetElements
    abstract submit: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements
    abstract unload: unit -> MQueryResultSetElements
    abstract unload: handler: Func<MQueryEvent, obj> -> MQueryResultSetElements

and [<AllowNullLiteral>] MQueryResultSet<'T> =
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: index: float -> 'T with get, set
    abstract contains: contained: 'T -> bool
    abstract filter: fn: Func<'T, float, bool> * ?context: obj -> MQueryResultSet<'T>
    abstract filter: fn: Func<'T, bool> * ?context: obj -> MQueryResultSet<'T>
    abstract every: fn: Func<'T, float, bool> * ?context: obj -> bool
    abstract every: fn: Func<'T, bool> * ?context: obj -> bool
    abstract some: fn: Func<'T, float, bool> * ?context: obj -> bool
    abstract some: fn: Func<'T, bool> * ?context: obj -> bool
    abstract map: callback: Func<'T, float, obj> -> MQueryResultSet<'T>
    abstract map: callback: Func<'T, obj> -> MQueryResultSet<'T>
    abstract forEach: fn: Func<'T, float, unit> * ?context: obj -> unit
    abstract forEach: fn: Func<'T, unit> * ?context: obj -> unit
    abstract indexOf: ``object``: obj * ?startIndex: float -> float
    abstract lastIndexOf: ``object``: obj * ?startIndex: float -> float

and [<AllowNullLiteral>] MQueryEvent =
    inherit Event
    abstract altKey: bool with get, set
    abstract attrChange: float with get, set
    abstract attrName: string with get, set
    abstract bubbles: bool with get, set
    abstract button: float with get, set
    abstract cancelable: bool with get, set
    abstract ctrlKey: bool with get, set
    abstract defaultPrevented: bool with get, set
    abstract detail: float with get, set
    abstract eventPhase: float with get, set
    abstract newValue: string with get, set
    abstract prevValue: string with get, set
    abstract relatedNode: HTMLElement with get, set
    abstract screenX: float with get, set
    abstract screenY: float with get, set
    abstract shiftKey: bool with get, set
    abstract view: obj with get, set

and [<AllowNullLiteral>] [<Import("*","CalloutActionOptions")>] CalloutActionOptions() =
    member __.text with get(): string = jsNative and set(v: string): unit = jsNative
    member __.tooltip with get(): string = jsNative and set(v: string): unit = jsNative
    member __.disabledTooltip with get(): string = jsNative and set(v: string): unit = jsNative
    member __.onClickCallback with get(): Func<Event, CalloutAction, obj> = jsNative and set(v: Func<Event, CalloutAction, obj>): unit = jsNative
    member __.isEnabledCallback with get(): Func<CalloutAction, bool> = jsNative and set(v: Func<CalloutAction, bool>): unit = jsNative
    member __.isVisibleCallback with get(): Func<CalloutAction, bool> = jsNative and set(v: Func<CalloutAction, bool>): unit = jsNative
    member __.menuEntries with get(): ResizeArray<CalloutActionMenuEntry> = jsNative and set(v: ResizeArray<CalloutActionMenuEntry>): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","CalloutActionMenuEntry")>] CalloutActionMenuEntry(text: string, onClickCallback: Func<CalloutActionMenuEntry, float, unit>, wzISrc: string, wzIAlt: string, wzISeq: float, wzDesc: string) =
    class end

and [<AllowNullLiteral>] [<Import("*","CalloutActionMenu")>] CalloutActionMenu(actionsId: obj) =
    member __.addAction(action: CalloutAction): unit = jsNative
    member __.getActions(): ResizeArray<CalloutAction> = jsNative
    member __.render(): unit = jsNative
    member __.refreshActions(): unit = jsNative
    member __.calculateActionWidth(): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","CalloutAction")>] CalloutAction(options: CalloutActionOptions) =
    member __.getText(): string = jsNative
    member __.getToolTop(): string = jsNative
    member __.getDisabledToolTip(): string = jsNative
    member __.getOnClickCallback(``event``: obj, action: CalloutAction): obj = jsNative
    member __.getIsDisabledCallback(action: CalloutAction): bool = jsNative
    member __.getIsVisibleCallback(action: CalloutAction): bool = jsNative
    member __.getIsMenu(): bool = jsNative
    member __.getMenuEntries(): ResizeArray<CalloutActionMenuEntry> = jsNative
    member __.render(): unit = jsNative
    member __.isEnabled(): bool = jsNative
    member __.isVisible(): bool = jsNative
    member __.set(options: CalloutActionOptions): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","Callout")>] Callout() =
    member __.set(options: CalloutOptions): obj = jsNative
    member __.addEventCallback(eventName: string, callback: Func<Callout, unit>): unit = jsNative
    member __.getLaunchPoint(): HTMLElement = jsNative
    member __.getID(): string = jsNative
    member __.getTitle(): string = jsNative
    member __.getContent(): string = jsNative
    member __.getContentElement(): HTMLElement = jsNative
    member __.getBoundingBox(): HTMLElement = jsNative
    member __.getContentWidth(): float = jsNative
    member __.getOpenOptions(): CalloutOpenOptions = jsNative
    member __.getBeakOrientation(): string = jsNative
    member __.getPositionAlgorithm(): obj = jsNative
    member __.isOpen(): bool = jsNative
    member __.isOpening(): bool = jsNative
    member __.isOpenOrOpening(): bool = jsNative
    member __.isClosing(): bool = jsNative
    member __.isClosed(): bool = jsNative
    member __.getActionMenu(): CalloutActionMenu = jsNative
    member __.addAction(action: CalloutAction): unit = jsNative
    member __.refreshActions(): unit = jsNative
    member __.``open``(useAnimation: bool): unit = jsNative
    member __.close(useAnimation: bool): unit = jsNative
    member __.toggle(): unit = jsNative
    member __.destroy(): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","CalloutOpenOptions")>] CalloutOpenOptions() =
    member __.``event`` with get(): string = jsNative and set(v: string): unit = jsNative
    member __.closeCalloutOnBlur with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.showCloseButton with get(): bool = jsNative and set(v: bool): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","CalloutOptions")>] CalloutOptions() =
    member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
    member __.launchPoint with get(): HTMLElement = jsNative and set(v: HTMLElement): unit = jsNative
    member __.beakOrientation with get(): string = jsNative and set(v: string): unit = jsNative
    member __.content with get(): string = jsNative and set(v: string): unit = jsNative
    member __.title with get(): string = jsNative and set(v: string): unit = jsNative
    member __.contentElement with get(): HTMLElement = jsNative and set(v: HTMLElement): unit = jsNative
    member __.boundingBox with get(): HTMLElement = jsNative and set(v: HTMLElement): unit = jsNative
    member __.contentWidth with get(): float = jsNative and set(v: float): unit = jsNative
    member __.openOptions with get(): CalloutOpenOptions = jsNative and set(v: CalloutOpenOptions): unit = jsNative
    member __.onOpeningCallback with get(): Func<Callout, unit> = jsNative and set(v: Func<Callout, unit>): unit = jsNative
    member __.onOpenedCallback with get(): Func<Callout, unit> = jsNative and set(v: Func<Callout, unit>): unit = jsNative
    member __.onClosingCallback with get(): Func<Callout, unit> = jsNative and set(v: Func<Callout, unit>): unit = jsNative
    member __.onClosedCallback with get(): Func<Callout, unit> = jsNative and set(v: Func<Callout, unit>): unit = jsNative
    member __.positionAlgorithm with get(): Func<Callout, unit> = jsNative and set(v: Func<Callout, unit>): unit = jsNative

and [<AllowNullLiteral>] [<Import("*","CalloutManager")>] CalloutManager() =
    static member createNew(options: CalloutOptions): Callout = jsNative
    static member createNewIfNecessary(options: CalloutOptions): Callout = jsNative
    static member remove(callout: Callout): unit = jsNative
    static member getFromLaunchPoint(launchPoint: HTMLElement): Callout = jsNative
    static member getFromLaunchPointIfExists(launchPoint: HTMLElement): Callout = jsNative
    static member containsOneCalloutOpen(ancestor: HTMLElement): bool = jsNative
    static member getFromCalloutDescendant(descendant: HTMLElement): Callout = jsNative
    static member forEach(callback: Func<Callout, unit>): unit = jsNative
    static member closeAll(): bool = jsNative
    static member isAtLeastOneCalloutOpen(): bool = jsNative
    static member isAtLeastOneCalloutOn(): bool = jsNative

and [<AllowNullLiteral>] [<Import("*","SPMgr")>] SPMgr() =
    member __.NewGroup(listItem: obj, fieldName: string): bool = jsNative
    member __.RenderHeader(renderCtx: SPClientTemplates.RenderContext, field: SPClientTemplates.FieldSchema): string = jsNative
    member __.RenderField(renderCtx: SPClientTemplates.RenderContext, field: SPClientTemplates.FieldSchema, listItem: obj, listSchema: SPClientTemplates.ListSchema): string = jsNative
    member __.RenderFieldByName(renderCtx: SPClientTemplates.RenderContext, fieldName: string, listItem: obj, listSchema: SPClientTemplates.ListSchema): string = jsNative

and [<AllowNullLiteral>] IEnumerator<'T> =
    abstract get_current: unit -> 'T
    abstract moveNext: unit -> bool
    abstract reset: unit -> unit

and [<AllowNullLiteral>] IEnumerable<'T> =
    abstract getEnumerator: unit -> IEnumerator<'T>

and [<AllowNullLiteral>] [<Import("*","SPStatusNotificationData")>] SPStatusNotificationData(text: string, subText: string, imageUrl: string, sip: string) =
    class end

and [<AllowNullLiteral>] [<Import("*","SPClientAutoFill")>] SPClientAutoFill(elmTextId: string, elmContainerId: string, fnPopulateAutoFill: Func<HTMLInputElement, unit>) =
    member __.MenuOptionType with get(): obj = jsNative and set(v: obj): unit = jsNative
    member __.KeyProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DisplayTextProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SubDisplayTextProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.TitleTextProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.MenuOptionTypeProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.TextElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.AutoFillContainerId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.AutoFillMenuId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.VisibleItemCount with get(): float = jsNative and set(v: float): unit = jsNative
    member __.CurrentFocusOption with get(): float = jsNative and set(v: float): unit = jsNative
    member __.AutoFillMinTextLength with get(): float = jsNative and set(v: float): unit = jsNative
    member __.AutoFillTimeout with get(): float = jsNative and set(v: float): unit = jsNative
    member __.AutoFillCallbackTimeoutID with get(): string = jsNative and set(v: string): unit = jsNative
    member __.FuncOnAutoFillClose with get(): Func<string, ISPClientAutoFillData, unit> = jsNative and set(v: Func<string, ISPClientAutoFillData, unit>): unit = jsNative
    member __.FuncPopulateAutoFill with get(): Func<HTMLElement, unit> = jsNative and set(v: Func<HTMLElement, unit>): unit = jsNative
    member __.AllOptionData with get(): obj = jsNative and set(v: obj): unit = jsNative
    static member GetAutoFillObjFromInput(elmText: HTMLInputElement): SPClientAutoFill = jsNative
    static member GetAutoFillObjFromContainer(elmChild: HTMLElement): SPClientAutoFill = jsNative
    static member GetAutoFillMenuItemFromOption(elmChild: HTMLElement): HTMLElement = jsNative
    member __.PopulateAutoFill(jsonObjSuggestions: ResizeArray<ISPClientAutoFillData>, fnOnAutoFillCloseFuncName: Func<string, ISPClientAutoFillData, unit>): unit = jsNative
    member __.IsAutoFillOpen(): bool = jsNative
    member __.SetAutoFillHeight(): unit = jsNative
    member __.SelectAutoFillOption(elemOption: HTMLElement): unit = jsNative
    member __.FocusAutoFill(): unit = jsNative
    member __.BlurAutoFill(): unit = jsNative
    member __.CloseAutoFill(ojData: ISPClientAutoFillData): unit = jsNative
    member __.UpdateAutoFillMenuFocus(bMoveNextLink: bool): unit = jsNative
    member __.UpdateAutoFillPosition(): unit = jsNative

and [<AllowNullLiteral>] ISPClientAutoFillData =
    abstract AutoFillKey: obj option with get, set
    abstract AutoFillDisplayText: string option with get, set
    abstract AutoFillSubDisplayText: string option with get, set
    abstract AutoFillTitleText: string option with get, set
    abstract AutoFillMenuOptionType: float option with get, set

and [<AllowNullLiteral>] [<Import("*","SPClientPeoplePicker")>] SPClientPeoplePicker() =
    member __.ValueName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DisplayTextName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SubDisplayTextName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DescriptionName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SIPAddressName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SuggestionsName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.UnvalidatedEmailAddressKey with get(): string = jsNative and set(v: string): unit = jsNative
    member __.KeyProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DisplayTextProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SubDisplayTextProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.TitleTextProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DomainProperty with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SPClientPeoplePickerDict with get(): obj = jsNative and set(v: obj): unit = jsNative
    member __.TopLevelElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.EditorElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.AutoFillElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.ResolvedListElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.InitialHelpTextElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.WaitImageId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.HiddenInputId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.AllowEmpty with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ForceClaims with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.AutoFillEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.AllowMultipleUsers with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.OnValueChangedClientScript with get(): Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit> = jsNative and set(v: Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit>): unit = jsNative
    member __.OnUserResolvedClientScript with get(): Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit> = jsNative and set(v: Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit>): unit = jsNative
    member __.OnControlValidateClientScript with get(): Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit> = jsNative and set(v: Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit>): unit = jsNative
    //member __.UrlZone with get(): SP.UrlZone = jsNative and set(v: SP.UrlZone): unit = jsNative
    member __.AllUrlZones with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.SharePointGroupID with get(): float = jsNative and set(v: float): unit = jsNative
    member __.AllowEmailAddresses with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.PPMRU with get(): SPClientPeoplePickerMRU = jsNative and set(v: SPClientPeoplePickerMRU): unit = jsNative
    member __.UseLocalSuggestionCache with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.CurrentQueryStr with get(): string = jsNative and set(v: string): unit = jsNative
    member __.LatestSearchQueryStr with get(): string = jsNative and set(v: string): unit = jsNative
    member __.InitialSuggestions with get(): ResizeArray<ISPClientPeoplePickerEntity> = jsNative and set(v: ResizeArray<ISPClientPeoplePickerEntity>): unit = jsNative
    member __.CurrentLocalSuggestions with get(): ResizeArray<ISPClientPeoplePickerEntity> = jsNative and set(v: ResizeArray<ISPClientPeoplePickerEntity>): unit = jsNative
    member __.CurrentLocalSuggestionsDict with get(): ISPClientPeoplePickerEntity = jsNative and set(v: ISPClientPeoplePickerEntity): unit = jsNative
    member __.VisibleSuggestions with get(): float = jsNative and set(v: float): unit = jsNative
    member __.PrincipalAccountType with get(): string = jsNative and set(v: string): unit = jsNative
//    member __.PrincipalAccountTypeEnum with get(): undefined.PrincipalType = jsNative and set(v: undefined.PrincipalType): unit = jsNative
    member __.EnabledClaimProviders with get(): string = jsNative and set(v: string): unit = jsNative
  //  member __.SearchPrincipalSource with get(): undefined.PrincipalSource = jsNative and set(v: undefined.PrincipalSource): unit = jsNative
    //member __.ResolvePrincipalSource with get(): undefined.PrincipalSource = jsNative and set(v: undefined.PrincipalSource): unit = jsNative
    member __.MaximumEntitySuggestions with get(): float = jsNative and set(v: float): unit = jsNative
    member __.EditorWidthSet with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.QueryScriptInit with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.AutoFillControl with get(): SPClientAutoFill = jsNative and set(v: SPClientAutoFill): unit = jsNative
    member __.TotalUserCount with get(): float = jsNative and set(v: float): unit = jsNative
    member __.UnresolvedUserCount with get(): float = jsNative and set(v: float): unit = jsNative
    member __.UserQueryDict with get(): obj = jsNative and set(v: obj): unit = jsNative
    member __.ProcessedUserList with get(): obj = jsNative and set(v: obj): unit = jsNative
    member __.HasInputError with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.HasServerError with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.ShowUserPresence with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.TerminatingCharacter with get(): string = jsNative and set(v: string): unit = jsNative
    member __.UnresolvedUserElmIdToReplace with get(): string = jsNative and set(v: string): unit = jsNative
//    member __.WebApplicationID with get(): SP.Guid = jsNative and set(v: SP.Guid): unit = jsNative
    static member InitializeStandalonePeoplePicker(clientId: string, value: ResizeArray<ISPClientPeoplePickerEntity>, schema: ISPClientPeoplePickerSchema): unit = jsNative
    static member ParseUserKeyPaste(userKey: string): string = jsNative
    static member GetTopLevelControl(elmChild: HTMLElement): HTMLElement = jsNative
    static member AugmentEntity(entity: ISPClientPeoplePickerEntity): ISPClientPeoplePickerEntity = jsNative
    static member AugmentEntitySuggestions(pickerObj: SPClientPeoplePicker, allEntities: ResizeArray<ISPClientPeoplePickerEntity>, ?mergeLocal: bool): ResizeArray<ISPClientPeoplePickerEntity> = jsNative
    static member PickerObjectFromSubElement(elmSubElement: HTMLElement): SPClientPeoplePicker = jsNative
    static member TestLocalMatch(strSearchLower: string, dataEntity: ISPClientPeoplePickerEntity): bool = jsNative
    static member BuildUnresolvedEntity(key: string, dispText: string): ISPClientPeoplePickerEntity = jsNative
    static member AddAutoFillMetaData(pickerObj: SPClientPeoplePicker, options: ResizeArray<ISPClientPeoplePickerEntity>, numOpts: float): ResizeArray<ISPClientPeoplePickerEntity> = jsNative
    static member BuildAutoFillMenuItems(pickerObj: SPClientPeoplePicker, options: ResizeArray<ISPClientPeoplePickerEntity>): ResizeArray<ISPClientPeoplePickerEntity> = jsNative
    static member IsUserEntity(entity: ISPClientPeoplePickerEntity): bool = jsNative
    static member CreateSPPrincipalType(acctStr: string): float = jsNative
    member __.GetAllUserInfo(): ResizeArray<ISPClientPeoplePickerEntity> = jsNative
    member __.SetInitialValue(entities: ResizeArray<ISPClientPeoplePickerEntity>, ?initialErrorMsg: string): unit = jsNative
    member __.AddUserKeys(userKeys: string, bSearch: bool): unit = jsNative
    member __.BatchAddUserKeysOperation(allKeys: ResizeArray<string>, numProcessed: float): unit = jsNative
    member __.ResolveAllUsers(fnContinuation: Func<unit, unit>): unit = jsNative
//    member __.ExecutePickerQuery(queryIds: string, onSuccess: Func<string, SP.StringResult, unit>, onFailure: Func<string, SP.StringResult, unit>, fnContinuation: Func<unit, unit>): unit = jsNative
    member __.AddUnresolvedUserFromEditor(?bRunQuery: bool): unit = jsNative
    member __.AddUnresolvedUser(unresolvedUserObj: ISPClientPeoplePickerEntity, ?bRunQuery: bool): unit = jsNative
//    member __.UpdateUnresolvedUser(results: SP.StringResult, user: ISPClientPeoplePickerEntity): unit = jsNative
    member __.AddPickerSearchQuery(queryStr: string): string = jsNative
    member __.AddPickerResolveQuery(queryStr: string): string = jsNative
//    member __.GetPeoplePickerQueryParameters(): undefined.ClientPeoplePickerQueryParameters = jsNative
    member __.AddProcessedUser(userObject: ISPClientPeoplePickerEntity, ?fResolved: bool): string = jsNative
    member __.DeleteProcessedUser(elmToRemove: HTMLElement): unit = jsNative
    member __.OnControlValueChanged(): unit = jsNative
    member __.OnControlResolvedUserChanged(): unit = jsNative
    member __.EnsureAutoFillControl(): unit = jsNative
    member __.ShowAutoFill(resultsTable: ResizeArray<ISPClientAutoFillData>): unit = jsNative
    member __.FocusAutoFill(): unit = jsNative
    member __.BlurAutoFill(): unit = jsNative
    member __.IsAutoFillOpen(): bool = jsNative
    member __.EnsureEditorWidth(): unit = jsNative
    member __.SetFocusOnEditorEnd(): unit = jsNative
    member __.ToggleWaitImageDisplay(?bShowImage: bool): unit = jsNative
    member __.SaveAllUserKeysToHiddenInput(): unit = jsNative
    member __.GetCurrentEditorValue(): string = jsNative
    member __.GetControlValueAsJSObject(): ResizeArray<ISPClientPeoplePickerEntity> = jsNative
    member __.GetAllUserKeys(): string = jsNative
    member __.GetControlValueAsText(): string = jsNative
    member __.IsEmpty(): bool = jsNative
    member __.IterateEachProcessedUser(fnCallback: Func<float, SPClientPeoplePickerProcessedUser, unit>): unit = jsNative
    member __.HasResolvedUsers(): bool = jsNative
    member __.Validate(): unit = jsNative
    member __.ValidateCurrentState(): unit = jsNative
    member __.GetUnresolvedEntityErrorMessage(): string = jsNative
    member __.ShowErrorMessage(msg: string): unit = jsNative
    member __.ClearServerError(): unit = jsNative
    member __.SetServerError(): unit = jsNative
    member __.OnControlValidate(): unit = jsNative
    member __.SetEnabledState(bEnabled: bool): unit = jsNative
    member __.DisplayLocalSuggestions(): unit = jsNative
    member __.CompileLocalSuggestions(input: string): unit = jsNative
    member __.PlanningGlobalSearch(): bool = jsNative
    member __.AddLoadingSuggestionMenuOption(): unit = jsNative
    member __.ShowingLocalSuggestions(): bool = jsNative
    member __.ShouldUsePPMRU(): bool = jsNative
    member __.AddResolvedUserToLocalCache(resolvedEntity: ISPClientPeoplePickerEntity, resolveText: string): unit = jsNative

and [<AllowNullLiteral>] ISPClientPeoplePickerSchema =
    abstract TopLevelElementId: string option with get, set
    abstract EditorElementId: string option with get, set
    abstract AutoFillElementId: string option with get, set
    abstract ResolvedListElementId: string option with get, set
    abstract InitialHelpTextElementId: string option with get, set
    abstract WaitImageId: string option with get, set
    abstract HiddenInputId: string option with get, set
    abstract AllowMultipleValues: bool option with get, set
    abstract Required: bool option with get, set
    abstract AutoFillEnabled: bool option with get, set
    abstract ForceClaims: bool option with get, set
    abstract AllowEmailAddresses: bool option with get, set
    abstract AllUrlZones: bool option with get, set
    abstract UseLocalSuggestionCache: bool option with get, set
    abstract UserNoQueryPermission: bool option with get, set
    abstract VisibleSuggestions: float option with get, set
    abstract MaximumEntitySuggestions: float option with get, set
    abstract ErrorMessage: string option with get, set
    abstract InitialHelpText: string option with get, set
    abstract InitialSuggestions: ResizeArray<ISPClientPeoplePickerEntity> option with get, set
//    abstract UrlZone: SP.UrlZone option with get, set
//    abstract WebApplicationID: SP.Guid option with get, set
    abstract SharePointGroupID: float option with get, set
    abstract PrincipalAccountType: string option with get, set
    abstract EnabledClaimProvider: string option with get, set
    //abstract ResolvePrincipalSource: undefined.PrincipalSource option with get, set
    //abstract SearchPrincipalSource: undefined.PrincipalSource option with get, set
    abstract OnUserResolvedClientScript: Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit> option with get, set
    abstract OnValueChangedClientScript: Func<string, ResizeArray<ISPClientPeoplePickerEntity>, unit> option with get, set
    abstract Width: obj option with get, set
    abstract Rows: float option with get, set

and [<AllowNullLiteral>] [<Import("*","SPClientPeoplePickerMRU")>] SPClientPeoplePickerMRU() =
    member __.PPMRUVersion with get(): float = jsNative and set(v: float): unit = jsNative
    member __.MaxPPMRUItems with get(): float = jsNative and set(v: float): unit = jsNative
    member __.PPMRUDomLocalStoreKey with get(): string = jsNative and set(v: string): unit = jsNative
    static member GetSPClientPeoplePickerMRU(): SPClientPeoplePickerMRU = jsNative
    member __.GetItems(strKey: string): ResizeArray<obj> = jsNative
    member __.SetItem(strSearchTerm: string, objEntity: obj): unit = jsNative
    member __.ResetCache(): unit = jsNative

and [<AllowNullLiteral>] ISPClientPeoplePickerEntity =
    abstract Key: string option with get, set
    abstract Description: string option with get, set
    abstract DisplayText: string option with get, set
    abstract EntityType: string option with get, set
    abstract ProviderDisplayName: string option with get, set
    abstract ProviderName: string option with get, set
    abstract IsResolved: bool option with get, set
    abstract EntityData: obj option with get, set
    abstract MultipleMatches: ResizeArray<ISPClientPeoplePickerEntity> with get, set
    abstract DomainText: string option with get, set
    [<Emit("$0[$1]{{=$2}}")>] abstract Item: key: string -> obj with get, set

and [<AllowNullLiteral>] [<Import("*","SPClientPeoplePickerProcessedUser")>] SPClientPeoplePickerProcessedUser() =
    member __.UserContainerElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DisplayElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.PresenceElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DeleteUserElementId with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SID with get(): string = jsNative and set(v: string): unit = jsNative
    member __.DisplayName with get(): string = jsNative and set(v: string): unit = jsNative
    member __.SIPAddress with get(): string = jsNative and set(v: string): unit = jsNative
    member __.UserInfo with get(): ISPClientPeoplePickerEntity = jsNative and set(v: ISPClientPeoplePickerEntity): unit = jsNative
    member __.ResolvedUser with get(): bool = jsNative and set(v: bool): unit = jsNative
    member __.Suggestions with get(): ResizeArray<ISPClientAutoFillData> = jsNative and set(v: ResizeArray<ISPClientAutoFillData>): unit = jsNative
    member __.ErrorDescription with get(): string = jsNative and set(v: string): unit = jsNative
    member __.ResolveText with get(): string = jsNative and set(v: string): unit = jsNative
    member __.UpdateResolvedUser(newUserInfo: ISPClientPeoplePickerEntity, strNewElementId: string): unit = jsNative
    member __.UpdateSuggestions(entity: ISPClientPeoplePickerEntity): unit = jsNative
    member __.BuildUserHTML(): string = jsNative
    member __.UpdateUserMaxWidth(): unit = jsNative
    member __.ResolvedAsUnverifiedEmail(): string = jsNative
    static member BuildUserPresenceHtml(elmId: string, strSip: string, ?bResolved: bool): string = jsNative
    static member GetUserContainerElement(elmChild: HTMLElement): HTMLElement = jsNative
    static member HandleProcessedUserClick(ndClicked: HTMLElement): unit = jsNative
    static member DeleteProcessedUser(elmToRemove: HTMLElement): unit = jsNative
    static member HandleDeleteProcessedUserKey(e: Event): unit = jsNative
    static member HandleResolveProcessedUserKey(e: Event): unit = jsNative

and [<AllowNullLiteral>] IListItem =
    abstract ID: float with get, set
    abstract ContentTypeId: string with get, set

type Globals =
    [<Global>] static member _spBodyOnLoadFunctions with get(): ResizeArray<Function> = jsNative and set(v: ResizeArray<Function>): unit = jsNative
    [<Global>] static member _spBodyOnLoadFunctionNames with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
    [<Global>] static member _spBodyOnLoadCalled with get(): bool = jsNative and set(v: bool): unit = jsNative
    [<Global>] static member Strings with get(): obj = jsNative and set(v: obj): unit = jsNative
    [<Global>] static member ajaxNavigate with get(): AjaxNavigate = jsNative and set(v: AjaxNavigate): unit = jsNative
    [<Global>] static member browseris with get(): Browseris = jsNative and set(v: Browseris): unit = jsNative
    [<Global>] static member ``mstatic member`` with get(): MQuery = jsNative and set(v: MQuery): unit = jsNative
    [<Global>] static member spMgr with get(): SPMgr = jsNative and set(v: SPMgr): unit = jsNative
