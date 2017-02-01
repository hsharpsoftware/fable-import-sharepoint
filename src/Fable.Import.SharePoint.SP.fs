namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module SP =
    type [<AllowNullLiteral>] [<Import("SOD","SP")>] SOD() =
        static member execute(fileName: string, functionName: string, [<ParamArray>] args: obj[]): unit = jsNative
        static member executeFunc(fileName: string, typeName: string, fn: Func<unit, unit>): unit = jsNative
        static member executeOrDelayUntilEventNotified(func: Function, eventName: string): bool = jsNative
        static member executeOrDelayUntilScriptLoaded(func: Func<unit, unit>, depScriptFileName: string): bool = jsNative
        static member notifyScriptLoadedAndExecuteWaitingJobs(scriptFileName: string): unit = jsNative
        static member notifyEventAndExecuteWaitingJobs(eventName: string, ?args: ResizeArray<obj>): unit = jsNative
        static member registerSod(fileName: string, url: string): unit = jsNative
        static member registerSodDep(fileName: string, dependentFileName: string): unit = jsNative
        static member loadMultiple(keys: ResizeArray<string>, fn: Func<unit, unit>, ?bSync: bool): unit = jsNative
        static member delayUntilEventNotified(func: Function, eventName: string): unit = jsNative
        static member get_prefetch(): bool = jsNative
        static member set_prefetch(value: bool): unit = jsNative
        static member get_ribbonImagePrefetchEnabled(): bool = jsNative
        static member set_ribbonImagePrefetchEnabled(value: bool): unit = jsNative

    and ListLevelPermissionMask =
        | viewListItems = 0
        | insertListItems = 1
        | editListItems = 2
        | deleteListItems = 3
        | approveItems = 4
        | openItems = 5
        | viewVersions = 6
        | deleteVersions = 7
        | breakCheckout = 8
        | managePersonalViews = 9
        | manageLists = 10

    and [<AllowNullLiteral>] [<Import("HtmlBuilder","SP")>] HtmlBuilder() =
        member __.addAttribute(name: string, value: string): unit = jsNative
        member __.addCssClass(cssClassName: string): unit = jsNative
        member __.addCommunitiesCssClass(cssClassName: string): unit = jsNative
        member __.renderBeginTag(tagName: string): unit = jsNative
        member __.renderEndTag(): unit = jsNative
        member __.write(s: string): unit = jsNative
        member __.writeEncoded(s: string): unit = jsNative
        member __.toString(): string = jsNative

    and [<AllowNullLiteral>] [<Import("ScriptHelpers","SP")>] ScriptHelpers() =
        static member disableWebpartSelection(context: SPClientTemplates.RenderContext): unit = jsNative
        static member getDocumentQueryPairs(): obj = jsNative
        static member getFieldFromSchema(schema: SPClientTemplates.ListSchema, fieldName: string): SPClientTemplates.FieldSchema = jsNative
        static member getLayoutsPageUrl(pageName: string, webServerRelativeUrl: string): string = jsNative
        static member getListLevelPermissionMask(jsonItem: string): float = jsNative
        static member getTextAreaElementValue(textAreaElement: HTMLTextAreaElement): string = jsNative
        static member getUrlQueryPairs(docUrl: string): obj = jsNative
        //static member getUserFieldProperty(item: ListItem, fieldName: string, propertyName: string): obj = jsNative
        static member getUserFieldProperty(item: obj, fieldName: string, propertyName: string): obj = jsNative
        static member hasPermission(listPermissionMask: float, listPermission: ListLevelPermissionMask): bool = jsNative
        //static member newGuid(): Guid = jsNative
        static member isNullOrEmptyString(str: string): bool = jsNative
        static member isNullOrUndefined(obj: obj): bool = jsNative
        static member isNullOrUndefinedOrEmpty(str: string): bool = jsNative
        static member isUndefined(obj: obj): bool = jsNative
        static member replaceOrAddQueryString(url: string, key: string, value: string): string = jsNative
        static member removeHtml(str: string): string = jsNative
        static member removeStyleChildren(element: HTMLElement): unit = jsNative
        static member removeHtmlAndTrimStringWithEllipsis(str: string, maxLength: float): string = jsNative
        static member setTextAreaElementValue(textAreaElement: HTMLTextAreaElement, newValue: string): unit = jsNative
        static member truncateToInt(n: float): float = jsNative
        static member urlCombine(path1: string, path2: string): string = jsNative
        static member resizeImageToSquareLength(imgElement: HTMLImageElement, squareLength: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("PageContextInfo","SP")>] PageContextInfo() =
        static member get_siteServerRelativeUrl(): string = jsNative
        static member get_webServerRelativeUrl(): string = jsNative
        static member get_webAbsoluteUrl(): string = jsNative
        static member get_serverRequestPath(): string = jsNative
        static member get_siteAbsoluteUrl(): string = jsNative
        static member get_webTitle(): string = jsNative
        static member get_tenantAppVersion(): string = jsNative
        static member get_webLogoUrl(): string = jsNative
        static member get_webLanguage(): float = jsNative
        static member get_currentLanguage(): float = jsNative
        static member get_pageItemId(): float = jsNative
        static member get_pageListId(): string = jsNative
        static member get_webPermMasks(): obj = jsNative
        static member get_currentCultureName(): string = jsNative
        static member get_currentUICultureName(): string = jsNative
        static member get_clientServerTimeDelta(): float = jsNative
        static member get_userLoginName(): string = jsNative
        static member get_webTemplate(): string = jsNative
        member __.get_pagePersonalizationScope(): string = jsNative

    and [<AllowNullLiteral>] [<Import("ContextPermissions","SP")>] ContextPermissions() =
        member __.has(perm: float): bool = jsNative
        member __.hasPermissions(high: float, low: float): bool = jsNative
        member __.fromJson(json: obj): unit = jsNative

    module ListOperation =
        module ViewOperation =
            type [<Import("ListOperation.ViewOperation","SP")>] Globals =
                static member getSelectedView(): string = jsNative
                static member navigateUp(viewId: string): unit = jsNative
                static member refreshView(viewId: string): unit = jsNative



        module Selection =
            type [<Import("ListOperation.Selection","SP")>] Globals =
                static member selectListItem(iid: string, bSelect: bool): unit = jsNative
                static member getSelectedItems(): ResizeArray<obj> = jsNative
                static member getSelectedList(): string = jsNative
                static member getSelectedView(): string = jsNative
                static member navigateUp(viewId: string): unit = jsNative
                static member deselectAllListItems(iid: string): unit = jsNative



        module Overrides =
            type [<Import("ListOperation.Overrides","SP")>] Globals =
                static member overrideDeleteConfirmation(listId: string, overrideText: string): unit = jsNative



    type RequestExecutorErrors =
        | requestAbortedOrTimedout = 0
        | unexpectedResponse = 1
        | httpError = 2
        | noAppWeb = 3
        | domainDoesNotMatch = 4
        | noTrustedOrigins = 5
        | iFrameLoadError = 6

    and [<AllowNullLiteral>] [<Import("RequestExecutor","SP")>] RequestExecutor(url: string, ?options: obj) =
        member __.get_formDigestHandlingEnabled(): bool = jsNative
        member __.set_formDigestHandlingEnabled(value: bool): unit = jsNative
        member __.get_iFrameSourceUrl(): string = jsNative
        member __.set_iFrameSourceUrl(value: string): unit = jsNative
        member __.executeAsync(requestInfo: RequestInfo): unit = jsNative
        member __.attemptLogin(returnUrl: string, success: Func<ResponseInfo, unit>, ?error: Func<ResponseInfo, RequestExecutorErrors, string, unit>): unit = jsNative

    and [<AllowNullLiteral>] RequestInfo =
        abstract url: string with get, set
        abstract ``method``: string option with get, set
        abstract headers: obj option with get, set
        abstract body: U2<string, Uint8Array> option with get, set
        abstract binaryStringRequestBody: bool option with get, set
        abstract binaryStringResponseBody: bool option with get, set
        abstract timeout: float option with get, set
        abstract success: Func<ResponseInfo, unit> option with get, set
        abstract error: Func<ResponseInfo, RequestExecutorErrors, string, unit> option with get, set
        abstract state: obj option with get, set

    and [<AllowNullLiteral>] ResponseInfo =
        abstract statusCode: float option with get, set
        abstract statusText: string option with get, set
        abstract responseAvailable: bool with get, set
        abstract allResponseHeaders: string option with get, set
        abstract headers: obj option with get, set
        abstract contentType: string option with get, set
        abstract body: U2<string, Uint8Array> option with get, set
        abstract state: obj option with get, set
(*
    and [<AllowNullLiteral>] [<Import("ProxyWebRequestExecutor","SP")>] ProxyWebRequestExecutor(url: string, ?options: obj) =
        interface WebRequestExecutor


    and [<AllowNullLiteral>] [<Import("ProxyWebRequestExecutorFactory","SP")>] ProxyWebRequestExecutorFactory(url: string, ?options: obj) =
        interface IWebRequestExecutorFactory with
            member __.createWebRequestExecutor(): WebRequestExecutor = jsNative
*)



    type [<AllowNullLiteral>] [<Import("ScriptUtility","SP")>] ScriptUtility() =
        static member isNullOrEmptyString(str: string): bool = jsNative
        static member isNullOrUndefined(obj: obj): bool = jsNative
        static member isUndefined(obj: obj): bool = jsNative
        static member truncateToInt(n: float): float = jsNative

    and [<AllowNullLiteral>] [<Import("Guid","SP")>] Guid(guidText: string) =
        static member get_empty(): Guid = jsNative
        static member newGuid(): Guid = jsNative
        static member isValid(uuid: string): bool = jsNative
        member __.toString(): string = jsNative
        member __.toString(format: string): string = jsNative
        member __.equals(uuid: Guid): bool = jsNative
        member __.toSerialized(): string = jsNative

    and PermissionKind =
        | emptyMask = 0
        | viewListItems = 1
        | addListItems = 2
        | editListItems = 3
        | deleteListItems = 4
        | approveItems = 5
        | openItems = 6
        | viewVersions = 7
        | deleteVersions = 8
        | cancelCheckout = 9
        | managePersonalViews = 10
        | manageLists = 11
        | viewFormPages = 12
        | anonymousSearchAccessList = 13
        | _open = 14
        | viewPages = 15
        | addAndCustomizePages = 16
        | applyThemeAndBorder = 17
        | applyStyleSheets = 18
        | viewUsageData = 19
        | createSSCSite = 20
        | manageSubwebs = 21
        | createGroups = 22
        | managePermissions = 23
        | browseDirectories = 24
        | browseUserInfo = 25
        | addDelPrivateWebParts = 26
        | updatePersonalWebParts = 27
        | manageWeb = 28
        | anonymousSearchAccessWebLists = 29
        | useClientIntegration = 30
        | useRemoteAPIs = 31
        | manageAlerts = 32
        | createAlerts = 33
        | editMyUserInfo = 34
        | enumeratePermissions = 35
        | fullMask = 36

    and [<AllowNullLiteral>] [<Import("BaseCollection","SP")>] BaseCollection<'T>() =
        member __.get_count(): float = jsNative
        member __.itemAtIndex(index: float): 'T = jsNative
        interface IEnumerable<'T> with
        member __.getEnumerator(): IEnumerator<'T> = jsNative 

    and [<AllowNullLiteral>] IFromJson =
        abstract fromJson: initValue: obj -> unit
        abstract customFromJson: initValue: obj -> bool

    and [<AllowNullLiteral>] [<Import("Base64EncodedByteArray","SP")>] Base64EncodedByteArray(base64Str: string) =
        member __.get_length(): float = jsNative
        member __.toBase64String(): string = jsNative
        member __.append(b: obj): unit = jsNative
        member __.getByteAt(index: float): obj = jsNative
        member __.setByteAt(index: float, b: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ConditionalScopeBase","SP")>] ConditionalScopeBase() =
        member __.startScope(): obj = jsNative
        member __.startIfTrue(): obj = jsNative
        member __.startIfFalse(): obj = jsNative
        member __.get_testResult(): bool = jsNative
        member __.fromJson(initValue: obj): unit = jsNative
        member __.customFromJson(initValue: obj): bool = jsNative

    and [<AllowNullLiteral>] [<Import("ClientObjectPropertyConditionalScope","SP")>] ClientObjectPropertyConditionalScope(clientObject: ClientObject, propertyName: string, comparisonOperator: string, valueToCompare: obj, allowAllActions: bool) =
        inherit ConditionalScopeBase()


    and [<AllowNullLiteral>] [<Import("ClientResult","SP")>] ClientResult<'T>() =
        member __.get_value(): 'T = jsNative
        member __.setValue(value: 'T): unit = jsNative

    and [<AllowNullLiteral>] [<Import("BooleanResult","SP")>] BooleanResult() =
        member __.get_value(): bool = jsNative

    and [<AllowNullLiteral>] [<Import("CharResult","SP")>] CharResult() =
        member __.get_value(): obj = jsNative

    and [<AllowNullLiteral>] [<Import("IntResult","SP")>] IntResult() =
        member __.get_value(): float = jsNative

    and [<AllowNullLiteral>] [<Import("DoubleResult","SP")>] DoubleResult() =
        member __.get_value(): float = jsNative

    and [<AllowNullLiteral>] [<Import("StringResult","SP")>] StringResult() =
        member __.get_value(): string = jsNative

    and [<AllowNullLiteral>] [<Import("DateTimeResult","SP")>] DateTimeResult() =
        member __.get_value(): DateTime = jsNative

    and [<AllowNullLiteral>] [<Import("GuidResult","SP")>] GuidResult() =
        member __.get_value(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("JsonObjectResult","SP")>] JsonObjectResult() =
        member __.get_value(): obj = jsNative

    and [<AllowNullLiteral>] [<Import("ClientDictionaryResultHandler","SP")>] ClientDictionaryResultHandler<'T>(dict: ClientResult<'T>) =
        class end

    and [<AllowNullLiteral>] [<Import("ClientUtility","SP")>] ClientUtility() =
        static member urlPathEncodeForXmlHttpRequest(url: string): string = jsNative
        static member getOrCreateObjectPathForConstructor(context: ClientRuntimeContext, typeId: string, args: ResizeArray<obj>): ObjectPath = jsNative

    and [<AllowNullLiteral>] [<Import("XElement","SP")>] XElement() =
        member __.get_name(): string = jsNative
        member __.set_name(value: string): unit = jsNative
        member __.get_attributes(): obj = jsNative
        member __.set_attributes(value: obj): unit = jsNative
        member __.get_children(): obj = jsNative
        member __.set_children(value: obj): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientXElement","SP")>] ClientXElement() =
        member __.get_element(): XElement = jsNative
        member __.set_element(value: XElement): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientXDocument","SP")>] ClientXDocument() =
        member __.get_root(): XElement = jsNative
        member __.set_root(value: XElement): unit = jsNative

    and [<AllowNullLiteral>] [<Import("DataConvert","SP")>] DataConvert() =
        static member writePropertiesToXml(writer: XmlWriter, obj: obj, propNames: ResizeArray<string>, serializationContext: SerializationContext): unit = jsNative
        static member populateDictionaryFromObject(dict: obj, parentNode: obj): unit = jsNative
        static member fixupTypes(context: ClientRuntimeContext, dict: obj): unit = jsNative
        static member populateArray(context: ClientRuntimeContext, dest: obj, jsonArrayFromServer: obj): unit = jsNative
        static member fixupType(context: ClientRuntimeContext, obj: obj): obj = jsNative
        static member writeDictionaryToXml(writer: XmlWriter, dict: obj, topLevelElementTagName: string, keys: obj, serializationContext: SerializationContext): unit = jsNative
        static member writeValueToXmlElement(writer: XmlWriter, objValue: obj, serializationContext: SerializationContext): unit = jsNative
        static member invokeSetProperty(obj: obj, propName: string, propValue: obj): unit = jsNative
        static member invokeGetProperty(obj: obj, propName: string): obj = jsNative
        static member specifyDateTimeKind(datetime: DateTime, kind: DateTimeKind): unit = jsNative
        static member getDateTimeKind(datetime: DateTime): DateTimeKind = jsNative
        static member createUnspecifiedDateTime(year: float, month: float, day: float, hour: float, minute: float, second: float, milliseconds: float): DateTime = jsNative
        static member createUtcDateTime(milliseconds: float): DateTime = jsNative
        static member createLocalDateTime(milliseconds: float): DateTime = jsNative

    (*
    and [<AllowNullLiteral>] IWebRequestExecutorFactory =
        abstract createWebRequestExecutor: unit -> WebRequestExecutor

    and [<AllowNullLiteral>] [<Import("PageRequestFailedEventArgs","SP")>] PageRequestFailedEventArgs() =
        interface Sys.EventArgs
        member __.get_executor(): WebRequestExecutor = jsNative
        member __.get_errorMessage(): string = jsNative
        member __.get_isErrorPage(): bool = jsNative

    and [<AllowNullLiteral>] [<Import("PageRequestSucceededEventArgs","SP")>] PageRequestSucceededEventArgs() =
        interface Sys.EventArgs
        member __.get_executor(): WebRequestExecutor = jsNative 

    and [<AllowNullLiteral>] [<Import("PageRequest","SP")>] PageRequest() =
        member __.get_request(): WebRequest = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_expectedContentType(): string = jsNative
        member __.set_expectedContentType(value: string): unit = jsNative
        member __.post(body: string): unit = jsNative
        member __.get(): unit = jsNative
        static member doPost(url: string, body: string, expectedContentType: string, succeededHandler: Func<obj, PageRequestSucceededEventArgs, unit>, failedHandler: Func<obj, PageRequestFailedEventArgs, unit>): unit = jsNative
        static member doGet(url: string, expectedContentType: string, succeededHandler: Func<obj, PageRequestSucceededEventArgs, unit>, failedHandler: Func<obj, PageRequestFailedEventArgs, unit>): unit = jsNative
        member __.add_succeeded(value: Func<obj, PageRequestSucceededEventArgs, unit>): unit = jsNative
        member __.remove_succeeded(value: Func<obj, PageRequestSucceededEventArgs, unit>): unit = jsNative
        member __.add_failed(value: Func<obj, PageRequestFailedEventArgs, unit>): unit = jsNative
        member __.remove_failed(value: Func<obj, PageRequestFailedEventArgs, unit>): unit = jsNative*)

    and [<AllowNullLiteral>] [<Import("ResResources","SP")>] ResResources() =
        static member getString(resourceId: string, args: ResizeArray<obj>): string = jsNative

    and [<AllowNullLiteral>] [<Import("XmlWriter","SP")>] XmlWriter() =
        //static member create(sb: Sys.StringBuilder): XmlWriter = jsNative
        static member create(sb: obj): XmlWriter = jsNative
        member __.writeStartElement(tagName: string): unit = jsNative
        member __.writeElementString(tagName: string, value: string): unit = jsNative
        member __.writeEndElement(): unit = jsNative
        member __.writeAttributeString(localName: string, value: string): unit = jsNative
        member __.writeStartAttribute(localName: string): unit = jsNative
        member __.writeEndAttribute(): unit = jsNative
        member __.writeString(value: string): unit = jsNative
        member __.writeRaw(xml: string): unit = jsNative
        member __.close(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientConstants","SP")>] ClientConstants() =
        member __.AddExpandoFieldTypeSuffix with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Actions with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ApplicationName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Body with get(): string = jsNative and set(v: string): unit = jsNative
        member __.CatchScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ChildItemQuery with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ChildItems with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ConditionalScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Constructor with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Context with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorInfo with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorStackTrace with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorCode with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorTypeName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorValue with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorDetails with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ErrorTraceCorrelationId with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ExceptionHandlingScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ExceptionHandlingScopeSimple with get(): string = jsNative and set(v: string): unit = jsNative
        member __.QueryableExpression with get(): string = jsNative and set(v: string): unit = jsNative
        member __.FinallyScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.HasException with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Id with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Identity with get(): string = jsNative and set(v: string): unit = jsNative
        member __.IfFalseScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.IfTrueScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.IsNull with get(): string = jsNative and set(v: string): unit = jsNative
        member __.LibraryVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.TraceCorrelationId with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Count with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Method with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Methods with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Name with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Object with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectPathId with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectPath with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectPaths with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectType with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectIdentity with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectIdentityQuery with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ObjectVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Parameter with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Parameters with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ParentId with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Processed with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Property with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Properties with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Query with get(): string = jsNative and set(v: string): unit = jsNative
        member __.QueryResult with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Request with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Results with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ScalarProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SchemaVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ScopeId with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SelectAll with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SelectAllProperties with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SetProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SetStaticProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.StaticMethod with get(): string = jsNative and set(v: string): unit = jsNative
        member __.StaticProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixChar with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixByte with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixInt16 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixUInt16 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixInt32 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixUInt32 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixInt64 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixUInt64 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixSingle with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixDouble with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixDecimal with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixTimeSpan with get(): string = jsNative and set(v: string): unit = jsNative
        member __.SuffixArray with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Test with get(): string = jsNative and set(v: string): unit = jsNative
        member __.TryScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Type with get(): string = jsNative and set(v: string): unit = jsNative
        member __.TypeId with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Update with get(): string = jsNative and set(v: string): unit = jsNative
        member __.Version with get(): string = jsNative and set(v: string): unit = jsNative
        member __.XmlElementName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.XmlElementAttributes with get(): string = jsNative and set(v: string): unit = jsNative
        member __.XmlElementChildren with get(): string = jsNative and set(v: string): unit = jsNative
        member __.XmlNamespace with get(): string = jsNative and set(v: string): unit = jsNative
        member __.FieldValuesMethodName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.RequestTokenHeader with get(): string = jsNative and set(v: string): unit = jsNative
        member __.FormDigestHeader with get(): string = jsNative and set(v: string): unit = jsNative
        member __.useWebLanguageHeader with get(): string = jsNative and set(v: string): unit = jsNative
        member __.useWebLanguageHeaderValue with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ClientTagHeader with get(): string = jsNative and set(v: string): unit = jsNative
        member __.TraceCorrelationIdRequestHeader with get(): string = jsNative and set(v: string): unit = jsNative
        member __.TraceCorrelationIdResponseHeader with get(): string = jsNative and set(v: string): unit = jsNative
        member __.greaterThan with get(): string = jsNative and set(v: string): unit = jsNative
        member __.lessThan with get(): string = jsNative and set(v: string): unit = jsNative
        member __.equal with get(): string = jsNative and set(v: string): unit = jsNative
        member __.notEqual with get(): string = jsNative and set(v: string): unit = jsNative
        member __.greaterThanOrEqual with get(): string = jsNative and set(v: string): unit = jsNative
        member __.lessThanOrEqual with get(): string = jsNative and set(v: string): unit = jsNative
        member __.andAlso with get(): string = jsNative and set(v: string): unit = jsNative
        member __.orElse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.not with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionParameter with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionStaticProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionMethod with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionStaticMethod with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionConstant with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionConvert with get(): string = jsNative and set(v: string): unit = jsNative
        member __.expressionTypeIs with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ofType with get(): string = jsNative and set(v: string): unit = jsNative
        member __.take with get(): string = jsNative and set(v: string): unit = jsNative
        member __.where with get(): string = jsNative and set(v: string): unit = jsNative
        member __.orderBy with get(): string = jsNative and set(v: string): unit = jsNative
        member __.orderByDescending with get(): string = jsNative and set(v: string): unit = jsNative
        member __.thenBy with get(): string = jsNative and set(v: string): unit = jsNative
        member __.thenByDescending with get(): string = jsNative and set(v: string): unit = jsNative
        member __.queryableObject with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ServiceFileName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.ServiceMethodName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.fluidApplicationInitParamUrl with get(): string = jsNative and set(v: string): unit = jsNative
        member __.fluidApplicationInitParamViaUrl with get(): string = jsNative and set(v: string): unit = jsNative
        member __.fluidApplicationInitParamRequestToken with get(): string = jsNative and set(v: string): unit = jsNative
        member __.fluidApplicationInitParamFormDigestTimeoutSeconds with get(): string = jsNative and set(v: string): unit = jsNative
        member __.fluidApplicationInitParamFormDigest with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientSchemaVersions","SP")>] ClientSchemaVersions() =
        member __.version14 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.version15 with get(): string = jsNative and set(v: string): unit = jsNative
        member __.currentVersion with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientErrorCodes","SP")>] ClientErrorCodes() =
        member __.genericError with get(): float = jsNative and set(v: float): unit = jsNative
        member __.accessDenied with get(): float = jsNative and set(v: float): unit = jsNative
        member __.docAlreadyExists with get(): float = jsNative and set(v: float): unit = jsNative
        member __.versionConflict with get(): float = jsNative and set(v: float): unit = jsNative
        member __.listItemDeleted with get(): float = jsNative and set(v: float): unit = jsNative
        member __.invalidFieldValue with get(): float = jsNative and set(v: float): unit = jsNative
        member __.notSupported with get(): float = jsNative and set(v: float): unit = jsNative
        member __.redirect with get(): float = jsNative and set(v: float): unit = jsNative
        member __.notSupportedRequestVersion with get(): float = jsNative and set(v: float): unit = jsNative
        member __.fieldValueFailedValidation with get(): float = jsNative and set(v: float): unit = jsNative
        member __.itemValueFailedValidation with get(): float = jsNative and set(v: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientAction","SP")>] ClientAction() =
        member __.get_id(): float = jsNative
        member __.get_path(): ObjectPath = jsNative
        member __.get_name(): string = jsNative

    and [<AllowNullLiteral>] [<Import("ClientActionSetProperty","SP")>] ClientActionSetProperty(obj: ClientObject, propName: string, propValue: obj) =
        inherit ClientAction()


    and [<AllowNullLiteral>] [<Import("ClientActionSetStaticProperty","SP")>] ClientActionSetStaticProperty(context: ClientRuntimeContext, typeId: string, propName: string, propValue: obj) =
        inherit ClientAction()


    and [<AllowNullLiteral>] [<Import("ClientActionInvokeMethod","SP")>] ClientActionInvokeMethod(obj: ClientObject, methodName: string, parameters: ResizeArray<obj>) =
        inherit ClientAction()


    and [<AllowNullLiteral>] [<Import("ClientActionInvokeStaticMethod","SP")>] ClientActionInvokeStaticMethod(context: ClientRuntimeContext, typeId: string, methodName: string, parameters: ResizeArray<obj>) =
        inherit ClientAction()


    and [<AllowNullLiteral>] [<Import("ClientObject","SP")>] ClientObject() =
        member __.get_context(): ClientRuntimeContext = jsNative
        member __.get_path(): ObjectPath = jsNative
        member __.get_objectVersion(): string = jsNative
        member __.set_objectVersion(value: string): unit = jsNative
        member __.fromJson(initValue: obj): unit = jsNative
        member __.customFromJson(initValue: obj): bool = jsNative
        member __.retrieve(): unit = jsNative
        member __.refreshLoad(): unit = jsNative
        member __.retrieve(propertyNames: ResizeArray<string>): unit = jsNative
        member __.isPropertyAvailable(propertyName: string): bool = jsNative
        member __.isObjectPropertyInstantiated(propertyName: string): bool = jsNative
        member __.get_serverObjectIsNull(): bool = jsNative
        member __.get_typedObject(): ClientObject = jsNative

    and [<AllowNullLiteral>] [<Import("ClientObjectData","SP")>] ClientObjectData() =
        member __.get_properties(): obj = jsNative
        member __.get_clientObjectProperties(): obj = jsNative
        member __.get_methodReturnObjects(): obj = jsNative

    and [<AllowNullLiteral>] [<Import("ClientObjectCollection","SP")>] ClientObjectCollection<'T>() =
        inherit ClientObject()
        member __.get_areItemsAvailable(): bool = jsNative
        member __.retrieveItems(): ClientObjectPrototype = jsNative
        member __.get_count(): float = jsNative
        member __.get_data(): ResizeArray<'T> = jsNative
        member __.addChild(obj: 'T): unit = jsNative
        member __.getItemAtIndex(index: float): 'T = jsNative
        member __.fromJson(obj: obj): unit = jsNative
        interface IEnumerable<'T> with
        member __.getEnumerator(): IEnumerator<'T> = jsNative

    and [<AllowNullLiteral>] [<Import("ClientObjectList","SP")>] ClientObjectList<'T>(context: ClientRuntimeContext, objectPath: ObjectPath, childItemType: obj) =
        inherit ClientObjectCollection<'T>()
        member __.fromJson(initValue: obj): unit = jsNative
        member __.customFromJson(initValue: obj): bool = jsNative

    and [<AllowNullLiteral>] [<Import("ClientObjectPrototype","SP")>] ClientObjectPrototype() =
        member __.retrieve(): unit = jsNative
        member __.retrieve(propertyNames: ResizeArray<string>): unit = jsNative
        member __.retrieveObject(propertyName: string): ClientObjectPrototype = jsNative
        member __.retrieveCollectionObject(propertyName: string): ClientObjectCollectionPrototype = jsNative

    and [<AllowNullLiteral>] [<Import("ClientObjectCollectionPrototype","SP")>] ClientObjectCollectionPrototype() =
        inherit ClientObjectPrototype()
        member __.retrieveItems(): ClientObjectPrototype = jsNative

    and ClientRequestStatus =
        | active = 0
        | inProgress = 1
        | completedSuccess = 2
        | completedException = 3

    //and [<AllowNullLiteral>] [<Import("WebRequestEventArgs","SP")>] WebRequestEventArgs(webRequest: WebRequest) = class end
    and [<AllowNullLiteral>] [<Import("WebRequestEventArgs","SP")>] WebRequestEventArgs(webRequest: obj) = class end
        //interface Sys.EventArgs
        //member __.get_webRequest(): WebRequest = jsNative

    and [<AllowNullLiteral>] [<Import("ClientRequest","SP")>] ClientRequest() =
        static member get_nextSequenceId(): float = jsNative
        //member __.get_webRequest(): WebRequest = jsNative
        member __.get_webRequest(): obj = jsNative
        member __.add_requestSucceeded(value: Func<obj, ClientRequestSucceededEventArgs, unit>): unit = jsNative
        member __.remove_requestSucceeded(value: Func<obj, ClientRequestSucceededEventArgs, unit>): unit = jsNative
        member __.add_requestFailed(value: Func<obj, ClientRequestFailedEventArgs, unit>): unit = jsNative
        member __.remove_requestFailed(value: Func<obj, ClientRequestFailedEventArgs, unit>): unit = jsNative
        member __.get_navigateWhenServerRedirect(): bool = jsNative
        member __.set_navigateWhenServerRedirect(value: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientRequestEventArgs","SP")>] ClientRequestEventArgs() =
        //interface Sys.EventArgs
        member __.get_request(): ClientRequest = jsNative

    and [<AllowNullLiteral>] [<Import("ClientRequestFailedEventArgs","SP")>] ClientRequestFailedEventArgs(request: ClientRequest, message: string, stackTrace: string, errorCode: float, errorValue: string, errorTypeName: string, errorDetails: obj, errorTraceCorrelationId: string) =
        inherit ClientRequestEventArgs()
        member __.get_message(): string = jsNative
        member __.get_stackTrace(): string = jsNative
        member __.get_errorCode(): float = jsNative
        member __.get_errorValue(): string = jsNative
        member __.get_errorTypeName(): string = jsNative
        member __.get_errorDetails(): obj = jsNative
        member __.get_errorTraceCorrelationId(): string = jsNative

    and [<AllowNullLiteral>] [<Import("ClientRequestSucceededEventArgs","SP")>] ClientRequestSucceededEventArgs() = class end


    and [<AllowNullLiteral>] [<Import("SimpleDataTable","SP")>] SimpleDataTable() =
        member __.get_rows(): ResizeArray<obj> = jsNative

    and [<AllowNullLiteral>] [<Import("ClientValueObject","SP")>] ClientValueObject() =
        member __.fromJson(obj: obj): unit = jsNative
        member __.customFromJson(obj: obj): bool = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative
        member __.customWriteToXml(writer: XmlWriter, serializationContext: SerializationContext): bool = jsNative
        member __.get_typeId(): string = jsNative

    and [<AllowNullLiteral>] [<Import("ClientValueObjectCollection","SP")>] ClientValueObjectCollection<'T>() =
        inherit ClientValueObject()
        member __.get_count(): float = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative
        interface IEnumerable<'T> with
        member __.getEnumerator(): IEnumerator<'T> = jsNative

    and [<AllowNullLiteral>] [<Import("ExceptionHandlingScope","SP")>] ExceptionHandlingScope(context: ClientRuntimeContext) =
        member __.startScope(): obj = jsNative
        member __.startTry(): obj = jsNative
        member __.startCatch(): obj = jsNative
        member __.startFinally(): obj = jsNative
        member __.get_processed(): bool = jsNative
        member __.get_hasException(): bool = jsNative
        member __.get_errorMessage(): string = jsNative
        member __.get_serverStackTrace(): string = jsNative
        member __.get_serverErrorCode(): float = jsNative
        member __.get_serverErrorValue(): string = jsNative
        member __.get_serverErrorTypeName(): string = jsNative
        member __.get_serverErrorDetails(): obj = jsNative

    and [<AllowNullLiteral>] [<Import("ObjectIdentityQuery","SP")>] ObjectIdentityQuery(objectPath: ObjectPath) =
        inherit ClientAction()


    and [<AllowNullLiteral>] [<Import("ObjectPath","SP")>] ObjectPath() =
        member __.setPendingReplace(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ObjectPathProperty","SP")>] ObjectPathProperty(context: ClientRuntimeContext, parent: ObjectPath, propertyName: string) =
        inherit ObjectPath()


    and [<AllowNullLiteral>] [<Import("ObjectPathStaticProperty","SP")>] ObjectPathStaticProperty(context: ClientRuntimeContext, typeId: string, propertyName: string) =
        inherit ObjectPath()


    and [<AllowNullLiteral>] [<Import("ObjectPathMethod","SP")>] ObjectPathMethod(context: ClientRuntimeContext, parent: ObjectPath, methodName: string, parameters: ResizeArray<obj>) =
        inherit ObjectPath()


    and [<AllowNullLiteral>] [<Import("ObjectPathStaticMethod","SP")>] ObjectPathStaticMethod(context: ClientRuntimeContext, typeId: string, methodName: string, parameters: ResizeArray<obj>) =
        inherit ObjectPath()


    and [<AllowNullLiteral>] [<Import("ObjectPathConstructor","SP")>] ObjectPathConstructor(context: ClientRuntimeContext, typeId: string, parameters: ResizeArray<obj>) =
        inherit ObjectPath()


    and [<AllowNullLiteral>] [<Import("SerializationContext","SP")>] SerializationContext() =
        member __.addClientObject(obj: ClientObject): unit = jsNative
        member __.addObjectPath(path: ObjectPath): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ResourceStrings","SP")>] ResourceStrings() =
        member __.argumentExceptionMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.argumentNullExceptionMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_AppIconAlt with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_AppWebUrlNotSet with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_ArrowImageAlt with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_BackToSite with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_ErrorGettingThemeInfo with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_HelpLinkToolTip with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_HostSiteUrlNotSet with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_InvalidArgument with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_InvalidJSON with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_InvalidOperation with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_PlaceHolderElementNotFound with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_RequiredScriptNotLoaded with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_SendFeedback with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_SettingsLinkToolTip with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_TimeoutGettingThemeInfo with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_Welcome with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cannotFindContextWebServerRelativeUrl with get(): string = jsNative and set(v: string): unit = jsNative
        member __.collectionHasNotBeenInitialized with get(): string = jsNative and set(v: string): unit = jsNative
        member __.collectionModified with get(): string = jsNative and set(v: string): unit = jsNative
        member __.invalidUsageOfConditionalScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.invalidUsageOfConditionalScopeNowAllowedAction with get(): string = jsNative and set(v: string): unit = jsNative
        member __.invalidUsageOfExceptionHandlingScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.namedPropertyHasNotBeenInitialized with get(): string = jsNative and set(v: string): unit = jsNative
        member __.namedServerObjectIsNull with get(): string = jsNative and set(v: string): unit = jsNative
        member __.noObjectPathAssociatedWithObject with get(): string = jsNative and set(v: string): unit = jsNative
        member __.notSameClientContext with get(): string = jsNative and set(v: string): unit = jsNative
        member __.notSupportedQueryExpressionWithExpressionDetail with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameIdentity with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameMethod with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameType with get(): string = jsNative and set(v: string): unit = jsNative
        member __.propertyHasNotBeenInitialized with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_BrowserBinaryDataNotSupported with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_BrowserNotSupported with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_CannotAccessSite with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_CannotAccessSiteCancelled with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_CannotAccessSiteOpenWindowFailed with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_DismissOpenWindowMessageLinkText with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_DomainDoesNotMatch with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_FixitHelpMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_InvalidArgumentOrField with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_InvalidOperation with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_NoTrustedOrigins with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_OpenWindowButtonText with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_OpenWindowMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_RequestAbortedOrTimedout with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_RequestUnexpectedResponse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_RequestUnexpectedResponseWithContentTypeAndStatus with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestAbortedOrTimedOut with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestEmptyQueryName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestHasBeenExecuted with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnexpectedResponse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnexpectedResponseWithContentTypeAndStatus with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnexpectedResponseWithStatus with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnknownResponse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.serverObjectIsNull with get(): string = jsNative and set(v: string): unit = jsNative
        member __.unknownError with get(): string = jsNative and set(v: string): unit = jsNative
        member __.unknownResponseData with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RuntimeRes","SP")>] RuntimeRes() =
        member __.cC_PlaceHolderElementNotFound with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_CannotAccessSiteOpenWindowFailed with get(): string = jsNative and set(v: string): unit = jsNative
        member __.noObjectPathAssociatedWithObject with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_TimeoutGettingThemeInfo with get(): string = jsNative and set(v: string): unit = jsNative
        member __.unknownResponseData with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnexpectedResponseWithStatus with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameProperty with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnknownResponse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_RequestUnexpectedResponseWithContentTypeAndStatus with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_BrowserNotSupported with get(): string = jsNative and set(v: string): unit = jsNative
        member __.argumentExceptionMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.namedServerObjectIsNull with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameType with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnexpectedResponseWithContentTypeAndStatus with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_InvalidJSON with get(): string = jsNative and set(v: string): unit = jsNative
        member __.invalidUsageOfExceptionHandlingScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.serverObjectIsNull with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_AppWebUrlNotSet with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_OpenWindowMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.argumentNullExceptionMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_HelpLinkToolTip with get(): string = jsNative and set(v: string): unit = jsNative
        member __.propertyHasNotBeenInitialized with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_RequestAbortedOrTimedout with get(): string = jsNative and set(v: string): unit = jsNative
        member __.invalidUsageOfConditionalScope with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_ErrorGettingThemeInfo with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_DismissOpenWindowMessageLinkText with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_CannotAccessSiteCancelled with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameIdentity with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_HostSiteUrlNotSet with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_FixitHelpMessage with get(): string = jsNative and set(v: string): unit = jsNative
        member __.notSupportedQueryExpressionWithExpressionDetail with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_RequestUnexpectedResponse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_DomainDoesNotMatch with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_BackToSite with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_NoTrustedOrigins with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_InvalidOperation with get(): string = jsNative and set(v: string): unit = jsNative
        member __.collectionModified with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_Welcome with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_AppIconAlt with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_SendFeedback with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_ArrowImageAlt with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_InvalidOperation with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestAbortedOrTimedOut with get(): string = jsNative and set(v: string): unit = jsNative
        member __.invalidUsageOfConditionalScopeNowAllowedAction with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cannotFindContextWebServerRelativeUrl with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_OpenWindowButtonText with get(): string = jsNative and set(v: string): unit = jsNative
        member __.unknownError with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_InvalidArgument with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_InvalidArgumentOrField with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_SettingsLinkToolTip with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestEmptyQueryName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.cC_RequiredScriptNotLoaded with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_CannotAccessSite with get(): string = jsNative and set(v: string): unit = jsNative
        member __.notSameClientContext with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestUnexpectedResponse with get(): string = jsNative and set(v: string): unit = jsNative
        member __.rE_BrowserBinaryDataNotSupported with get(): string = jsNative and set(v: string): unit = jsNative
        member __.collectionHasNotBeenInitialized with get(): string = jsNative and set(v: string): unit = jsNative
        member __.namedPropertyHasNotBeenInitialized with get(): string = jsNative and set(v: string): unit = jsNative
        member __.requestHasBeenExecuted with get(): string = jsNative and set(v: string): unit = jsNative
        member __.objectNameMethod with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ParseJSONUtil","SP")>] ParseJSONUtil() =
        static member parseObjectFromJsonString(json: string): obj = jsNative
        static member validateJson(text: string): bool = jsNative

    and DateTimeKind =
        | unspecified = 0
        | utc = 1
        | local = 2

    and [<AllowNullLiteral>] [<Import("OfficeVersion","SP")>] OfficeVersion() =
        member __.majorBuildVersion with get(): float = jsNative and set(v: float): unit = jsNative
        member __.previousMajorBuildVersion with get(): float = jsNative and set(v: float): unit = jsNative
        member __.majorVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.previousVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.majorVersionDotZero with get(): string = jsNative and set(v: string): unit = jsNative
        member __.previousVersionDotZero with get(): string = jsNative and set(v: string): unit = jsNative
        member __.assemblyVersion with get(): string = jsNative and set(v: string): unit = jsNative
        member __.wssMajorVersion with get(): string = jsNative and set(v: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientRuntimeContext","SP")>] ClientRuntimeContext() = //serverRelativeUrlOrFullUrl: string
        //interface Sys.IDisposable
        member __.get_url(): string = jsNative
        member __.get_viaUrl(): string = jsNative
        member __.set_viaUrl(value: string): unit = jsNative
        member __.get_formDigestHandlingEnabled(): bool = jsNative
        member __.set_formDigestHandlingEnabled(value: bool): unit = jsNative
        member __.get_applicationName(): string = jsNative
        member __.set_applicationName(value: string): unit = jsNative
        member __.get_clientTag(): string = jsNative
        member __.set_clientTag(value: string): unit = jsNative
        //member __.get_webRequestExecutorFactory(): IWebRequestExecutorFactory = jsNative
        //member __.set_webRequestExecutorFactory(value: IWebRequestExecutorFactory): unit = jsNative
        member __.get_pendingRequest(): ClientRequest = jsNative
        member __.get_hasPendingRequest(): bool = jsNative
        member __.add_executingWebRequest(value: Func<obj, WebRequestEventArgs, unit>): unit = jsNative
        member __.remove_executingWebRequest(value: Func<obj, WebRequestEventArgs, unit>): unit = jsNative
        member __.add_requestSucceeded(value: Func<obj, ClientRequestSucceededEventArgs, unit>): unit = jsNative
        member __.remove_requestSucceeded(value: Func<obj, ClientRequestSucceededEventArgs, unit>): unit = jsNative
        member __.add_requestFailed(value: Func<obj, ClientRequestFailedEventArgs, unit>): unit = jsNative
        member __.remove_requestFailed(value: Func<obj, ClientRequestFailedEventArgs, unit>): unit = jsNative
        member __.add_beginningRequest(value: Func<obj, ClientRequestEventArgs, unit>): unit = jsNative
        member __.remove_beginningRequest(value: Func<obj, ClientRequestEventArgs, unit>): unit = jsNative
        member __.get_requestTimeout(): float = jsNative
        member __.set_requestTimeout(value: float): unit = jsNative
        member __.executeQueryAsync(succeededCallback: Func<obj, ClientRequestSucceededEventArgs, unit>, failedCallback: Func<obj, ClientRequestFailedEventArgs, unit>): unit = jsNative
        member __.executeQueryAsync(succeededCallback: Func<obj, ClientRequestSucceededEventArgs, unit>): unit = jsNative
        member __.executeQueryAsync(): unit = jsNative
        member __.get_staticObjects(): obj = jsNative
        member __.castTo(obj: ClientObject, ``type``: obj): ClientObject = jsNative
        member __.addQuery(query: ClientAction): unit = jsNative
        member __.addQueryIdAndResultObject(id: float, obj: obj): unit = jsNative
        member __.parseObjectFromJsonString(json: string): obj = jsNative
        member __.parseObjectFromJsonString(json: string, skipTypeFixup: bool): obj = jsNative
        member __.load(clientObject: ClientObject): unit = jsNative
        member __.loadQuery(clientObjectCollection: ClientObjectCollection<'T>, exp: string): obj = jsNative
        member __.load(clientObject: ClientObject, [<ParamArray>] exps: string[]): unit = jsNative
        member __.loadQuery(clientObjectCollection: ClientObjectCollection<'T>): obj = jsNative
        member __.get_serverSchemaVersion(): string = jsNative
        member __.get_serverLibraryVersion(): string = jsNative
        member __.get_traceCorrelationId(): string = jsNative
        member __.set_traceCorrelationId(value: string): unit = jsNative
        member __.dispose(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ClientContext","SP")>] ClientContext() =
        inherit ClientRuntimeContext()
        static member get_current(): ClientContext = jsNative
        member __.get_web(): Web = jsNative
        member __.get_site(): Site = jsNative
        member __.get_serverVersion(): string = jsNative

    and ULSTraceLevel =
        | verbose = 0

    and [<AllowNullLiteral>] [<Import("ULS","SP")>] ULS() =
        static member get_enabled(): bool = jsNative
        static member set_enabled(value: bool): unit = jsNative
        static member log(debugMessage: string): unit = jsNative
        static member increaseIndent(): unit = jsNative
        static member decreaseIndent(): unit = jsNative
        static member traceApiEnter(functionName: string, args: ResizeArray<obj>): unit = jsNative
        static member traceApiEnter(functionName: string): unit = jsNative
        static member traceApiLeave(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("AccessRequests","SP")>] AccessRequests() =
        static member changeRequestStatus(context: ClientRuntimeContext, itemId: float, newStatus: float, convStr: string, permType: string, permissionLevel: float): unit = jsNative
        static member changeRequestStatusBulk(context: ClientRuntimeContext, requestIds: ResizeArray<float>, newStatus: float): unit = jsNative

    and AddFieldOptions =
        | defaultValue = 0
        | addToDefaultContentType = 1
        | addToNoContentType = 2
        | addToAllContentTypes = 3
        | addFieldInternalNameHint = 4
        | addFieldToDefaultView = 5
        | addFieldCheckDisplayName = 6

    and [<AllowNullLiteral>] [<Import("AlternateUrl","SP")>] AlternateUrl() =
        inherit ClientObject()
        member __.get_uri(): string = jsNative
        member __.get_urlZone(): UrlZone = jsNative

    and [<AllowNullLiteral>] [<Import("App","SP")>] App() =
        inherit ClientObject()
        member __.get_assetId(): string = jsNative
        member __.get_contentMarket(): string = jsNative
        member __.get_versionString(): string = jsNative

    and [<AllowNullLiteral>] [<Import("AppCatalog","SP")>] AppCatalog() =
        static member getAppInstances(context: ClientRuntimeContext, web: Web): ClientObjectList<AppInstance> = jsNative
        static member getDeveloperSiteAppInstancesByIds(context: ClientRuntimeContext, site: Site, appInstanceIds: ResizeArray<Guid>): ClientObjectList<AppInstance> = jsNative
        static member isAppSideloadingEnabled(context: ClientRuntimeContext): BooleanResult = jsNative

    and [<AllowNullLiteral>] [<Import("AppContextSite","SP")>] AppContextSite(context: ClientRuntimeContext, siteUrl: string) =
        inherit ClientObject()
        member __.get_site(): Site = jsNative
        member __.get_web(): Web = jsNative
        static member newObject(context: ClientRuntimeContext, siteUrl: string): AppContextSite = jsNative

    and [<AllowNullLiteral>] [<Import("AppInstance","SP")>] AppInstance() =
        inherit ClientObject()
        member __.get_appPrincipalId(): string = jsNative
        member __.get_appWebFullUrl(): string = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_inError(): bool = jsNative
        member __.get_startPage(): string = jsNative
        member __.get_remoteAppUrl(): string = jsNative
        member __.get_settingsPageUrl(): string = jsNative
        member __.get_siteId(): Guid = jsNative
        member __.get_status(): AppInstanceStatus = jsNative
        member __.get_title(): string = jsNative
        member __.get_webId(): Guid = jsNative
        member __.getErrorDetails(): ClientObjectList<AppInstanceErrorDetails> = jsNative
        member __.uninstall(): GuidResult = jsNative
        member __.upgrade(appPackageStream: Base64EncodedByteArray): unit = jsNative
        member __.cancelAllJobs(): BooleanResult = jsNative
        member __.install(): GuidResult = jsNative
        member __.getPreviousAppVersion(): App = jsNative
        member __.retryAllJobs(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("AppInstanceErrorDetails","SP")>] AppInstanceErrorDetails() =
        inherit ClientObject()
        member __.get_correlationId(): Guid = jsNative
        member __.set_correlationId(value: Guid): unit = jsNative
        member __.get_errorDetail(): string = jsNative
        member __.get_errorType(): AppInstanceErrorType = jsNative
        member __.set_errorType(value: AppInstanceErrorType): unit = jsNative
        member __.get_errorTypeName(): string = jsNative
        member __.get_exceptionMessage(): string = jsNative
        member __.get_source(): AppInstanceErrorSource = jsNative
        member __.set_source(value: AppInstanceErrorSource): unit = jsNative
        member __.get_sourceName(): string = jsNative

    and AppInstanceErrorSource =
        | common = 0
        | appWeb = 1
        | parentWeb = 2
        | remoteWebSite = 3
        | database = 4
        | officeExtension = 5
        | eventCallouts = 6
        | finalization = 7

    and AppInstanceErrorType =
        | transient = 0
        | configuration = 1
        | app = 2

    and AppInstanceStatus =
        | invalidStatus = 0
        | installing = 1
        | canceling = 2
        | uninstalling = 3
        | installed = 4
        | upgrading = 5
        | initialized = 6
        | upgradeCanceling = 7
        | disabling = 8
        | disabled = 9

    and [<AllowNullLiteral>] [<Import("AppLicense","SP")>] AppLicense() =
        inherit ClientValueObject()
        member __.get_rawXMLLicenseToken(): string = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("AppLicenseCollection","SP")>] AppLicenseCollection() =
        inherit ClientValueObjectCollection<AppLicense>()
        member __.add(item: AppLicense): unit = jsNative
        member __.get_item(index: float): AppLicense = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and AppLicenseType =
        | perpetualMultiUser = 0
        | perpetualAllUsers = 1
        | trialMultiUser = 2
        | trialAllUsers = 3

    and [<AllowNullLiteral>] [<Import("Attachment","SP")>] Attachment() =
        inherit ClientObject()
        member __.get_fileName(): string = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("AttachmentCollection","SP")>] AttachmentCollection() =
        inherit ClientObjectCollection<Attachment>()
        member __.itemAt(index: float): Attachment = jsNative
        member __.get_item(index: float): Attachment = jsNative
        member __.getByFileName(fileName: string): Attachment = jsNative

    and [<AllowNullLiteral>] [<Import("AttachmentCreationInformation","SP")>] AttachmentCreationInformation() =
        inherit ClientValueObject()
        member __.get_contentStream(): Base64EncodedByteArray = jsNative
        member __.set_contentStream(value: Base64EncodedByteArray): unit = jsNative
        member __.get_fileName(): string = jsNative
        member __.set_fileName(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("BasePermissions","SP")>] BasePermissions() =
        inherit ClientValueObject()
        member __.set(perm: PermissionKind): unit = jsNative
        member __.clear(perm: PermissionKind): unit = jsNative
        member __.clearAll(): unit = jsNative
        member __.has(perm: PermissionKind): bool = jsNative
        member __.equals(perm: BasePermissions): bool = jsNative
        member __.hasPermissions(high: float, low: float): bool = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and BaseType =
        | none = 0
        | genericList = 1
        | documentLibrary = 2
        | unused = 3
        | discussionBoard = 4
        | survey = 5
        | issue = 6

    and BrowserFileHandling =
        | permissive = 0
        | strict = 1

    and CalendarType =
        | none = 0
        | gregorian = 1
        | japan = 2
        | taiwan = 3
        | korea = 4
        | hijri = 5
        | thai = 6
        | hebrew = 7
        | gregorianMEFrench = 8
        | gregorianArabic = 9
        | gregorianXLITEnglish = 10
        | gregorianXLITFrench = 11
        | koreaJapanLunar = 12
        | chineseLunar = 13
        | sakaEra = 14
        | umAlQura = 15

    and [<AllowNullLiteral>] [<Import("CamlQuery","SP")>] CamlQuery() =
        inherit ClientValueObject()
        static member createAllItemsQuery(): CamlQuery = jsNative
        static member createAllFoldersQuery(): CamlQuery = jsNative
        member __.get_datesInUtc(): bool = jsNative
        member __.set_datesInUtc(value: bool): unit = jsNative
        member __.get_folderServerRelativeUrl(): string = jsNative
        member __.set_folderServerRelativeUrl(value: string): unit = jsNative
        member __.get_listItemCollectionPosition(): ListItemCollectionPosition = jsNative
        member __.set_listItemCollectionPosition(value: ListItemCollectionPosition): unit = jsNative
        member __.get_viewXml(): string = jsNative
        member __.set_viewXml(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Change","SP")>] Change() =
        inherit ClientObject()
        member __.get_changeToken(): ChangeToken = jsNative
        member __.get_changeType(): ChangeType = jsNative
        member __.get_siteId(): Guid = jsNative
        member __.get_time(): DateTime = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeAlert","SP")>] ChangeAlert() =
        inherit Change()
        member __.get_alertId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeCollection","SP")>] ChangeCollection() =
        inherit ClientObjectCollection<Change>()
        member __.itemAt(index: float): Change = jsNative
        member __.get_item(index: float): Change = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeContentType","SP")>] ChangeContentType() =
        inherit Change()
        member __.get_contentTypeId(): ContentTypeId = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeField","SP")>] ChangeField() =
        inherit Change()
        member __.get_fieldId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeFile","SP")>] ChangeFile() =
        inherit Change()
        member __.get_uniqueId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeFolder","SP")>] ChangeFolder() =
        inherit Change()
        member __.get_uniqueId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeGroup","SP")>] ChangeGroup() =
        inherit Change()
        member __.get_groupId(): float = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeItem","SP")>] ChangeItem() =
        inherit Change()
        member __.get_itemId(): float = jsNative
        member __.get_listId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeList","SP")>] ChangeList() =
        inherit Change()
        member __.get_listId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeLogItemQuery","SP")>] ChangeLogItemQuery() =
        inherit ClientValueObject()
        member __.get_changeToken(): string = jsNative
        member __.set_changeToken(value: string): unit = jsNative
        member __.get_contains(): string = jsNative
        member __.set_contains(value: string): unit = jsNative
        member __.get_query(): string = jsNative
        member __.set_query(value: string): unit = jsNative
        member __.get_queryOptions(): string = jsNative
        member __.set_queryOptions(value: string): unit = jsNative
        member __.get_rowLimit(): string = jsNative
        member __.set_rowLimit(value: string): unit = jsNative
        member __.get_viewFields(): string = jsNative
        member __.set_viewFields(value: string): unit = jsNative
        member __.get_viewName(): string = jsNative
        member __.set_viewName(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeQuery","SP")>] ChangeQuery(allChangeObjectTypes: bool, allChangeTypes: bool) =
        inherit ClientValueObject()
        member __.get_add(): bool = jsNative
        member __.set_add(value: bool): unit = jsNative
        member __.get_alert(): bool = jsNative
        member __.set_alert(value: bool): unit = jsNative
        member __.get_changeTokenEnd(): ChangeToken = jsNative
        member __.set_changeTokenEnd(value: ChangeToken): unit = jsNative
        member __.get_changeTokenStart(): ChangeToken = jsNative
        member __.set_changeTokenStart(value: ChangeToken): unit = jsNative
        member __.get_contentType(): bool = jsNative
        member __.set_contentType(value: bool): unit = jsNative
        member __.get_deleteObject(): bool = jsNative
        member __.set_deleteObject(value: bool): unit = jsNative
        member __.get_field(): bool = jsNative
        member __.set_field(value: bool): unit = jsNative
        member __.get_file(): bool = jsNative
        member __.set_file(value: bool): unit = jsNative
        member __.get_folder(): bool = jsNative
        member __.set_folder(value: bool): unit = jsNative
        member __.get_group(): bool = jsNative
        member __.set_group(value: bool): unit = jsNative
        member __.get_groupMembershipAdd(): bool = jsNative
        member __.set_groupMembershipAdd(value: bool): unit = jsNative
        member __.get_groupMembershipDelete(): bool = jsNative
        member __.set_groupMembershipDelete(value: bool): unit = jsNative
        member __.get_item(): bool = jsNative
        member __.set_item(value: bool): unit = jsNative
        member __.get_list(): bool = jsNative
        member __.set_list(value: bool): unit = jsNative
        member __.get_move(): bool = jsNative
        member __.set_move(value: bool): unit = jsNative
        member __.get_navigation(): bool = jsNative
        member __.set_navigation(value: bool): unit = jsNative
        member __.get_rename(): bool = jsNative
        member __.set_rename(value: bool): unit = jsNative
        member __.get_restore(): bool = jsNative
        member __.set_restore(value: bool): unit = jsNative
        member __.get_roleAssignmentAdd(): bool = jsNative
        member __.set_roleAssignmentAdd(value: bool): unit = jsNative
        member __.get_roleAssignmentDelete(): bool = jsNative
        member __.set_roleAssignmentDelete(value: bool): unit = jsNative
        member __.get_roleDefinitionAdd(): bool = jsNative
        member __.set_roleDefinitionAdd(value: bool): unit = jsNative
        member __.get_roleDefinitionDelete(): bool = jsNative
        member __.set_roleDefinitionDelete(value: bool): unit = jsNative
        member __.get_roleDefinitionUpdate(): bool = jsNative
        member __.set_roleDefinitionUpdate(value: bool): unit = jsNative
        member __.get_securityPolicy(): bool = jsNative
        member __.set_securityPolicy(value: bool): unit = jsNative
        member __.get_site(): bool = jsNative
        member __.set_site(value: bool): unit = jsNative
        member __.get_systemUpdate(): bool = jsNative
        member __.set_systemUpdate(value: bool): unit = jsNative
        member __.get_update(): bool = jsNative
        member __.set_update(value: bool): unit = jsNative
        member __.get_user(): bool = jsNative
        member __.set_user(value: bool): unit = jsNative
        member __.get_view(): bool = jsNative
        member __.set_view(value: bool): unit = jsNative
        member __.get_web(): bool = jsNative
        member __.set_web(value: bool): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeSite","SP")>] ChangeSite() =
        inherit Change()


    and [<AllowNullLiteral>] [<Import("ChangeToken","SP")>] ChangeToken() =
        inherit ClientValueObject()
        member __.get_stringValue(): string = jsNative
        member __.set_stringValue(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and ChangeType =
        | noChange = 0
        | add = 1
        | update = 2
        | deleteObject = 3
        | rename = 4
        | moveAway = 5
        | moveInto = 6
        | restore = 7
        | roleAdd = 8
        | roleDelete = 9
        | roleUpdate = 10
        | assignmentAdd = 11
        | assignmentDelete = 12
        | memberAdd = 13
        | memberDelete = 14
        | systemUpdate = 15
        | navigation = 16
        | scopeAdd = 17
        | scopeDelete = 18
        | listContentTypeAdd = 19
        | listContentTypeDelete = 20

    and [<AllowNullLiteral>] [<Import("ChangeUser","SP")>] ChangeUser() =
        inherit Change()
        member __.get_activate(): bool = jsNative
        member __.get_userId(): float = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeView","SP")>] ChangeView() =
        inherit Change()
        member __.get_viewId(): Guid = jsNative
        member __.get_listId(): Guid = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("ChangeWeb","SP")>] ChangeWeb() =
        inherit Change()
        member __.get_webId(): Guid = jsNative

    and CheckinType =
        | minorCheckIn = 0
        | majorCheckIn = 1
        | overwriteCheckIn = 2

    and CheckOutType =
        | online = 0
        | offline = 1
        | none = 2

    and ChoiceFormatType =
        | dropdown = 0
        | radioButtons = 1

    and [<AllowNullLiteral>] [<Import("CompatibilityRange","SP")>] CompatibilityRange() =
        inherit ClientObject()


    and [<AllowNullLiteral>] [<Import("ContentType","SP")>] ContentType() =
        inherit ClientObject()
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_displayFormTemplateName(): string = jsNative
        member __.set_displayFormTemplateName(value: string): unit = jsNative
        member __.get_displayFormUrl(): string = jsNative
        member __.set_displayFormUrl(value: string): unit = jsNative
        member __.get_documentTemplate(): string = jsNative
        member __.set_documentTemplate(value: string): unit = jsNative
        member __.get_documentTemplateUrl(): string = jsNative
        member __.get_editFormTemplateName(): string = jsNative
        member __.set_editFormTemplateName(value: string): unit = jsNative
        member __.get_editFormUrl(): string = jsNative
        member __.set_editFormUrl(value: string): unit = jsNative
        member __.get_fieldLinks(): FieldLinkCollection = jsNative
        member __.get_fields(): FieldCollection = jsNative
        member __.get_group(): string = jsNative
        member __.set_group(value: string): unit = jsNative
        member __.get_hidden(): bool = jsNative
        member __.set_hidden(value: bool): unit = jsNative
        member __.get_id(): ContentTypeId = jsNative
        member __.get_jsLink(): string = jsNative
        member __.set_jsLink(value: string): unit = jsNative
        member __.get_name(): string = jsNative
        member __.set_name(value: string): unit = jsNative
        member __.get_newFormTemplateName(): string = jsNative
        member __.set_newFormTemplateName(value: string): unit = jsNative
        member __.get_newFormUrl(): string = jsNative
        member __.set_newFormUrl(value: string): unit = jsNative
        member __.get_parent(): ContentType = jsNative
        member __.get_readOnly(): bool = jsNative
        member __.set_readOnly(value: bool): unit = jsNative
        member __.get_schemaXml(): string = jsNative
        member __.get_schemaXmlWithResourceTokens(): string = jsNative
        member __.set_schemaXmlWithResourceTokens(value: string): unit = jsNative
        member __.get_scope(): string = jsNative
        member __.get_sealed(): bool = jsNative
        member __.set_sealed(value: bool): unit = jsNative
        member __.get_stringId(): string = jsNative
        //member __.get_workflowAssociations(): WorkflowAssociationCollection = jsNative
        member __.update(updateChildren: bool): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ContentTypeCollection","SP")>] ContentTypeCollection() =
        inherit ClientObjectCollection<ContentType>()
        member __.itemAt(index: float): ContentType = jsNative
        member __.get_item(index: float): ContentType = jsNative
        member __.getById(contentTypeId: string): ContentType = jsNative
        member __.addExistingContentType(contentType: ContentType): ContentType = jsNative
        member __.add(parameters: ContentTypeCreationInformation): ContentType = jsNative

    and [<AllowNullLiteral>] [<Import("ContentTypeCreationInformation","SP")>] ContentTypeCreationInformation() =
        inherit ClientValueObject()
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_group(): string = jsNative
        member __.set_group(value: string): unit = jsNative
        member __.get_name(): string = jsNative
        member __.set_name(value: string): unit = jsNative
        member __.get_parentContentType(): ContentType = jsNative
        member __.set_parentContentType(value: ContentType): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ContentTypeId","SP")>] ContentTypeId() =
        inherit ClientValueObject()
        member __.toString(): string = jsNative
        member __.get_stringValue(): string = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and CustomizedPageStatus =
        | none = 0
        | uncustomized = 1
        | customized = 2

    and DateTimeFieldFormatType =
        | dateOnly = 0
        | dateTime = 1

    and DateTimeFieldFriendlyFormatType =
        | unspecified = 0
        | disabled = 1
        | relative = 2

    and DraftVisibilityType =
        | reader = 0
        | author = 1
        | approver = 2

    and [<AllowNullLiteral>] [<Import("EventReceiverDefinition","SP")>] EventReceiverDefinition() =
        inherit ClientObject()
        member __.get_receiverAssembly(): string = jsNative
        member __.get_receiverClass(): string = jsNative
        member __.get_receiverId(): Guid = jsNative
        member __.get_receiverName(): string = jsNative
        member __.get_sequenceNumber(): float = jsNative
        member __.get_synchronization(): EventReceiverSynchronization = jsNative
        member __.get_eventType(): EventReceiverType = jsNative
        member __.get_receiverUrl(): string = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("EventReceiverDefinitionCollection","SP")>] EventReceiverDefinitionCollection() =
        inherit ClientObjectCollection<EventReceiverDefinition>()
        member __.itemAt(index: float): EventReceiverDefinition = jsNative
        member __.get_item(index: float): EventReceiverDefinition = jsNative
        member __.getById(eventReceiverId: Guid): EventReceiverDefinition = jsNative
        member __.add(eventReceiverCreationInformation: EventReceiverDefinitionCreationInformation): EventReceiverDefinition = jsNative

    and [<AllowNullLiteral>] [<Import("EventReceiverDefinitionCreationInformation","SP")>] EventReceiverDefinitionCreationInformation() =
        inherit ClientValueObject()
        member __.get_receiverAssembly(): string = jsNative
        member __.set_receiverAssembly(value: string): unit = jsNative
        member __.get_receiverClass(): string = jsNative
        member __.set_receiverClass(value: string): unit = jsNative
        member __.get_receiverName(): string = jsNative
        member __.set_receiverName(value: string): unit = jsNative
        member __.get_sequenceNumber(): float = jsNative
        member __.set_sequenceNumber(value: float): unit = jsNative
        member __.get_synchronization(): EventReceiverSynchronization = jsNative
        member __.set_synchronization(value: EventReceiverSynchronization): unit = jsNative
        member __.get_eventType(): EventReceiverType = jsNative
        member __.set_eventType(value: EventReceiverType): unit = jsNative
        member __.get_receiverUrl(): string = jsNative
        member __.set_receiverUrl(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and EventReceiverSynchronization =
        | defaultSynchronization = 0
        | synchronous = 1
        | asynchronous = 2

    and EventReceiverType =
        | invalidReceiver = 0
        | itemAdding = 1
        | itemUpdating = 2
        | itemDeleting = 3
        | itemCheckingIn = 4
        | itemCheckingOut = 5
        | itemUncheckingOut = 6
        | itemAttachmentAdding = 7
        | itemAttachmentDeleting = 8
        | itemFileMoving = 9
        | itemVersionDeleting = 10
        | fieldAdding = 11
        | fieldUpdating = 12
        | fieldDeleting = 13
        | listAdding = 14
        | listDeleting = 15
        | siteDeleting = 16
        | webDeleting = 17
        | webMoving = 18
        | webAdding = 19
        | groupAdding = 20
        | groupUpdating = 21
        | groupDeleting = 22
        | groupUserAdding = 23
        | groupUserDeleting = 24
        | roleDefinitionAdding = 25
        | roleDefinitionUpdating = 26
        | roleDefinitionDeleting = 27
        | roleAssignmentAdding = 28
        | roleAssignmentDeleting = 29
        | inheritanceBreaking = 30
        | inheritanceResetting = 31
        | workflowStarting = 32
        | itemAdded = 33
        | itemUpdated = 34
        | itemDeleted = 35
        | itemCheckedIn = 36
        | itemCheckedOut = 37
        | itemUncheckedOut = 38
        | itemAttachmentAdded = 39
        | itemAttachmentDeleted = 40
        | itemFileMoved = 41
        | itemFileConverted = 42
        | itemVersionDeleted = 43
        | fieldAdded = 44
        | fieldUpdated = 45
        | fieldDeleted = 46
        | listAdded = 47
        | listDeleted = 48
        | siteDeleted = 49
        | webDeleted = 50
        | webMoved = 51
        | webProvisioned = 52
        | groupAdded = 53
        | groupUpdated = 54
        | groupDeleted = 55
        | groupUserAdded = 56
        | groupUserDeleted = 57
        | roleDefinitionAdded = 58
        | roleDefinitionUpdated = 59
        | roleDefinitionDeleted = 60
        | roleAssignmentAdded = 61
        | roleAssignmentDeleted = 62
        | inheritanceBroken = 63
        | inheritanceReset = 64
        | workflowStarted = 65
        | workflowPostponed = 66
        | workflowCompleted = 67
        | entityInstanceAdded = 68
        | entityInstanceUpdated = 69
        | entityInstanceDeleted = 70
        | appInstalled = 71
        | appUpgraded = 72
        | appUninstalling = 73
        | emailReceived = 74
        | contextEvent = 75

    and [<AllowNullLiteral>] [<Import("Feature","SP")>] Feature() =
        inherit ClientObject()
        member __.get_definitionId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("FeatureCollection","SP")>] FeatureCollection() =
        inherit ClientObjectCollection<Feature>()
        member __.itemAt(index: float): Feature = jsNative
        member __.get_item(index: float): Feature = jsNative
        member __.getById(featureId: Guid): Feature = jsNative
        member __.add(featureId: Guid, force: bool, featdefScope: FeatureDefinitionScope): Feature = jsNative
        member __.remove(featureId: Guid, force: bool): unit = jsNative

    and FeatureDefinitionScope =
        | none = 0
        | farm = 1
        | site = 2
        | web = 3

    and [<AllowNullLiteral>] [<Import("Field","SP")>] Field() =
        inherit ClientObject()
        member __.get_canBeDeleted(): bool = jsNative
        member __.get_defaultValue(): string = jsNative
        member __.set_defaultValue(value: string): unit = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_direction(): string = jsNative
        member __.set_direction(value: string): unit = jsNative
        member __.get_enforceUniqueValues(): bool = jsNative
        member __.set_enforceUniqueValues(value: bool): unit = jsNative
        member __.get_entityPropertyName(): string = jsNative
        member __.get_filterable(): bool = jsNative
        member __.get_fromBaseType(): bool = jsNative
        member __.get_group(): string = jsNative
        member __.set_group(value: string): unit = jsNative
        member __.get_hidden(): bool = jsNative
        member __.set_hidden(value: bool): unit = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_indexed(): bool = jsNative
        member __.set_indexed(value: bool): unit = jsNative
        member __.get_internalName(): string = jsNative
        member __.get_jsLink(): string = jsNative
        member __.set_jsLink(value: string): unit = jsNative
        member __.get_readOnlyField(): bool = jsNative
        member __.set_readOnlyField(value: bool): unit = jsNative
        member __.get_required(): bool = jsNative
        member __.set_required(value: bool): unit = jsNative
        member __.get_schemaXml(): string = jsNative
        member __.set_schemaXml(value: string): unit = jsNative
        member __.get_schemaXmlWithResourceTokens(): string = jsNative
        member __.get_scope(): string = jsNative
        member __.get_sealed(): bool = jsNative
        member __.get_sortable(): bool = jsNative
        member __.get_staticName(): string = jsNative
        member __.set_staticName(value: string): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_fieldTypeKind(): FieldType = jsNative
        member __.set_fieldTypeKind(value: FieldType): unit = jsNative
        member __.get_typeAsString(): string = jsNative
        member __.set_typeAsString(value: string): unit = jsNative
        member __.get_typeDisplayName(): string = jsNative
        member __.get_typeShortDescription(): string = jsNative
        member __.get_validationFormula(): string = jsNative
        member __.set_validationFormula(value: string): unit = jsNative
        member __.get_validationMessage(): string = jsNative
        member __.set_validationMessage(value: string): unit = jsNative
        member __.validateSetValue(item: ListItem, value: string): unit = jsNative
        member __.updateAndPushChanges(pushChangesToLists: bool): unit = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative
        member __.setShowInDisplayForm(value: bool): unit = jsNative
        member __.setShowInEditForm(value: bool): unit = jsNative
        member __.setShowInNewForm(value: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldCalculated","SP")>] FieldCalculated() =
        inherit Field()
        member __.get_dateFormat(): DateTimeFieldFormatType = jsNative
        member __.set_dateFormat(value: DateTimeFieldFormatType): unit = jsNative
        member __.get_formula(): string = jsNative
        member __.set_formula(value: string): unit = jsNative
        member __.get_outputType(): FieldType = jsNative
        member __.set_outputType(value: FieldType): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldCalculatedErrorValue","SP")>] FieldCalculatedErrorValue() =
        inherit ClientValueObject()
        member __.get_errorMessage(): string = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldMultiChoice","SP")>] FieldMultiChoice() =
        inherit Field()
        member __.get_fillInChoice(): bool = jsNative
        member __.set_fillInChoice(value: bool): unit = jsNative
        member __.get_mappings(): string = jsNative
        member __.get_choices(): ResizeArray<string> = jsNative
        member __.set_choices(value: ResizeArray<string>): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldChoice","SP")>] FieldChoice() =
        inherit FieldMultiChoice()
        member __.get_editFormat(): ChoiceFormatType = jsNative
        member __.set_editFormat(value: ChoiceFormatType): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldCollection","SP")>] FieldCollection() =
        inherit ClientObjectCollection<Field>()
        member __.itemAt(index: float): Field = jsNative
        member __.get_item(index: float): Field = jsNative
        member __.get_schemaXml(): string = jsNative
        member __.getByTitle(title: string): Field = jsNative
        member __.getById(id: Guid): Field = jsNative
        member __.add(field: Field): Field = jsNative
        member __.addDependentLookup(displayName: string, primaryLookupField: Field, lookupField: string): Field = jsNative
        member __.addFieldAsXml(schemaXml: string, addToDefaultView: bool, options: AddFieldOptions): Field = jsNative
        member __.getByInternalNameOrTitle(strName: string): Field = jsNative

    and [<AllowNullLiteral>] [<Import("FieldComputed","SP")>] FieldComputed() =
        inherit Field()
        member __.get_enableLookup(): bool = jsNative
        member __.set_enableLookup(value: bool): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldNumber","SP")>] FieldNumber() =
        inherit Field()
        member __.get_maximumValue(): float = jsNative
        member __.set_maximumValue(value: float): unit = jsNative
        member __.get_minimumValue(): float = jsNative
        member __.set_minimumValue(value: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldCurrency","SP")>] FieldCurrency() =
        inherit FieldNumber()
        member __.get_currencyLocaleId(): float = jsNative
        member __.set_currencyLocaleId(value: float): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldDateTime","SP")>] FieldDateTime() =
        inherit Field()
        member __.get_dateTimeCalendarType(): CalendarType = jsNative
        member __.set_dateTimeCalendarType(value: CalendarType): unit = jsNative
        member __.get_displayFormat(): DateTimeFieldFormatType = jsNative
        member __.set_displayFormat(value: DateTimeFieldFormatType): unit = jsNative
        member __.get_friendlyDisplayFormat(): DateTimeFieldFriendlyFormatType = jsNative
        member __.set_friendlyDisplayFormat(value: DateTimeFieldFriendlyFormatType): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldGeolocation","SP")>] FieldGeolocation() =
        inherit Field()


    and [<AllowNullLiteral>] [<Import("FieldGeolocationValue","SP")>] FieldGeolocationValue() =
        inherit ClientValueObject()
        member __.get_altitude(): float = jsNative
        member __.set_altitude(value: float): unit = jsNative
        member __.get_latitude(): float = jsNative
        member __.set_latitude(value: float): unit = jsNative
        member __.get_longitude(): float = jsNative
        member __.set_longitude(value: float): unit = jsNative
        member __.get_measure(): float = jsNative
        member __.set_measure(value: float): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldGuid","SP")>] FieldGuid() =
        inherit Field()


    and [<AllowNullLiteral>] [<Import("FieldLink","SP")>] FieldLink() =
        inherit ClientObject()
        member __.get_hidden(): bool = jsNative
        member __.set_hidden(value: bool): unit = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_name(): string = jsNative
        member __.get_required(): bool = jsNative
        member __.set_required(value: bool): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldLinkCollection","SP")>] FieldLinkCollection() =
        inherit ClientObjectCollection<FieldLink>()
        member __.itemAt(index: float): FieldLink = jsNative
        member __.get_item(index: float): FieldLink = jsNative
        member __.getById(id: Guid): FieldLink = jsNative
        member __.add(parameters: FieldLinkCreationInformation): FieldLink = jsNative
        member __.reorder(internalNames: ResizeArray<string>): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldLinkCreationInformation","SP")>] FieldLinkCreationInformation() =
        inherit ClientValueObject()
        member __.get_field(): Field = jsNative
        member __.set_field(value: Field): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldLookup","SP")>] FieldLookup() =
        inherit Field()
        member __.get_allowMultipleValues(): bool = jsNative
        member __.set_allowMultipleValues(value: bool): unit = jsNative
        member __.get_isRelationship(): bool = jsNative
        member __.set_isRelationship(value: bool): unit = jsNative
        member __.get_lookupField(): string = jsNative
        member __.set_lookupField(value: string): unit = jsNative
        member __.get_lookupList(): string = jsNative
        member __.set_lookupList(value: string): unit = jsNative
        member __.get_lookupWebId(): Guid = jsNative
        member __.set_lookupWebId(value: Guid): unit = jsNative
        member __.get_primaryFieldId(): string = jsNative
        member __.set_primaryFieldId(value: string): unit = jsNative
        member __.get_relationshipDeleteBehavior(): RelationshipDeleteBehaviorType = jsNative
        member __.set_relationshipDeleteBehavior(value: RelationshipDeleteBehaviorType): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldLookupValue","SP")>] FieldLookupValue() =
        inherit ClientValueObject()
        member __.get_lookupId(): float = jsNative
        member __.set_lookupId(value: float): unit = jsNative
        member __.get_lookupValue(): string = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldMultiLineText","SP")>] FieldMultiLineText() =
        inherit Field()
        member __.get_allowHyperlink(): bool = jsNative
        member __.set_allowHyperlink(value: bool): unit = jsNative
        member __.get_appendOnly(): bool = jsNative
        member __.set_appendOnly(value: bool): unit = jsNative
        member __.get_numberOfLines(): float = jsNative
        member __.set_numberOfLines(value: float): unit = jsNative
        member __.get_restrictedMode(): bool = jsNative
        member __.set_restrictedMode(value: bool): unit = jsNative
        member __.get_richText(): bool = jsNative
        member __.set_richText(value: bool): unit = jsNative
        member __.get_wikiLinking(): bool = jsNative

    and [<AllowNullLiteral>] [<Import("FieldRatingScale","SP")>] FieldRatingScale() =
        inherit FieldMultiChoice()
        member __.get_gridEndNumber(): float = jsNative
        member __.set_gridEndNumber(value: float): unit = jsNative
        member __.get_gridNAOptionText(): string = jsNative
        member __.set_gridNAOptionText(value: string): unit = jsNative
        member __.get_gridStartNumber(): float = jsNative
        member __.set_gridStartNumber(value: float): unit = jsNative
        member __.get_gridTextRangeAverage(): string = jsNative
        member __.set_gridTextRangeAverage(value: string): unit = jsNative
        member __.get_gridTextRangeHigh(): string = jsNative
        member __.set_gridTextRangeHigh(value: string): unit = jsNative
        member __.get_gridTextRangeLow(): string = jsNative
        member __.set_gridTextRangeLow(value: string): unit = jsNative
        member __.get_rangeCount(): float = jsNative

    and [<AllowNullLiteral>] [<Import("FieldRatingScaleQuestionAnswer","SP")>] FieldRatingScaleQuestionAnswer() =
        inherit ClientValueObject()
        member __.get_answer(): float = jsNative
        member __.set_answer(value: float): unit = jsNative
        member __.get_question(): string = jsNative
        member __.set_question(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldStringValues","SP")>] FieldStringValues() =
        inherit ClientObject()
        member __.get_fieldValues(): obj = jsNative
        member __.get_item(fieldName: string): string = jsNative
        member __.refreshLoad(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldText","SP")>] FieldText() =
        inherit Field()
        member __.get_maxLength(): float = jsNative
        member __.set_maxLength(value: float): unit = jsNative

    and FieldType =
        | invalid = 0
        | integer = 1
        | text = 2
        | note = 3
        | dateTime = 4
        | counter = 5
        | choice = 6
        | lookup = 7
        | boolean = 8
        | number = 9
        | currency = 10
        | URL = 11
        | computed = 12
        | threading = 13
        | guid = 14
        | multiChoice = 15
        | gridChoice = 16
        | calculated = 17
        | file = 18
        | attachments = 19
        | user = 20
        | recurrence = 21
        | crossProjectLink = 22
        | modStat = 23
        | error = 24
        | contentTypeId = 25
        | pageSeparator = 26
        | threadIndex = 27
        | workflowStatus = 28
        | allDayEvent = 29
        | workflowEventType = 30
        | geolocation = 31
        | outcomeChoice = 32
        | maxItems = 33

    and [<AllowNullLiteral>] [<Import("FieldUrl","SP")>] FieldUrl() =
        inherit Field()
        member __.get_displayFormat(): UrlFieldFormatType = jsNative
        member __.set_displayFormat(value: UrlFieldFormatType): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldUrlValue","SP")>] FieldUrlValue() =
        inherit ClientValueObject()
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FieldUser","SP")>] FieldUser() =
        inherit FieldLookup()
        member __.get_allowDisplay(): bool = jsNative
        member __.set_allowDisplay(value: bool): unit = jsNative
        member __.get_presence(): bool = jsNative
        member __.set_presence(value: bool): unit = jsNative
        member __.get_selectionGroup(): float = jsNative
        member __.set_selectionGroup(value: float): unit = jsNative
        member __.get_selectionMode(): FieldUserSelectionMode = jsNative
        member __.set_selectionMode(value: FieldUserSelectionMode): unit = jsNative

    and FieldUserSelectionMode =
        | peopleOnly = 0
        | peopleAndGroups = 1

    and [<AllowNullLiteral>] [<Import("FieldUserValue","SP")>] FieldUserValue() =
        inherit FieldLookupValue()
        static member fromUser(userName: string): FieldUserValue = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("File","SP")>] File() =
        inherit ClientObject()
        member __.get_author(): User = jsNative
        member __.get_checkedOutByUser(): User = jsNative
        member __.get_checkInComment(): string = jsNative
        member __.get_checkOutType(): CheckOutType = jsNative
        member __.get_contentTag(): string = jsNative
        member __.get_customizedPageStatus(): CustomizedPageStatus = jsNative
        member __.get_eTag(): string = jsNative
        member __.get_exists(): bool = jsNative
        member __.get_length(): float = jsNative
        member __.get_level(): FileLevel = jsNative
        member __.get_listItemAllFields(): ListItem = jsNative
        member __.get_lockedByUser(): User = jsNative
        member __.get_majorVersion(): float = jsNative
        member __.get_minorVersion(): float = jsNative
        member __.get_modifiedBy(): User = jsNative
        member __.get_name(): string = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.get_timeCreated(): DateTime = jsNative
        member __.get_timeLastModified(): DateTime = jsNative
        member __.get_title(): string = jsNative
        member __.get_uIVersion(): float = jsNative
        member __.get_uIVersionLabel(): string = jsNative
        member __.get_versions(): FileVersionCollection = jsNative
        member __.undoCheckOut(): unit = jsNative
        member __.checkIn(comment: string, checkInType: CheckinType): unit = jsNative
        member __.publish(comment: string): unit = jsNative
        member __.unPublish(comment: string): unit = jsNative
        member __.approve(comment: string): unit = jsNative
        member __.deny(comment: string): unit = jsNative
        static member getContentVerFromTag(context: ClientRuntimeContext, contentTag: string): IntResult = jsNative
        //member __.getLimitedWebPartManager(scope: PersonalizationScope): LimitedWebPartManager = jsNative
        member __.moveTo(newUrl: string, flags: MoveOperations): unit = jsNative
        member __.copyTo(strNewUrl: string, bOverWrite: bool): unit = jsNative
        member __.saveBinary(parameters: FileSaveBinaryInformation): unit = jsNative
        member __.deleteObject(): unit = jsNative
        member __.recycle(): GuidResult = jsNative
        member __.checkOut(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FileCollection","SP")>] FileCollection() =
        inherit ClientObjectCollection<File>()
        member __.itemAt(index: float): File = jsNative
        member __.get_item(index: float): File = jsNative
        member __.getByUrl(url: string): File = jsNative
        member __.add(parameters: FileCreationInformation): File = jsNative
        member __.addTemplateFile(urlOfFile: string, templateFileType: TemplateFileType): File = jsNative

    and [<AllowNullLiteral>] [<Import("FileCreationInformation","SP")>] FileCreationInformation() =
        inherit ClientValueObject()
        member __.get_content(): Base64EncodedByteArray = jsNative
        member __.set_content(value: Base64EncodedByteArray): unit = jsNative
        member __.get_overwrite(): bool = jsNative
        member __.set_overwrite(value: bool): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and FileLevel =
        | published = 0
        | draft = 1
        | checkout = 2

    and [<AllowNullLiteral>] [<Import("FileSaveBinaryInformation","SP")>] FileSaveBinaryInformation() =
        inherit ClientValueObject()
        member __.get_checkRequiredFields(): bool = jsNative
        member __.set_checkRequiredFields(value: bool): unit = jsNative
        member __.get_content(): Base64EncodedByteArray = jsNative
        member __.set_content(value: Base64EncodedByteArray): unit = jsNative
        member __.get_eTag(): string = jsNative
        member __.set_eTag(value: string): unit = jsNative
        member __.get_fieldValues(): obj = jsNative
        member __.set_fieldValues(value: obj): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and FileSystemObjectType =
        | invalid = 0
        | file = 1
        | folder = 2
        | web = 3

    and [<AllowNullLiteral>] [<Import("FileVersion","SP")>] FileVersion() =
        inherit ClientObject()
        member __.get_checkInComment(): string = jsNative
        member __.get_created(): DateTime = jsNative
        member __.get_createdBy(): User = jsNative
        member __.get_iD(): float = jsNative
        member __.get_isCurrentVersion(): bool = jsNative
        member __.get_size(): float = jsNative
        member __.get_url(): string = jsNative
        member __.get_versionLabel(): string = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("FileVersionCollection","SP")>] FileVersionCollection() =
        inherit ClientObjectCollection<FileVersion>()
        member __.itemAt(index: float): FileVersion = jsNative
        member __.get_item(index: float): FileVersion = jsNative
        member __.getById(versionid: float): FileVersion = jsNative
        member __.deleteByID(vid: float): unit = jsNative
        member __.deleteByLabel(versionlabel: string): unit = jsNative
        member __.deleteAll(): unit = jsNative
        member __.restoreByLabel(versionlabel: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Folder","SP")>] Folder() =
        inherit ClientObject()
        member __.get_contentTypeOrder(): ResizeArray<ContentTypeId> = jsNative
        member __.get_files(): FileCollection = jsNative
        member __.get_listItemAllFields(): ListItem = jsNative
        member __.get_itemCount(): float = jsNative
        member __.get_name(): string = jsNative
        member __.get_parentFolder(): Folder = jsNative
        member __.get_properties(): PropertyValues = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.get_folders(): FolderCollection = jsNative
        member __.get_uniqueContentTypeOrder(): ResizeArray<ContentTypeId> = jsNative
        member __.set_uniqueContentTypeOrder(value: ResizeArray<ContentTypeId>): unit = jsNative
        member __.get_welcomePage(): string = jsNative
        member __.set_welcomePage(value: string): unit = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative
        member __.recycle(): GuidResult = jsNative

    and [<AllowNullLiteral>] [<Import("FolderCollection","SP")>] FolderCollection() =
        inherit ClientObjectCollection<Folder>()
        member __.itemAt(index: float): Folder = jsNative
        member __.get_item(index: float): Folder = jsNative
        member __.getByUrl(url: string): Folder = jsNative
        member __.add(url: string): Folder = jsNative

    and [<AllowNullLiteral>] [<Import("Form","SP")>] Form() =
        inherit ClientObject()
        member __.get_id(): Guid = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.get_formType(): PageType = jsNative

    and [<AllowNullLiteral>] [<Import("FormCollection","SP")>] FormCollection() =
        inherit ClientObjectCollection<Form>()
        member __.itemAt(index: float): Form = jsNative
        member __.get_item(index: float): Form = jsNative
        member __.getByPageType(formType: PageType): Form = jsNative
        member __.getById(id: Guid): Form = jsNative

    and [<AllowNullLiteral>] [<Import("Principal","SP")>] Principal() =
        inherit ClientObject()
        member __.get_id(): float = jsNative
        member __.get_isHiddenInUI(): bool = jsNative
        member __.get_loginName(): string = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        //member __.get_principalType(): PrincipalType = jsNative

    and [<AllowNullLiteral>] [<Import("Group","SP")>] Group() =
        inherit Principal()
        member __.get_allowMembersEditMembership(): bool = jsNative
        member __.set_allowMembersEditMembership(value: bool): unit = jsNative
        member __.get_allowRequestToJoinLeave(): bool = jsNative
        member __.set_allowRequestToJoinLeave(value: bool): unit = jsNative
        member __.get_autoAcceptRequestToJoinLeave(): bool = jsNative
        member __.set_autoAcceptRequestToJoinLeave(value: bool): unit = jsNative
        member __.get_canCurrentUserEditMembership(): bool = jsNative
        member __.get_canCurrentUserManageGroup(): bool = jsNative
        member __.get_canCurrentUserViewMembership(): bool = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_onlyAllowMembersViewMembership(): bool = jsNative
        member __.set_onlyAllowMembersViewMembership(value: bool): unit = jsNative
        member __.get_owner(): Principal = jsNative
        member __.set_owner(value: Principal): unit = jsNative
        member __.get_ownerTitle(): string = jsNative
        member __.get_requestToJoinLeaveEmailSetting(): string = jsNative
        member __.set_requestToJoinLeaveEmailSetting(value: string): unit = jsNative
        member __.get_users(): UserCollection = jsNative
        member __.update(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("GroupCollection","SP")>] GroupCollection() =
        inherit ClientObjectCollection<Group>()
        member __.itemAt(index: float): Group = jsNative
        member __.get_item(index: float): Group = jsNative
        member __.getByName(name: string): Group = jsNative
        member __.getById(id: float): Group = jsNative
        member __.add(parameters: GroupCreationInformation): Group = jsNative
        member __.removeByLoginName(loginName: string): unit = jsNative
        member __.removeById(id: float): unit = jsNative
        member __.remove(group: Group): unit = jsNative

    and [<AllowNullLiteral>] [<Import("GroupCreationInformation","SP")>] GroupCreationInformation() =
        inherit ClientValueObject()
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("InformationRightsManagementSettings","SP")>] InformationRightsManagementSettings() =
        inherit ClientObject()
        member __.get_allowPrint(): bool = jsNative
        member __.set_allowPrint(value: bool): unit = jsNative
        member __.get_allowScript(): bool = jsNative
        member __.set_allowScript(value: bool): unit = jsNative
        member __.get_allowWriteCopy(): bool = jsNative
        member __.set_allowWriteCopy(value: bool): unit = jsNative
        member __.get_disableDocumentBrowserView(): bool = jsNative
        member __.set_disableDocumentBrowserView(value: bool): unit = jsNative
        member __.get_documentAccessExpireDays(): float = jsNative
        member __.set_documentAccessExpireDays(value: float): unit = jsNative
        member __.get_documentLibraryProtectionExpireDate(): DateTime = jsNative
        member __.set_documentLibraryProtectionExpireDate(value: DateTime): unit = jsNative
        member __.get_enableDocumentAccessExpire(): bool = jsNative
        member __.set_enableDocumentAccessExpire(value: bool): unit = jsNative
        member __.get_enableDocumentBrowserPublishingView(): bool = jsNative
        member __.set_enableDocumentBrowserPublishingView(value: bool): unit = jsNative
        member __.get_enableGroupProtection(): bool = jsNative
        member __.set_enableGroupProtection(value: bool): unit = jsNative
        member __.get_enableLicenseCacheExpire(): bool = jsNative
        member __.set_enableLicenseCacheExpire(value: bool): unit = jsNative
        member __.get_groupName(): string = jsNative
        member __.set_groupName(value: string): unit = jsNative
        member __.get_licenseCacheExpireDays(): float = jsNative
        member __.set_licenseCacheExpireDays(value: float): unit = jsNative
        member __.get_policyDescription(): string = jsNative
        member __.set_policyDescription(value: string): unit = jsNative
        member __.get_policyTitle(): string = jsNative
        member __.set_policyTitle(value: string): unit = jsNative
        member __.reset(): unit = jsNative
        member __.update(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("Language","SP")>] Language() =
        inherit ClientValueObject()
        member __.get_displayName(): string = jsNative
        member __.get_languageTag(): string = jsNative
        member __.get_lcid(): float = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("SecurableObject","SP")>] SecurableObject() =
        inherit ClientObject()
        member __.get_firstUniqueAncestorSecurableObject(): SecurableObject = jsNative
        member __.get_hasUniqueRoleAssignments(): bool = jsNative
        member __.get_roleAssignments(): RoleAssignmentCollection = jsNative
        member __.resetRoleInheritance(): unit = jsNative
        member __.breakRoleInheritance(copyRoleAssignments: bool, clearSubscopes: bool): unit = jsNative

    and ControlMode =
        | invalid = 0
        | displayMode = 1
        | editMode = 2
        | newMode = 3

    and [<AllowNullLiteral>] [<Import("List","SP")>] List() =
        inherit SecurableObject()
        member __.getItemById(id: float): ListItem = jsNative
        member __.get_allowContentTypes(): bool = jsNative
        member __.get_baseTemplate(): float = jsNative
        member __.get_baseType(): BaseType = jsNative
        member __.get_browserFileHandling(): BrowserFileHandling = jsNative
        member __.get_contentTypes(): ContentTypeCollection = jsNative
        member __.get_contentTypesEnabled(): bool = jsNative
        member __.set_contentTypesEnabled(value: bool): unit = jsNative
        member __.get_created(): DateTime = jsNative
        member __.get_dataSource(): ListDataSource = jsNative
        member __.get_defaultContentApprovalWorkflowId(): Guid = jsNative
        member __.set_defaultContentApprovalWorkflowId(value: Guid): unit = jsNative
        member __.get_defaultDisplayFormUrl(): string = jsNative
        member __.set_defaultDisplayFormUrl(value: string): unit = jsNative
        member __.get_defaultEditFormUrl(): string = jsNative
        member __.set_defaultEditFormUrl(value: string): unit = jsNative
        member __.get_defaultNewFormUrl(): string = jsNative
        member __.set_defaultNewFormUrl(value: string): unit = jsNative
        member __.get_defaultView(): View = jsNative
        member __.get_defaultViewUrl(): string = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_direction(): string = jsNative
        member __.set_direction(value: string): unit = jsNative
        member __.get_documentTemplateUrl(): string = jsNative
        member __.set_documentTemplateUrl(value: string): unit = jsNative
        member __.get_draftVersionVisibility(): DraftVisibilityType = jsNative
        member __.set_draftVersionVisibility(value: DraftVisibilityType): unit = jsNative
        member __.get_effectiveBasePermissions(): BasePermissions = jsNative
        member __.get_effectiveBasePermissionsForUI(): BasePermissions = jsNative
        member __.get_enableAttachments(): bool = jsNative
        member __.set_enableAttachments(value: bool): unit = jsNative
        member __.get_enableFolderCreation(): bool = jsNative
        member __.set_enableFolderCreation(value: bool): unit = jsNative
        member __.get_enableMinorVersions(): bool = jsNative
        member __.set_enableMinorVersions(value: bool): unit = jsNative
        member __.get_enableModeration(): bool = jsNative
        member __.set_enableModeration(value: bool): unit = jsNative
        member __.get_enableVersioning(): bool = jsNative
        member __.set_enableVersioning(value: bool): unit = jsNative
        member __.get_entityTypeName(): string = jsNative
        member __.get_eventReceivers(): EventReceiverDefinitionCollection = jsNative
        member __.get_fields(): FieldCollection = jsNative
        member __.get_forceCheckout(): bool = jsNative
        member __.set_forceCheckout(value: bool): unit = jsNative
        member __.get_forms(): FormCollection = jsNative
        member __.get_hasExternalDataSource(): bool = jsNative
        member __.get_hidden(): bool = jsNative
        member __.set_hidden(value: bool): unit = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_imageUrl(): string = jsNative
        member __.set_imageUrl(value: string): unit = jsNative
        member __.get_informationRightsManagementSettings(): InformationRightsManagementSettings = jsNative
        member __.get_irmEnabled(): bool = jsNative
        member __.set_irmEnabled(value: bool): unit = jsNative
        member __.get_irmExpire(): bool = jsNative
        member __.set_irmExpire(value: bool): unit = jsNative
        member __.get_irmReject(): bool = jsNative
        member __.set_irmReject(value: bool): unit = jsNative
        member __.get_isApplicationList(): bool = jsNative
        member __.set_isApplicationList(value: bool): unit = jsNative
        member __.get_isCatalog(): bool = jsNative
        member __.get_isPrivate(): bool = jsNative
        member __.get_isSiteAssetsLibrary(): bool = jsNative
        member __.get_itemCount(): float = jsNative
        member __.get_lastItemDeletedDate(): DateTime = jsNative
        member __.get_lastItemModifiedDate(): DateTime = jsNative
        member __.set_lastItemModifiedDate(value: DateTime): unit = jsNative
        member __.get_listItemEntityTypeFullName(): string = jsNative
        member __.get_multipleDataList(): bool = jsNative
        member __.set_multipleDataList(value: bool): unit = jsNative
        member __.get_noCrawl(): bool = jsNative
        member __.set_noCrawl(value: bool): unit = jsNative
        member __.get_onQuickLaunch(): bool = jsNative
        member __.set_onQuickLaunch(value: bool): unit = jsNative
        member __.get_parentWeb(): Web = jsNative
        member __.get_parentWebUrl(): string = jsNative
        member __.get_rootFolder(): Folder = jsNative
        member __.get_schemaXml(): string = jsNative
        member __.get_serverTemplateCanCreateFolders(): bool = jsNative
        member __.get_templateFeatureId(): Guid = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_userCustomActions(): UserCustomActionCollection = jsNative
        member __.get_validationFormula(): string = jsNative
        member __.set_validationFormula(value: string): unit = jsNative
        member __.get_validationMessage(): string = jsNative
        member __.set_validationMessage(value: string): unit = jsNative
        member __.get_views(): ViewCollection = jsNative
        //member __.get_workflowAssociations(): WorkflowAssociationCollection = jsNative
        member __.getChanges(query: ChangeQuery): ChangeCollection = jsNative
        member __.getListItemChangesSinceToken(query: ChangeLogItemQuery): ResizeArray<obj> = jsNative
        member __.getUserEffectivePermissions(userName: string): BasePermissions = jsNative
        member __.saveAsNewView(oldName: string, newName: string, privateView: bool, uri: string): StringResult = jsNative
        member __.getRelatedFields(): RelatedFieldCollection = jsNative
        member __.getRelatedFieldsExtendedData(): RelatedFieldExtendedDataCollection = jsNative
        member __.renderListFormData(itemId: float, formId: string, mode: ControlMode): StringResult = jsNative
        member __.renderListData(viewXml: string): StringResult = jsNative
        member __.reserveListItemId(): IntResult = jsNative
        member __.update(): unit = jsNative
        member __.getView(viewGuid: Guid): View = jsNative
        member __.deleteObject(): unit = jsNative
        member __.recycle(): GuidResult = jsNative
        member __.getItems(query: CamlQuery): ListItemCollection = jsNative
        member __.addItem(parameters: ListItemCreationInformation): ListItem = jsNative

    and [<AllowNullLiteral>] [<Import("ListCollection","SP")>] ListCollection() =
        inherit ClientObjectCollection<List>()
        member __.itemAt(index: float): List = jsNative
        member __.get_item(index: float): List = jsNative
        member __.getByTitle(title: string): List = jsNative
        member __.getById(id: Guid): List = jsNative
        member __.getById(id: string): List = jsNative
        member __.add(parameters: ListCreationInformation): List = jsNative
        member __.ensureSitePagesLibrary(): List = jsNative
        member __.ensureSiteAssetsLibrary(): List = jsNative

    and [<AllowNullLiteral>] [<Import("ListCreationInformation","SP")>] ListCreationInformation() =
        inherit ClientValueObject()
        member __.get_customSchemaXml(): string = jsNative
        member __.set_customSchemaXml(value: string): unit = jsNative
        member __.get_dataSourceProperties(): obj = jsNative
        member __.set_dataSourceProperties(value: obj): unit = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_documentTemplateType(): float = jsNative
        member __.set_documentTemplateType(value: float): unit = jsNative
        member __.get_quickLaunchOption(): QuickLaunchOptions = jsNative
        member __.set_quickLaunchOption(value: QuickLaunchOptions): unit = jsNative
        member __.get_templateFeatureId(): Guid = jsNative
        member __.set_templateFeatureId(value: Guid): unit = jsNative
        member __.get_templateType(): float = jsNative
        member __.set_templateType(value: float): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ListDataSource","SP")>] ListDataSource() =
        inherit ClientValueObject()
        member __.get_properties(): obj = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ListDataValidationExceptionValue","SP")>] ListDataValidationExceptionValue() =
        inherit ClientValueObject()
        member __.get_fieldFailures(): ResizeArray<ListDataValidationFailure> = jsNative
        member __.get_itemFailure(): ListDataValidationFailure = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ListDataValidationFailure","SP")>] ListDataValidationFailure() =
        inherit ClientValueObject()
        member __.get_displayName(): string = jsNative
        member __.get_message(): string = jsNative
        member __.get_name(): string = jsNative
        member __.get_reason(): ListDataValidationFailureReason = jsNative
        member __.get_validationType(): ListDataValidationType = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and ListDataValidationFailureReason =
        | dataFailure = 0
        | formulaError = 1

    and ListDataValidationType =
        | userFormulaField = 0
        | userFormulaItem = 1
        | requiredField = 2
        | choiceField = 3
        | minMaxField = 4
        | textField = 5

    and [<AllowNullLiteral>] [<Import("ListItem","SP")>] ListItem() =
        inherit SecurableObject()
        member __.get_fieldValues(): obj = jsNative
        member __.get_item(fieldInternalName: string): obj = jsNative
        member __.set_item(fieldInternalName: string, value: obj): unit = jsNative
        member __.get_attachmentFiles(): AttachmentCollection = jsNative
        member __.get_contentType(): ContentType = jsNative
        member __.get_displayName(): string = jsNative
        member __.get_effectiveBasePermissions(): BasePermissions = jsNative
        member __.get_effectiveBasePermissionsForUI(): BasePermissions = jsNative
        member __.get_fieldValuesAsHtml(): FieldStringValues = jsNative
        member __.get_fieldValuesAsText(): FieldStringValues = jsNative
        member __.get_fieldValuesForEdit(): FieldStringValues = jsNative
        member __.get_file(): File = jsNative
        member __.get_fileSystemObjectType(): FileSystemObjectType = jsNative
        member __.get_folder(): Folder = jsNative
        member __.get_id(): float = jsNative
        member __.get_parentList(): List = jsNative
        member __.refreshLoad(): unit = jsNative
        //member __.getWOPIFrameUrl(action: SPWOPIFrameAction): StringResult = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative
        member __.recycle(): GuidResult = jsNative
        member __.getUserEffectivePermissions(userName: string): BasePermissions = jsNative
        member __.parseAndSetFieldValue(fieldInternalName: string, value: string): unit = jsNative
        member __.validateUpdateListItem(formValues: ResizeArray<ListItemFormUpdateValue>, bNewDocumentUpdate: bool): ResizeArray<ListItemFormUpdateValue> = jsNative

    and [<AllowNullLiteral>] [<Import("ListItemCollection","SP")>] ListItemCollection() =
        inherit ClientObjectCollection<ListItem>()
        member __.itemAt(index: float): ListItem = jsNative
        member __.get_item(index: float): ListItem = jsNative
        member __.getById(id: float): ListItem = jsNative
        member __.getById(id: string): ListItem = jsNative
        member __.get_listItemCollectionPosition(): ListItemCollectionPosition = jsNative

    and [<AllowNullLiteral>] [<Import("ListItemCollectionPosition","SP")>] ListItemCollectionPosition() =
        inherit ClientValueObject()
        member __.get_pagingInfo(): string = jsNative
        member __.set_pagingInfo(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ListItemCreationInformation","SP")>] ListItemCreationInformation() =
        inherit ClientValueObject()
        member __.get_folderUrl(): string = jsNative
        member __.set_folderUrl(value: string): unit = jsNative
        member __.get_leafName(): string = jsNative
        member __.set_leafName(value: string): unit = jsNative
        member __.get_underlyingObjectType(): FileSystemObjectType = jsNative
        member __.set_underlyingObjectType(value: FileSystemObjectType): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ListItemEntityCollection","SP")>] ListItemEntityCollection() =
        inherit ClientObjectCollection<ListItem>()
        member __.itemAt(index: float): ListItem = jsNative
        member __.get_item(index: float): ListItem = jsNative

    and [<AllowNullLiteral>] [<Import("ListItemFormUpdateValue","SP")>] ListItemFormUpdateValue() =
        inherit ClientValueObject()
        member __.get_errorMessage(): string = jsNative
        member __.set_errorMessage(value: string): unit = jsNative
        member __.get_fieldName(): string = jsNative
        member __.set_fieldName(value: string): unit = jsNative
        member __.get_fieldValue(): string = jsNative
        member __.set_fieldValue(value: string): unit = jsNative
        member __.get_hasException(): bool = jsNative
        member __.set_hasException(value: bool): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ListTemplate","SP")>] ListTemplate() =
        inherit ClientObject()
        member __.get_allowsFolderCreation(): bool = jsNative
        member __.get_baseType(): BaseType = jsNative
        member __.get_description(): string = jsNative
        member __.get_featureId(): Guid = jsNative
        member __.get_hidden(): bool = jsNative
        member __.get_imageUrl(): string = jsNative
        member __.get_internalName(): string = jsNative
        member __.get_isCustomTemplate(): bool = jsNative
        member __.get_name(): string = jsNative
        member __.get_onQuickLaunch(): bool = jsNative
        member __.get_listTemplateTypeKind(): float = jsNative
        member __.get_unique(): bool = jsNative

    and [<AllowNullLiteral>] [<Import("ListTemplateCollection","SP")>] ListTemplateCollection() =
        inherit ClientObjectCollection<ListTemplate>()
        member __.itemAt(index: float): ListTemplate = jsNative
        member __.get_item(index: float): ListTemplate = jsNative
        member __.getByName(name: string): ListTemplate = jsNative

    and ListTemplateType =
        | invalidType = 0
        | noListTemplate = 1
        | genericList = 2
        | documentLibrary = 3
        | survey = 4
        | links = 5
        | announcements = 6
        | contacts = 7
        | events = 8
        | tasks = 9
        | discussionBoard = 10
        | pictureLibrary = 11
        | dataSources = 12
        | webTemplateCatalog = 13
        | userInformation = 14
        | webPartCatalog = 15
        | listTemplateCatalog = 16
        | xMLForm = 17
        | masterPageCatalog = 18
        | noCodeWorkflows = 19
        | workflowProcess = 20
        | webPageLibrary = 21
        | customGrid = 22
        | solutionCatalog = 23
        | noCodePublic = 24
        | themeCatalog = 25
        | designCatalog = 26
        | appDataCatalog = 27
        | dataConnectionLibrary = 28
        | workflowHistory = 29
        | ganttTasks = 30
        | helpLibrary = 31
        | accessRequest = 32
        | tasksWithTimelineAndHierarchy = 33
        | maintenanceLogs = 34
        | meetings = 35
        | agenda = 36
        | meetingUser = 37
        | decision = 38
        | meetingObjective = 39
        | textBox = 40
        | thingsToBring = 41
        | homePageLibrary = 42
        | posts = 43
        | comments = 44
        | categories = 45
        | facility = 46
        | whereabouts = 47
        | callTrack = 48
        | circulation = 49
        | timecard = 50
        | holidays = 51
        | iMEDic = 52
        | externalList = 53
        | mySiteDocumentLibrary = 54
        | issueTracking = 55
        | adminTasks = 56
        | healthRules = 57
        | healthReports = 58
        | developerSiteDraftApps = 59

    and MoveOperations =
        | none = 0
        | overwrite = 1
        | allowBrokenThickets = 2
        | bypassApprovePermission = 3

    and [<AllowNullLiteral>] [<Import("Navigation","SP")>] Navigation() =
        inherit ClientObject()
        member __.get_quickLaunch(): NavigationNodeCollection = jsNative
        member __.get_topNavigationBar(): NavigationNodeCollection = jsNative
        member __.get_useShared(): bool = jsNative
        member __.set_useShared(value: bool): unit = jsNative
        member __.getNodeById(id: float): NavigationNode = jsNative

    and [<AllowNullLiteral>] [<Import("NavigationNode","SP")>] NavigationNode() =
        inherit ClientObject()
        member __.get_children(): NavigationNodeCollection = jsNative
        member __.get_id(): float = jsNative
        member __.get_isDocLib(): bool = jsNative
        member __.get_isExternal(): bool = jsNative
        member __.get_isVisible(): bool = jsNative
        member __.set_isVisible(value: bool): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("NavigationNodeCollection","SP")>] NavigationNodeCollection() =
        inherit ClientObjectCollection<NavigationNode>()
        member __.itemAt(index: float): NavigationNode = jsNative
        member __.get_item(index: float): NavigationNode = jsNative
        member __.add(parameters: NavigationNodeCreationInformation): NavigationNode = jsNative

    and [<AllowNullLiteral>] [<Import("NavigationNodeCreationInformation","SP")>] NavigationNodeCreationInformation() =
        inherit ClientValueObject()
        member __.get_asLastNode(): bool = jsNative
        member __.set_asLastNode(value: bool): unit = jsNative
        member __.get_isExternal(): bool = jsNative
        member __.set_isExternal(value: bool): unit = jsNative
        member __.get_previousNode(): NavigationNode = jsNative
        member __.set_previousNode(value: NavigationNode): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ObjectSharingInformation","SP")>] ObjectSharingInformation() =
        inherit ClientObject()
        member __.get_anonymousEditLink(): string = jsNative
        member __.get_anonymousViewLink(): string = jsNative
        member __.get_canManagePermissions(): bool = jsNative
        member __.get_hasPendingAccessRequests(): bool = jsNative
        member __.get_hasPermissionLevels(): bool = jsNative
        member __.get_isSharedWithCurrentUser(): bool = jsNative
        member __.get_isSharedWithGuest(): bool = jsNative
        member __.get_isSharedWithMany(): bool = jsNative
        member __.get_isSharedWithSecurityGroup(): bool = jsNative
        member __.get_pendingAccessRequestsLink(): string = jsNative
        member __.getSharedWithUsers(): ClientObjectList<ObjectSharingInformationUser> = jsNative
        static member getListItemSharingInformation(context: ClientRuntimeContext, listID: Guid, itemID: float, excludeCurrentUser: bool, excludeSiteAdmin: bool, excludeSecurityGroups: bool, retrieveAnonymousLinks: bool, retrieveUserInfoDetails: bool, checkForAccessRequests: bool): ObjectSharingInformation = jsNative
        static member getWebSharingInformation(context: ClientRuntimeContext, excludeCurrentUser: bool, excludeSiteAdmin: bool, excludeSecurityGroups: bool, retrieveAnonymousLinks: bool, retrieveUserInfoDetails: bool, checkForAccessRequests: bool): ObjectSharingInformation = jsNative
        static member getObjectSharingInformation(context: ClientRuntimeContext, securableObject: SecurableObject, excludeCurrentUser: bool, excludeSiteAdmin: bool, excludeSecurityGroups: bool, retrieveAnonymousLinks: bool, retrieveUserInfoDetails: bool, checkForAccessRequests: bool, retrievePermissionLevels: bool): ObjectSharingInformation = jsNative

    and [<AllowNullLiteral>] [<Import("ObjectSharingInformationUser","SP")>] ObjectSharingInformationUser() =
        inherit ClientObject()
        member __.get_customRoleNames(): string = jsNative
        member __.get_department(): string = jsNative
        member __.get_email(): string = jsNative
        member __.get_hasEditPermission(): bool = jsNative
        member __.get_hasViewPermission(): bool = jsNative
        member __.get_id(): float = jsNative
        member __.get_isSiteAdmin(): bool = jsNative
        member __.get_jobTitle(): string = jsNative
        member __.get_loginName(): string = jsNative
        member __.get_name(): string = jsNative
        member __.get_picture(): string = jsNative
        member __.get_principal(): Principal = jsNative
        member __.get_sipAddress(): string = jsNative
        member __.get_user(): User = jsNative

    and OpenWebOptions =
        | none = 0
        | initNavigationCache = 1

    and PageType =
        | invalid = 0
        | defaultView = 1
        | normalView = 2
        | dialogView = 3
        | view = 4
        | displayForm = 5
        | displayFormDialog = 6
        | editForm = 7
        | editFormDialog = 8
        | newForm = 9
        | newFormDialog = 10
        | solutionForm = 11
        | pAGE_MAXITEMS = 12

    and [<AllowNullLiteral>] [<Import("PropertyValues","SP")>] PropertyValues() =
        inherit ClientObject()
        member __.get_fieldValues(): obj = jsNative
        member __.get_item(fieldName: string): obj = jsNative
        member __.set_item(fieldName: string, value: obj): unit = jsNative
        member __.refreshLoad(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("PushNotificationSubscriber","SP")>] PushNotificationSubscriber() =
        inherit ClientObject()
        member __.get_customArgs(): string = jsNative
        member __.set_customArgs(value: string): unit = jsNative
        member __.get_deviceAppInstanceId(): Guid = jsNative
        member __.get_lastModifiedTimeStamp(): DateTime = jsNative
        member __.get_registrationTimeStamp(): DateTime = jsNative
        member __.get_serviceToken(): string = jsNative
        member __.set_serviceToken(value: string): unit = jsNative
        member __.get_subscriberType(): string = jsNative
        member __.set_subscriberType(value: string): unit = jsNative
        member __.get_user(): User = jsNative
        member __.update(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("PushNotificationSubscriberCollection","SP")>] PushNotificationSubscriberCollection() =
        inherit ClientObjectCollection<PushNotificationSubscriber>()
        member __.itemAt(index: float): PushNotificationSubscriber = jsNative
        member __.get_item(index: float): PushNotificationSubscriber = jsNative
        member __.getByStoreId(id: string): PushNotificationSubscriber = jsNative

    and QuickLaunchOptions =
        | off = 0
        | on = 1
        | defaultValue = 2

    and [<AllowNullLiteral>] [<Import("RecycleBinItem","SP")>] RecycleBinItem() =
        inherit ClientObject()
        member __.get_author(): User = jsNative
        member __.get_deletedBy(): User = jsNative
        member __.get_deletedDate(): DateTime = jsNative
        member __.get_dirName(): string = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_itemState(): RecycleBinItemState = jsNative
        member __.get_itemType(): RecycleBinItemType = jsNative
        member __.get_leafName(): string = jsNative
        member __.get_size(): float = jsNative
        member __.get_title(): string = jsNative
        member __.deleteObject(): unit = jsNative
        member __.restore(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RecycleBinItemCollection","SP")>] RecycleBinItemCollection() =
        inherit ClientObjectCollection<RecycleBinItem>()
        member __.itemAt(index: float): RecycleBinItem = jsNative
        member __.get_item(index: float): RecycleBinItem = jsNative
        member __.getById(id: Guid): RecycleBinItem = jsNative
        member __.deleteAll(): unit = jsNative
        member __.restoreAll(): unit = jsNative

    and RecycleBinItemState =
        | none = 0
        | firstStageRecycleBin = 1
        | secondStageRecycleBin = 2

    and RecycleBinItemType =
        | none = 0
        | file = 1
        | fileVersion = 2
        | listItem = 3
        | list = 4
        | folder = 5
        | folderWithLists = 6
        | attachment = 7
        | listItemVersion = 8
        | cascadeParent = 9
        | web = 10

    and [<AllowNullLiteral>] [<Import("RegionalSettings","SP")>] RegionalSettings() =
        inherit ClientObject()
        member __.get_adjustHijriDays(): float = jsNative
        member __.get_alternateCalendarType(): float = jsNative
        member __.get_aM(): string = jsNative
        member __.get_calendarType(): float = jsNative
        member __.get_collation(): float = jsNative
        member __.get_collationLCID(): float = jsNative
        member __.get_dateFormat(): float = jsNative
        member __.get_dateSeparator(): string = jsNative
        member __.get_decimalSeparator(): string = jsNative
        member __.get_digitGrouping(): string = jsNative
        member __.get_firstDayOfWeek(): float = jsNative
        member __.get_firstWeekOfYear(): float = jsNative
        member __.get_isEastAsia(): bool = jsNative
        member __.get_isRightToLeft(): bool = jsNative
        member __.get_isUIRightToLeft(): bool = jsNative
        member __.get_listSeparator(): string = jsNative
        member __.get_localeId(): float = jsNative
        member __.get_negativeSign(): string = jsNative
        member __.get_negNumberMode(): float = jsNative
        member __.get_pM(): string = jsNative
        member __.get_positiveSign(): string = jsNative
        member __.get_showWeeks(): bool = jsNative
        member __.get_thousandSeparator(): string = jsNative
        member __.get_time24(): bool = jsNative
        member __.get_timeMarkerPosition(): float = jsNative
        member __.get_timeSeparator(): string = jsNative
        member __.get_timeZone(): TimeZone = jsNative
        member __.get_timeZones(): TimeZoneCollection = jsNative
        member __.get_workDayEndHour(): float = jsNative
        member __.get_workDays(): float = jsNative
        member __.get_workDayStartHour(): float = jsNative

    and [<AllowNullLiteral>] [<Import("RelatedField","SP")>] RelatedField() =
        inherit ClientObject()
        member __.get_fieldId(): Guid = jsNative
        member __.get_listId(): Guid = jsNative
        member __.get_lookupList(): List = jsNative
        member __.get_relationshipDeleteBehavior(): RelationshipDeleteBehaviorType = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("RelatedFieldCollection","SP")>] RelatedFieldCollection() =
        inherit ClientObjectCollection<RelatedField>()
        member __.itemAt(index: float): RelatedField = jsNative
        member __.get_item(index: float): RelatedField = jsNative

    and [<AllowNullLiteral>] [<Import("RelatedFieldExtendedData","SP")>] RelatedFieldExtendedData() =
        inherit ClientObject()
        member __.get_fieldId(): Guid = jsNative
        member __.get_listId(): Guid = jsNative
        member __.get_listImageUrl(): string = jsNative
        member __.get_resolvedListTitle(): string = jsNative
        member __.get_toolTipDescription(): string = jsNative
        member __.get_webId(): Guid = jsNative

    and [<AllowNullLiteral>] [<Import("RelatedFieldExtendedDataCollection","SP")>] RelatedFieldExtendedDataCollection() =
        inherit ClientObjectCollection<RelatedFieldExtendedData>()
        member __.itemAt(index: float): RelatedFieldExtendedData = jsNative
        member __.get_item(index: float): RelatedFieldExtendedData = jsNative

    and [<AllowNullLiteral>] [<Import("RelatedItem","SP")>] RelatedItem() =
        inherit ClientValueObject()
        member __.get_iconUrl(): string = jsNative
        member __.set_iconUrl(value: string): unit = jsNative
        member __.get_itemId(): float = jsNative
        member __.set_itemId(value: float): unit = jsNative
        member __.get_listId(): string = jsNative
        member __.set_listId(value: string): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_webId(): string = jsNative
        member __.set_webId(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RelatedItemManager","SP")>] RelatedItemManager() =
        inherit ClientObject()
        static member getRelatedItems(context: ClientRuntimeContext, SourceListName: string, SourceItemID: float): ResizeArray<RelatedItem> = jsNative
        static member getPageOneRelatedItems(context: ClientRuntimeContext, SourceListName: string, SourceItemID: float): ResizeArray<RelatedItem> = jsNative
        static member addSingleLink(context: ClientRuntimeContext, SourceListName: string, SourceItemID: float, SourceWebUrl: string, TargetListName: string, TargetItemID: float, TargetWebUrl: string, TryAddReverseLink: bool): unit = jsNative
        static member addSingleLinkToUrl(context: ClientRuntimeContext, SourceListName: string, SourceItemID: float, TargetItemUrl: string, TryAddReverseLink: bool): unit = jsNative
        static member addSingleLinkFromUrl(context: ClientRuntimeContext, SourceItemUrl: string, TargetListName: string, TargetItemID: float, TryAddReverseLink: bool): unit = jsNative
        static member deleteSingleLink(context: ClientRuntimeContext, SourceListName: string, SourceItemID: float, SourceWebUrl: string, TargetListName: string, TargetItemID: float, TargetWebUrl: string, TryDeleteReverseLink: bool): unit = jsNative

    and RelationshipDeleteBehaviorType =
        | none = 0
        | cascade = 1
        | restrict = 2

    and [<AllowNullLiteral>] [<Import("RequestVariable","SP")>] RequestVariable(context: ClientRuntimeContext) =
        inherit ClientObject()
        member __.get_value(): string = jsNative
        static member newObject(context: ClientRuntimeContext): RequestVariable = jsNative
        member __.append(value: string): unit = jsNative
        member __.set(value: string): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RoleAssignment","SP")>] RoleAssignment() =
        inherit ClientObject()
        member __.get_member(): Principal = jsNative
        member __.get_principalId(): float = jsNative
        member __.get_roleDefinitionBindings(): RoleDefinitionBindingCollection = jsNative
        member __.importRoleDefinitionBindings(roleDefinitionBindings: RoleDefinitionBindingCollection): unit = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RoleAssignmentCollection","SP")>] RoleAssignmentCollection() =
        inherit ClientObjectCollection<RoleAssignment>()
        member __.itemAt(index: float): RoleAssignment = jsNative
        member __.get_item(index: float): RoleAssignment = jsNative
        member __.get_groups(): GroupCollection = jsNative
        member __.getByPrincipal(principalToFind: Principal): RoleAssignment = jsNative
        member __.getByPrincipalId(principalId: float): RoleAssignment = jsNative
        member __.add(principal: Principal, roleBindings: RoleDefinitionBindingCollection): RoleAssignment = jsNative

    and [<AllowNullLiteral>] [<Import("RoleDefinition","SP")>] RoleDefinition() =
        inherit ClientObject()
        member __.get_basePermissions(): BasePermissions = jsNative
        member __.set_basePermissions(value: BasePermissions): unit = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_hidden(): bool = jsNative
        member __.get_id(): float = jsNative
        member __.get_name(): string = jsNative
        member __.set_name(value: string): unit = jsNative
        member __.get_order(): float = jsNative
        member __.set_order(value: float): unit = jsNative
        member __.get_roleTypeKind(): RoleType = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RoleDefinitionBindingCollection","SP")>] RoleDefinitionBindingCollection(context: ClientRuntimeContext) =
        inherit ClientObjectCollection<RoleDefinition>()
        member __.itemAt(index: float): RoleDefinition = jsNative
        member __.get_item(index: float): RoleDefinition = jsNative
        static member newObject(context: ClientRuntimeContext): RoleDefinitionBindingCollection = jsNative
        member __.add(roleDefinition: RoleDefinition): unit = jsNative
        member __.remove(roleDefinition: RoleDefinition): unit = jsNative
        member __.removeAll(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("RoleDefinitionCollection","SP")>] RoleDefinitionCollection() =
        inherit ClientObjectCollection<RoleDefinition>()
        member __.itemAt(index: float): RoleDefinition = jsNative
        member __.get_item(index: float): RoleDefinition = jsNative
        member __.getByName(name: string): RoleDefinition = jsNative
        member __.add(parameters: RoleDefinitionCreationInformation): RoleDefinition = jsNative
        member __.getById(id: float): RoleDefinition = jsNative
        member __.getByType(roleType: RoleType): RoleDefinition = jsNative

    and [<AllowNullLiteral>] [<Import("RoleDefinitionCreationInformation","SP")>] RoleDefinitionCreationInformation() =
        inherit ClientValueObject()
        member __.get_basePermissions(): BasePermissions = jsNative
        member __.set_basePermissions(value: BasePermissions): unit = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_name(): string = jsNative
        member __.set_name(value: string): unit = jsNative
        member __.get_order(): float = jsNative
        member __.set_order(value: float): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and RoleType =
        | none = 0
        | guest = 1
        | reader = 2
        | contributor = 3
        | webDesigner = 4
        | administrator = 5
        | editor = 6

    and [<AllowNullLiteral>] [<Import("ServerSettings","SP")>] ServerSettings() =
        static member getAlternateUrls(context: ClientRuntimeContext): ClientObjectList<AlternateUrl> = jsNative
        static member getGlobalInstalledLanguages(context: ClientRuntimeContext, compatibilityLevel: float): ResizeArray<Language> = jsNative

    and [<AllowNullLiteral>] [<Import("Site","SP")>] Site() =
        inherit ClientObject()
        member __.get_allowDesigner(): bool = jsNative
        member __.set_allowDesigner(value: bool): unit = jsNative
        member __.get_allowMasterPageEditing(): bool = jsNative
        member __.set_allowMasterPageEditing(value: bool): unit = jsNative
        member __.get_allowRevertFromTemplate(): bool = jsNative
        member __.set_allowRevertFromTemplate(value: bool): unit = jsNative
        member __.get_allowSelfServiceUpgrade(): bool = jsNative
        member __.set_allowSelfServiceUpgrade(value: bool): unit = jsNative
        member __.get_allowSelfServiceUpgradeEvaluation(): bool = jsNative
        member __.set_allowSelfServiceUpgradeEvaluation(value: bool): unit = jsNative
        member __.get_canUpgrade(): bool = jsNative
        member __.get_compatibilityLevel(): float = jsNative
        member __.get_eventReceivers(): EventReceiverDefinitionCollection = jsNative
        member __.get_features(): FeatureCollection = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_lockIssue(): string = jsNative
        member __.get_maxItemsPerThrottledOperation(): float = jsNative
        member __.get_owner(): User = jsNative
        member __.set_owner(value: User): unit = jsNative
        member __.get_primaryUri(): string = jsNative
        member __.get_readOnly(): bool = jsNative
        member __.get_recycleBin(): RecycleBinItemCollection = jsNative
        member __.get_rootWeb(): Web = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.get_shareByLinkEnabled(): bool = jsNative
        member __.get_showUrlStructure(): bool = jsNative
        member __.set_showUrlStructure(value: bool): unit = jsNative
        member __.get_uIVersionConfigurationEnabled(): bool = jsNative
        member __.set_uIVersionConfigurationEnabled(value: bool): unit = jsNative
        member __.get_upgradeInfo(): UpgradeInfo = jsNative
        member __.get_upgradeReminderDate(): DateTime = jsNative
        member __.get_upgrading(): bool = jsNative
        member __.get_url(): string = jsNative
        member __.get_usage(): UsageInfo = jsNative
        member __.get_userCustomActions(): UserCustomActionCollection = jsNative
        member __.updateClientObjectModelUseRemoteAPIsPermissionSetting(requireUseRemoteAPIs: bool): unit = jsNative
        member __.needsUpgradeByType(versionUpgrade: bool, recursive: bool): BooleanResult = jsNative
        //member __.runHealthCheck(ruleId: Guid, bRepair: bool, bRunAlways: bool): SiteHealthSummary = jsNative
        member __.createPreviewSPSite(upgrade: bool, sendemail: bool): unit = jsNative
        member __.runUpgradeSiteSession(versionUpgrade: bool, queueOnly: bool, sendEmail: bool): unit = jsNative
        member __.getChanges(query: ChangeQuery): ChangeCollection = jsNative
        member __.openWeb(strUrl: string): Web = jsNative
        member __.openWebById(gWebId: Guid): Web = jsNative
        member __.getWebTemplates(LCID: float, overrideCompatLevel: float): WebTemplateCollection = jsNative
        member __.getCustomListTemplates(web: Web): ListTemplateCollection = jsNative
        member __.getCatalog(typeCatalog: float): List = jsNative
        member __.extendUpgradeReminderDate(): unit = jsNative
        member __.invalidate(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("SiteUrl","SP")>] SiteUrl() =
        inherit ClientObject()


    and [<AllowNullLiteral>] [<Import("SubwebQuery","SP")>] SubwebQuery() =
        inherit ClientValueObject()
        member __.get_configurationFilter(): float = jsNative
        member __.set_configurationFilter(value: float): unit = jsNative
        member __.get_webTemplateFilter(): float = jsNative
        member __.set_webTemplateFilter(value: float): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and TemplateFileType =
        | standardPage = 0
        | wikiPage = 1
        | formPage = 2

    and [<AllowNullLiteral>] [<Import("ThemeInfo","SP")>] ThemeInfo() =
        inherit ClientObject()
        member __.get_accessibleDescription(): string = jsNative
        member __.get_themeBackgroundImageUri(): string = jsNative
        member __.getThemeShadeByName(name: string): StringResult = jsNative
        member __.getThemeFontByName(name: string, lcid: float): StringResult = jsNative

    and [<AllowNullLiteral>] [<Import("TimeZone","SP")>] TimeZone() =
        inherit ClientObject()
        member __.get_description(): string = jsNative
        member __.get_id(): float = jsNative
        member __.get_information(): TimeZoneInformation = jsNative
        member __.localTimeToUTC(date: DateTime): DateTimeResult = jsNative
        member __.utcToLocalTime(date: DateTime): DateTimeResult = jsNative

    and [<AllowNullLiteral>] [<Import("TimeZoneCollection","SP")>] TimeZoneCollection() =
        inherit ClientObjectCollection<TimeZone>()
        member __.itemAt(index: float): TimeZone = jsNative
        member __.get_item(index: float): TimeZone = jsNative
        member __.getById(id: float): TimeZone = jsNative

    and [<AllowNullLiteral>] [<Import("TimeZoneInformation","SP")>] TimeZoneInformation() =
        inherit ClientValueObject()
        member __.get_bias(): float = jsNative
        member __.get_daylightBias(): float = jsNative
        member __.get_standardBias(): float = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("UpgradeInfo","SP")>] UpgradeInfo() =
        inherit ClientValueObject()
        member __.get_errorFile(): string = jsNative
        member __.get_errors(): float = jsNative
        member __.get_lastUpdated(): DateTime = jsNative
        member __.get_logFile(): string = jsNative
        member __.get_requestDate(): DateTime = jsNative
        member __.get_retryCount(): float = jsNative
        member __.get_startTime(): DateTime = jsNative
        member __.get_status(): UpgradeStatus = jsNative
        member __.get_upgradeType(): UpgradeType = jsNative
        member __.get_warnings(): float = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and UpgradeStatus =
        | none = 0
        | inProgress = 1
        | failed = 2
        | completed = 3

    and UpgradeType =
        | buildUpgrade = 0
        | versionUpgrade = 1

    and UrlFieldFormatType =
        | hyperlink = 0
        | image = 1

    and UrlZone =
        | defaultZone = 0
        | intranet = 1
        | internet = 2
        | custom = 3
        | extranet = 4

    and [<AllowNullLiteral>] [<Import("UsageInfo","SP")>] UsageInfo() =
        inherit ClientValueObject()
        member __.get_bandwidth(): float = jsNative
        member __.get_discussionStorage(): float = jsNative
        member __.get_hits(): float = jsNative
        member __.get_storage(): float = jsNative
        member __.get_storagePercentageUsed(): float = jsNative
        member __.get_visits(): float = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("User","SP")>] User() =
        inherit Principal()
        member __.get_email(): string = jsNative
        member __.set_email(value: string): unit = jsNative
        member __.get_groups(): GroupCollection = jsNative
        member __.get_isSiteAdmin(): bool = jsNative
        member __.set_isSiteAdmin(value: bool): unit = jsNative
        member __.get_userId(): UserIdInfo = jsNative
        member __.update(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("UserCollection","SP")>] UserCollection() =
        inherit ClientObjectCollection<User>()
        member __.itemAt(index: float): User = jsNative
        member __.get_item(index: float): User = jsNative
        member __.getByLoginName(loginName: string): User = jsNative
        member __.getById(id: float): User = jsNative
        member __.getByEmail(emailAddress: string): User = jsNative
        member __.removeByLoginName(loginName: string): unit = jsNative
        member __.removeById(id: float): unit = jsNative
        member __.remove(user: User): unit = jsNative
        member __.add(parameters: UserCreationInformation): User = jsNative
        member __.addUser(user: User): User = jsNative

    and [<AllowNullLiteral>] [<Import("UserCreationInformation","SP")>] UserCreationInformation() =
        inherit ClientValueObject()
        member __.get_email(): string = jsNative
        member __.set_email(value: string): unit = jsNative
        member __.get_loginName(): string = jsNative
        member __.set_loginName(value: string): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("UserCustomAction","SP")>] UserCustomAction() =
        inherit ClientObject()
        member __.get_commandUIExtension(): string = jsNative
        member __.set_commandUIExtension(value: string): unit = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_group(): string = jsNative
        member __.set_group(value: string): unit = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_imageUrl(): string = jsNative
        member __.set_imageUrl(value: string): unit = jsNative
        member __.get_location(): string = jsNative
        member __.set_location(value: string): unit = jsNative
        member __.get_name(): string = jsNative
        member __.set_name(value: string): unit = jsNative
        member __.get_registrationId(): string = jsNative
        member __.set_registrationId(value: string): unit = jsNative
        member __.get_registrationType(): UserCustomActionRegistrationType = jsNative
        member __.set_registrationType(value: UserCustomActionRegistrationType): unit = jsNative
        member __.get_rights(): BasePermissions = jsNative
        member __.set_rights(value: BasePermissions): unit = jsNative
        member __.get_scope(): UserCustomActionScope = jsNative
        member __.get_scriptBlock(): string = jsNative
        member __.set_scriptBlock(value: string): unit = jsNative
        member __.get_scriptSrc(): string = jsNative
        member __.set_scriptSrc(value: string): unit = jsNative
        member __.get_sequence(): float = jsNative
        member __.set_sequence(value: float): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_versionOfUserCustomAction(): string = jsNative
        member __.update(): unit = jsNative
        member __.deleteObject(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("UserCustomActionCollection","SP")>] UserCustomActionCollection() =
        inherit ClientObjectCollection<UserCustomAction>()
        member __.itemAt(index: float): UserCustomAction = jsNative
        member __.get_item(index: float): UserCustomAction = jsNative
        member __.getById(id: Guid): UserCustomAction = jsNative
        member __.clear(): unit = jsNative
        member __.add(): UserCustomAction = jsNative

    and UserCustomActionRegistrationType =
        | none = 0
        | list = 1
        | contentType = 2
        | progId = 3
        | fileType = 4

    and UserCustomActionScope =
        | unknown = 0
        | site = 1
        | web = 2
        | list = 3

    and [<AllowNullLiteral>] [<Import("UserIdInfo","SP")>] UserIdInfo() =
        inherit ClientValueObject()
        member __.get_nameId(): string = jsNative
        member __.get_nameIdIssuer(): string = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("View","SP")>] View() =
        inherit ClientObject()
        member __.get_aggregations(): string = jsNative
        member __.set_aggregations(value: string): unit = jsNative
        member __.get_aggregationsStatus(): string = jsNative
        member __.set_aggregationsStatus(value: string): unit = jsNative
        member __.get_baseViewId(): string = jsNative
        member __.get_contentTypeId(): ContentTypeId = jsNative
        member __.set_contentTypeId(value: ContentTypeId): unit = jsNative
        member __.get_defaultView(): bool = jsNative
        member __.set_defaultView(value: bool): unit = jsNative
        member __.get_defaultViewForContentType(): bool = jsNative
        member __.set_defaultViewForContentType(value: bool): unit = jsNative
        member __.get_editorModified(): bool = jsNative
        member __.set_editorModified(value: bool): unit = jsNative
        member __.get_formats(): string = jsNative
        member __.set_formats(value: string): unit = jsNative
        member __.get_hidden(): bool = jsNative
        member __.set_hidden(value: bool): unit = jsNative
        member __.get_htmlSchemaXml(): string = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_imageUrl(): string = jsNative
        member __.get_includeRootFolder(): bool = jsNative
        member __.set_includeRootFolder(value: bool): unit = jsNative
        member __.get_viewJoins(): string = jsNative
        member __.set_viewJoins(value: string): unit = jsNative
        member __.get_jsLink(): string = jsNative
        member __.set_jsLink(value: string): unit = jsNative
        member __.get_listViewXml(): string = jsNative
        member __.set_listViewXml(value: string): unit = jsNative
        member __.get_method(): string = jsNative
        member __.set_method(value: string): unit = jsNative
        member __.get_mobileDefaultView(): bool = jsNative
        member __.set_mobileDefaultView(value: bool): unit = jsNative
        member __.get_mobileView(): bool = jsNative
        member __.set_mobileView(value: bool): unit = jsNative
        member __.get_moderationType(): string = jsNative
        member __.get_orderedView(): bool = jsNative
        member __.get_paged(): bool = jsNative
        member __.set_paged(value: bool): unit = jsNative
        member __.get_personalView(): bool = jsNative
        member __.get_viewProjectedFields(): string = jsNative
        member __.set_viewProjectedFields(value: string): unit = jsNative
        member __.get_viewQuery(): string = jsNative
        member __.set_viewQuery(value: string): unit = jsNative
        member __.get_readOnlyView(): bool = jsNative
        member __.get_requiresClientIntegration(): bool = jsNative
        member __.get_rowLimit(): float = jsNative
        member __.set_rowLimit(value: float): unit = jsNative
        member __.get_scope(): ViewScope = jsNative
        member __.set_scope(value: ViewScope): unit = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.get_styleId(): string = jsNative
        member __.get_threaded(): bool = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_toolbar(): string = jsNative
        member __.set_toolbar(value: string): unit = jsNative
        member __.get_toolbarTemplateName(): string = jsNative
        member __.get_viewType(): string = jsNative
        member __.get_viewData(): string = jsNative
        member __.set_viewData(value: string): unit = jsNative
        member __.get_viewFields(): ViewFieldCollection = jsNative
        member __.deleteObject(): unit = jsNative
        member __.renderAsHtml(): StringResult = jsNative
        member __.update(): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ViewCollection","SP")>] ViewCollection() =
        inherit ClientObjectCollection<View>()
        member __.itemAt(index: float): View = jsNative
        member __.get_item(index: float): View = jsNative
        member __.getByTitle(strTitle: string): View = jsNative
        member __.getById(guidId: Guid): View = jsNative
        member __.add(parameters: ViewCreationInformation): View = jsNative

    and [<AllowNullLiteral>] [<Import("ViewCreationInformation","SP")>] ViewCreationInformation() =
        inherit ClientValueObject()
        member __.get_paged(): bool = jsNative
        member __.set_paged(value: bool): unit = jsNative
        member __.get_personalView(): bool = jsNative
        member __.set_personalView(value: bool): unit = jsNative
        member __.get_query(): string = jsNative
        member __.set_query(value: string): unit = jsNative
        member __.get_rowLimit(): float = jsNative
        member __.set_rowLimit(value: float): unit = jsNative
        member __.get_setAsDefaultView(): bool = jsNative
        member __.set_setAsDefaultView(value: bool): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_viewFields(): ResizeArray<string> = jsNative
        member __.set_viewFields(value: ResizeArray<string>): unit = jsNative
        member __.get_viewTypeKind(): ViewType = jsNative
        member __.set_viewTypeKind(value: ViewType): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("ViewFieldCollection","SP")>] ViewFieldCollection() =
        inherit ClientObjectCollection<string>()
        member __.itemAt(index: float): string = jsNative
        member __.get_item(index: float): string = jsNative
        member __.get_schemaXml(): string = jsNative
        member __.moveFieldTo(field: string, index: float): unit = jsNative
        member __.add(strField: string): unit = jsNative
        member __.remove(strField: string): unit = jsNative
        member __.removeAll(): unit = jsNative

    and ViewScope =
        | defaultValue = 0
        | recursive = 1
        | recursiveAll = 2
        | filesOnly = 3

    and ViewType =
        | none = 0
        | html = 1
        | grid = 2
        | calendar = 3
        | recurrence = 4
        | chart = 5
        | gantt = 6

    and [<AllowNullLiteral>] [<Import("Web","SP")>] Web() =
        inherit SecurableObject()
        member __.get_allowDesignerForCurrentUser(): bool = jsNative
        member __.get_allowMasterPageEditingForCurrentUser(): bool = jsNative
        member __.get_allowRevertFromTemplateForCurrentUser(): bool = jsNative
        member __.get_allowRssFeeds(): bool = jsNative
        member __.get_allProperties(): PropertyValues = jsNative
        member __.get_appInstanceId(): Guid = jsNative
        member __.get_associatedMemberGroup(): Group = jsNative
        member __.set_associatedMemberGroup(value: Group): unit = jsNative
        member __.get_associatedOwnerGroup(): Group = jsNative
        member __.set_associatedOwnerGroup(value: Group): unit = jsNative
        member __.get_associatedVisitorGroup(): Group = jsNative
        member __.set_associatedVisitorGroup(value: Group): unit = jsNative
        member __.get_availableContentTypes(): ContentTypeCollection = jsNative
        member __.get_availableFields(): FieldCollection = jsNative
        member __.get_configuration(): float = jsNative
        member __.get_contentTypes(): ContentTypeCollection = jsNative
        member __.get_created(): DateTime = jsNative
        member __.get_currentUser(): User = jsNative
        member __.get_customMasterUrl(): string = jsNative
        member __.set_customMasterUrl(value: string): unit = jsNative
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_documentLibraryCalloutOfficeWebAppPreviewersDisabled(): bool = jsNative
        member __.get_effectiveBasePermissions(): BasePermissions = jsNative
        member __.get_enableMinimalDownload(): bool = jsNative
        member __.set_enableMinimalDownload(value: bool): unit = jsNative
        member __.get_eventReceivers(): EventReceiverDefinitionCollection = jsNative
        member __.get_features(): FeatureCollection = jsNative
        member __.get_fields(): FieldCollection = jsNative
        member __.get_folders(): FolderCollection = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_language(): float = jsNative
        member __.get_lastItemModifiedDate(): DateTime = jsNative
        member __.get_lists(): ListCollection = jsNative
        member __.get_listTemplates(): ListTemplateCollection = jsNative
        member __.get_masterUrl(): string = jsNative
        member __.set_masterUrl(value: string): unit = jsNative
        member __.get_navigation(): Navigation = jsNative
        member __.get_parentWeb(): WebInformation = jsNative
        member __.get_pushNotificationSubscribers(): PushNotificationSubscriberCollection = jsNative
        member __.get_quickLaunchEnabled(): bool = jsNative
        member __.set_quickLaunchEnabled(value: bool): unit = jsNative
        member __.get_recycleBin(): RecycleBinItemCollection = jsNative
        member __.get_recycleBinEnabled(): bool = jsNative
        member __.get_regionalSettings(): RegionalSettings = jsNative
        member __.get_roleDefinitions(): RoleDefinitionCollection = jsNative
        member __.get_rootFolder(): Folder = jsNative
        member __.get_saveSiteAsTemplateEnabled(): bool = jsNative
        member __.set_saveSiteAsTemplateEnabled(value: bool): unit = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.set_serverRelativeUrl(value: string): unit = jsNative
        member __.get_showUrlStructureForCurrentUser(): bool = jsNative
        member __.get_siteGroups(): GroupCollection = jsNative
        member __.get_siteUserInfoList(): List = jsNative
        member __.get_siteUsers(): UserCollection = jsNative
        member __.get_supportedUILanguageIds(): ResizeArray<float> = jsNative
        member __.get_syndicationEnabled(): bool = jsNative
        member __.set_syndicationEnabled(value: bool): unit = jsNative
        member __.get_themeInfo(): ThemeInfo = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_treeViewEnabled(): bool = jsNative
        member __.set_treeViewEnabled(value: bool): unit = jsNative
        member __.get_uIVersion(): float = jsNative
        member __.set_uIVersion(value: float): unit = jsNative
        member __.get_uIVersionConfigurationEnabled(): bool = jsNative
        member __.set_uIVersionConfigurationEnabled(value: bool): unit = jsNative
        member __.get_url(): string = jsNative
        member __.get_userCustomActions(): UserCustomActionCollection = jsNative
        member __.get_webs(): WebCollection = jsNative
        member __.get_webTemplate(): string = jsNative
        //member __.get_workflowAssociations(): WorkflowAssociationCollection = jsNative
        //member __.get_workflowTemplates(): WorkflowTemplateCollection = jsNative
        member __.doesUserHavePermissions(permissionMask: BasePermissions): BooleanResult = jsNative
        member __.getUserEffectivePermissions(userName: string): BasePermissions = jsNative
        //member __.mapToIcon(fileName: string, progId: string, size: IconSize): StringResult = jsNative
        member __.registerPushNotificationSubscriber(deviceAppInstanceId: Guid, serviceToken: string): PushNotificationSubscriber = jsNative
        member __.unregisterPushNotificationSubscriber(deviceAppInstanceId: Guid): unit = jsNative
        member __.getPushNotificationSubscribersByArgs(customArgs: string): PushNotificationSubscriberCollection = jsNative
        member __.getPushNotificationSubscribersByUser(userName: string): PushNotificationSubscriberCollection = jsNative
        member __.doesPushNotificationSubscriberExist(deviceAppInstanceId: Guid): BooleanResult = jsNative
        member __.getPushNotificationSubscriber(deviceAppInstanceId: Guid): PushNotificationSubscriber = jsNative
        member __.getUserById(userId: float): User = jsNative
        member __.getAvailableWebTemplates(lcid: float, doIncludeCrossLanguage: bool): WebTemplateCollection = jsNative
        member __.getCatalog(typeCatalog: float): List = jsNative
        member __.getChanges(query: ChangeQuery): ChangeCollection = jsNative
        member __.applyWebTemplate(webTemplate: string): unit = jsNative
        member __.deleteObject(): unit = jsNative
        member __.update(): unit = jsNative
        member __.getFileByServerRelativeUrl(serverRelativeUrl: string): File = jsNative
        member __.getFolderByServerRelativeUrl(serverRelativeUrl: string): Folder = jsNative
        //member __.getEntity(``namespace``: string, name: string): Entity = jsNative
        //member __.getAppBdcCatalogForAppInstance(appInstanceId: Guid): AppBdcCatalog = jsNative
        //member __.getAppBdcCatalog(): AppBdcCatalog = jsNative
        member __.getSubwebsForCurrentUser(query: SubwebQuery): WebCollection = jsNative
        member __.getAppInstanceById(appInstanceId: Guid): AppInstance = jsNative
        member __.getAppInstancesByProductId(productId: Guid): ClientObjectList<AppInstance> = jsNative
        member __.loadAndInstallAppInSpecifiedLocale(appPackageStream: Base64EncodedByteArray, installationLocaleLCID: float): AppInstance = jsNative
        member __.loadApp(appPackageStream: Base64EncodedByteArray, installationLocaleLCID: float): AppInstance = jsNative
        member __.loadAndInstallApp(appPackageStream: Base64EncodedByteArray): AppInstance = jsNative
        member __.ensureUser(logonName: string): User = jsNative
        member __.applyTheme(colorPaletteUrl: string, fontSchemeUrl: string, backgroundImageUrl: string, shareGenerated: bool): unit = jsNative
        member __.getList(url: string): List = jsNative

    and [<AllowNullLiteral>] [<Import("WebCollection","SP")>] WebCollection() =
        inherit ClientObjectCollection<Web>()
        member __.itemAt(index: float): Web = jsNative
        member __.get_item(index: float): Web = jsNative
        member __.add(parameters: WebCreationInformation): Web = jsNative

    and [<AllowNullLiteral>] [<Import("WebCreationInformation","SP")>] WebCreationInformation() =
        inherit ClientValueObject()
        member __.get_description(): string = jsNative
        member __.set_description(value: string): unit = jsNative
        member __.get_language(): float = jsNative
        member __.set_language(value: float): unit = jsNative
        member __.get_title(): string = jsNative
        member __.set_title(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_useSamePermissionsAsParentSite(): bool = jsNative
        member __.set_useSamePermissionsAsParentSite(value: bool): unit = jsNative
        member __.get_webTemplate(): string = jsNative
        member __.set_webTemplate(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("WebInformation","SP")>] WebInformation() =
        inherit ClientObject()
        member __.get_configuration(): float = jsNative
        member __.get_created(): DateTime = jsNative
        member __.get_description(): string = jsNative
        member __.get_id(): Guid = jsNative
        member __.get_language(): float = jsNative
        member __.get_lastItemModifiedDate(): DateTime = jsNative
        member __.get_serverRelativeUrl(): string = jsNative
        member __.get_title(): string = jsNative
        member __.get_webTemplate(): string = jsNative
        member __.get_webTemplateId(): float = jsNative

    and [<AllowNullLiteral>] [<Import("WebProxy","SP")>] WebProxy() =
        static member invoke(context: ClientRuntimeContext, requestInfo: WebRequestInfo): WebResponseInfo = jsNative

    and [<AllowNullLiteral>] [<Import("WebRequestInfo","SP")>] WebRequestInfo() =
        inherit ClientValueObject()
        member __.get_body(): string = jsNative
        member __.set_body(value: string): unit = jsNative
        member __.get_headers(): obj = jsNative
        member __.set_headers(value: obj): unit = jsNative
        member __.get_method(): string = jsNative
        member __.set_method(value: string): unit = jsNative
        member __.get_url(): string = jsNative
        member __.set_url(value: string): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("WebResponseInfo","SP")>] WebResponseInfo() =
        inherit ClientValueObject()
        member __.get_body(): string = jsNative
        member __.set_body(value: string): unit = jsNative
        member __.get_headers(): obj = jsNative
        member __.set_headers(value: obj): unit = jsNative
        member __.get_statusCode(): float = jsNative
        member __.set_statusCode(value: float): unit = jsNative
        member __.get_typeId(): string = jsNative
        member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

    and [<AllowNullLiteral>] [<Import("WebTemplate","SP")>] WebTemplate() =
        inherit ClientObject()
        member __.get_description(): string = jsNative
        member __.get_displayCategory(): string = jsNative
        member __.get_id(): float = jsNative
        member __.get_imageUrl(): string = jsNative
        member __.get_isHidden(): bool = jsNative
        member __.get_isRootWebOnly(): bool = jsNative
        member __.get_isSubWebOnly(): bool = jsNative
        member __.get_lcid(): float = jsNative
        member __.get_name(): string = jsNative
        member __.get_title(): string = jsNative

    and [<AllowNullLiteral>] [<Import("WebTemplateCollection","SP")>] WebTemplateCollection() =
        inherit ClientObjectCollection<WebTemplate>()
        member __.itemAt(index: float): WebTemplate = jsNative
        member __.get_item(index: float): WebTemplate = jsNative
        member __.getByName(name: string): WebTemplate = jsNative

    module Application =
        module UI =
            type [<AllowNullLiteral>] DefaultFormsInformationRequestor =
                abstract onDefaultFormsInformationRetrieveSuccess: defaultForms: DefaultFormsInformation -> unit
                abstract onDefaultFormsInformationRetrieveFailure: unit -> unit

            and [<AllowNullLiteral>] [<Import("Application.UI.FormsInfo","SP")>] FormsInfo() =
                member __.ContentTypeName with get(): string = jsNative and set(v: string): unit = jsNative
                member __.NewFormUrl with get(): string = jsNative and set(v: string): unit = jsNative
                member __.DisplayFormUrl with get(): string = jsNative and set(v: string): unit = jsNative
                member __.EditFormUrl with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.DefaultFormsInformation","SP")>] DefaultFormsInformation() =
                member __.DefaultForms with get(): FormsInfo = jsNative and set(v: FormsInfo): unit = jsNative
                member __.OtherForms with get(): obj = jsNative and set(v: obj): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.DefaultFormsMenuBuilder","SP")>] DefaultFormsMenuBuilder() =
                static member getDefaultFormsInformation(requestor: DefaultFormsInformationRequestor, listId: Guid): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.ViewSelectorMenuOptions","SP")>] ViewSelectorMenuOptions() =
                member __.showRepairView with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.showMergeView with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.showEditView with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.showCreateView with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.showApproverView with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.listId with get(): string = jsNative and set(v: string): unit = jsNative
                member __.viewId with get(): string = jsNative and set(v: string): unit = jsNative
                member __.viewParameters with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] ViewInformationRequestor =
                abstract onViewInformationReturned: viewGroups: ViewSelectorGroups -> unit

            and [<AllowNullLiteral>] [<Import("Application.UI.ViewSelectorGroups","SP")>] ViewSelectorGroups() =
                member __.ModeratedViews with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.PublicViews with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.PersonalViews with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.OtherViews with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.DefaultView with get(): ViewSelectorMenuItem = jsNative and set(v: ViewSelectorMenuItem): unit = jsNative
                member __.ViewCreation with get(): obj = jsNative and set(v: obj): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.ViewSelectorMenuItem","SP")>] ViewSelectorMenuItem() =
                member __.Text with get(): string = jsNative and set(v: string): unit = jsNative
                member __.ActionScriptText with get(): string = jsNative and set(v: string): unit = jsNative
                member __.NavigateUrl with get(): string = jsNative and set(v: string): unit = jsNative
                member __.ImageSourceUrl with get(): string = jsNative and set(v: string): unit = jsNative
                member __.Description with get(): string = jsNative and set(v: string): unit = jsNative
                member __.Id with get(): string = jsNative and set(v: string): unit = jsNative
                member __.Sequence with get(): float = jsNative and set(v: float): unit = jsNative
                member __.ItemType with get(): string = jsNative and set(v: string): unit = jsNative
                member __.GroupId with get(): float = jsNative and set(v: float): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.ViewSelectorSubMenu","SP")>] ViewSelectorSubMenu() =
                member __.Text with get(): string = jsNative and set(v: string): unit = jsNative
                member __.ImageSourceUrl with get(): string = jsNative and set(v: string): unit = jsNative
                member __.SubMenuItems with get(): obj = jsNative and set(v: obj): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.ViewSelectorMenuBuilder","SP")>] ViewSelectorMenuBuilder() =
                static member get_filterMenuItemsCallback(): Func<obj, obj> = jsNative
                static member set_filterMenuItemsCallback(value: Func<obj, obj>): unit = jsNative
                static member showMenu(elem: HTMLElement, options: ViewSelectorMenuOptions): unit = jsNative
                static member getViewInformation(requestor: ViewInformationRequestor, options: ViewSelectorMenuOptions): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.MoreColorsPicker","SP")>] MoreColorsPicker(e: HTMLElement) =
                //interface Control
                member __.initialize(): unit = jsNative
                member __.dispose(): unit = jsNative
                member __.get_colorValue(): string = jsNative
                member __.set_colorValue(value: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.MoreColorsPage","SP")>] MoreColorsPage(e: HTMLElement) =
                //interface Control
                member __.initialize(): unit = jsNative
                member __.dispose(): unit = jsNative
                member __.get_moreColorsPicker(): MoreColorsPicker = jsNative
                member __.set_moreColorsPicker(value: MoreColorsPicker): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.ThemeWebPage","SP")>] ThemeWebPage(e: HTMLElement) =
                //interface Control
                //member __.add_themeDisplayUpdated(value: Func<obj, Sys.EventArgs, unit>): unit = jsNative
                //member __.remove_themeDisplayUpdated(value: Func<obj, Sys.EventArgs, unit>): unit = jsNative
                member __.initialize(): unit = jsNative
                member __.dispose(): unit = jsNative
                //member __.onThemeSelectionChanged(evt: DomEvent): unit = jsNative
                member __.updateThemeDisplay(): unit = jsNative
                member __.get_thmxThemes(): obj = jsNative
                member __.set_thmxThemes(value: obj): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Application.UI.WikiPageNameInPlaceEditor","SP")>] WikiPageNameInPlaceEditor(ownerDoc: obj, displayElemId: string, editElemId: string, editTextBoxId: string) =
                member __.editingPageCallback(): unit = jsNative
                member __.savingPageCallback(): unit = jsNative



    module Analytics =
        type [<AllowNullLiteral>] [<Import("Analytics.AnalyticsUsageEntry","SP")>] AnalyticsUsageEntry() =
            inherit ClientObject()
            static member logAnalyticsEvent(context: ClientRuntimeContext, eventTypeId: float, itemId: string): unit = jsNative
            static member logAnalyticsEvent2(context: ClientRuntimeContext, eventTypeId: float, itemId: string, rollupScopeId: Guid, siteId: Guid, userId: string): unit = jsNative
            static member logAnalyticsAppEvent(context: ClientRuntimeContext, appEventTypeId: Guid, itemId: string): unit = jsNative
            static member logAnalyticsAppEvent2(context: ClientRuntimeContext, appEventTypeId: Guid, itemId: string, rollupScopeId: Guid, siteId: Guid, userId: string): unit = jsNative

        and EventTypeId =
            | none = 0
            | first = 1
            | view = 2
            | recommendationView = 3
            | recommendationClick = 4
            | last = 5



    module SiteHealth =
        type [<AllowNullLiteral>] [<Import("SiteHealth.SiteHealthResult","SP")>] SiteHealthResult() =
            inherit ClientValueObject()
            member __.get_messageAsText(): string = jsNative
            member __.get_ruleHelpLink(): string = jsNative
            member __.get_ruleId(): Guid = jsNative
            member __.get_ruleIsRepairable(): bool = jsNative
            member __.get_ruleName(): string = jsNative
            member __.get_status(): SiteHealthStatusType = jsNative
            member __.set_status(value: SiteHealthStatusType): unit = jsNative
            member __.get_timeStamp(): DateTime = jsNative
            member __.set_timeStamp(value: DateTime): unit = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and SiteHealthStatusType =
            | passed = 0
            | failedWarning = 1
            | failedError = 2

        and [<AllowNullLiteral>] [<Import("SiteHealth.SiteHealthSummary","SP")>] SiteHealthSummary() =
            inherit ClientObject()
            member __.get_failedErrorCount(): float = jsNative
            member __.get_failedWarningCount(): float = jsNative
            member __.get_passedCount(): float = jsNative
            member __.get_results(): ResizeArray<SiteHealthResult> = jsNative



    module BusinessData =
        type [<AllowNullLiteral>] [<Import("BusinessData.AppBdcCatalog","SP")>] AppBdcCatalog() =
            inherit ClientObject()
            member __.getEntity(``namespace``: string, name: string): Entity = jsNative
            member __.getLobSystemProperty(lobSystemName: string, propertyName: string): StringResult = jsNative
            member __.setLobSystemProperty(lobSystemName: string, propertyName: string, propertyValue: string): unit = jsNative
            member __.getLobSystemInstanceProperty(lobSystemName: string, lobSystemInstanceName: string, propertyName: string): StringResult = jsNative
            member __.setLobSystemInstanceProperty(lobSystemName: string, lobSystemInstanceName: string, propertyName: string, propertyValue: string): unit = jsNative
            member __.getConnectionId(lobSystemName: string, lobSystemInstanceName: string): StringResult = jsNative
            member __.setConnectionId(lobSystemName: string, lobSystemInstanceName: string, connectionId: string): unit = jsNative
            member __.getPermissibleConnections(): ResizeArray<string> = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.Entity","SP")>] Entity() =
            inherit ClientObject()
            member __.get_estimatedInstanceCount(): float = jsNative
            member __.get_name(): string = jsNative
            member __.get_namespace(): string = jsNative
            //member __.getIdentifiers(): EntityIdentifierCollection = jsNative
            member __.getIdentifierCount(): IntResult = jsNative
            member __.getLobSystem(): LobSystem = jsNative
            member __.getCreatorView(methodInstanceName: string): EntityView = jsNative
            member __.getUpdaterView(updaterName: string): EntityView = jsNative
            member __.getFinderView(methodInstanceName: string): EntityView = jsNative
            member __.getSpecificFinderView(specificFinderName: string): EntityView = jsNative
            member __.getDefaultSpecificFinderView(): EntityView = jsNative
           (* member __.findSpecificDefault(identity: EntityIdentity, lobSystemInstance: LobSystemInstance): EntityInstance = jsNative
            member __.findSpecific(identity: EntityIdentity, specificFinderName: string, lobSystemInstance: LobSystemInstance): EntityInstance = jsNative
            member __.findSpecificDefaultByBdcId(bdcIdentity: string, lobSystemInstance: LobSystemInstance): EntityInstance = jsNative
            member __.findSpecificByBdcId(bdcIdentity: string, specificFinderName: string, lobSystemInstance: LobSystemInstance): EntityInstance = jsNative
            member __.findFiltered(filterList: FilterCollection, nameOfFinder: string, lobSystemInstance: LobSystemInstance): EntityInstanceCollection = jsNative
            member __.findAssociated(entityInstance: EntityInstance, associationName: string, filterList: FilterCollection, lobSystemInstance: LobSystemInstance): EntityInstanceCollection = jsNative
            member __.getFilters(methodInstanceName: string): FilterCollection = jsNative
            member __.execute(methodInstanceName: string, lobSystemInstance: LobSystemInstance, inputParams: ResizeArray<obj>): MethodExecutionResult = jsNative
            member __.getAssociationView(associationName: string): EntityView = jsNative
            member __.create(fieldValues: EntityFieldValueDictionary, lobSystemInstance: LobSystemInstance): EntityIdentity = jsNative
            member __.subscribe(eventType: EntityEventType, notificationCallback: NotificationCallback, onBehalfOfUser: string, subscriberName: string, lobSystemInstance: LobSystemInstance): Subscription = jsNative
            member __.unsubscribe(subscription: Subscription, onBehalfOfUser: string, unsubscriberName: string, lobSystemInstance: LobSystemInstance): unit = jsNative *)

        and [<AllowNullLiteral>] [<Import("BusinessData.EntityField","SP")>] EntityField() =
            inherit ClientObject()
            member __.get_containsLocalizedDisplayName(): bool = jsNative
            member __.get_defaultDisplayName(): string = jsNative
            member __.get_localizedDisplayName(): string = jsNative
            member __.get_name(): string = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.EntityIdentifier","SP")>] EntityIdentifier() =
            inherit ClientObject()
            member __.get_identifierType(): string = jsNative
            member __.get_name(): string = jsNative
            member __.getDefaultDisplayName(): StringResult = jsNative
            member __.containsLocalizedDisplayName(): BooleanResult = jsNative
            member __.getLocalizedDisplayName(): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.EntityView","SP")>] EntityView() =
            inherit ClientObject()
            //member __.get_fields(): EntityFieldCollection = jsNative
            member __.get_name(): string = jsNative
            member __.get_relatedSpecificFinderName(): string = jsNative
            //member __.getDefaultValues(): EntityFieldValueDictionary = jsNative
            member __.getXmlSchema(): StringResult = jsNative
            member __.getTypeDescriptor(fieldDotNotation: string): TypeDescriptor = jsNative
            member __.getType(fieldDotNotation: string): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.Filter","SP")>] Filter() =
            inherit ClientObject()
            member __.get_defaultDisplayName(): string = jsNative
            member __.get_filterField(): string = jsNative
            member __.get_filterType(): string = jsNative
            member __.get_localizedDisplayName(): string = jsNative
            member __.get_name(): string = jsNative
            member __.get_valueCount(): float = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.LobSystem","SP")>] LobSystem() =
            inherit ClientObject()
            member __.get_name(): string = jsNative
            //member __.getLobSystemInstances(): LobSystemInstanceCollection = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.LobSystemInstance","SP")>] LobSystemInstance() =
            inherit ClientObject()
            member __.get_name(): string = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.MethodExecutionResult","SP")>] MethodExecutionResult() =
            inherit ClientObject()
            member __.get_returnParameterCollection(): ReturnParameterCollection = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.ReturnParameterCollection","SP")>] ReturnParameterCollection() = class end
            //inherit ClientObjectCollection<EntityFieldValueDictionary>()
            //member __.itemAt(index: float): EntityFieldValueDictionary = jsNative
            //member __.get_item(index: float): EntityFieldValueDictionary = jsNative

        and [<AllowNullLiteral>] [<Import("BusinessData.TypeDescriptor","SP")>] TypeDescriptor() =
            inherit ClientObject()
            member __.get_containsReadOnly(): bool = jsNative
            member __.get_isCollection(): bool = jsNative
            member __.get_isReadOnly(): bool = jsNative
            member __.get_name(): string = jsNative
            member __.get_typeName(): string = jsNative
            member __.containsLocalizedDisplayName(): BooleanResult = jsNative
            member __.getLocalizedDisplayName(): StringResult = jsNative
            member __.getDefaultDisplayName(): StringResult = jsNative
            member __.isRoot(): BooleanResult = jsNative
            member __.isLeaf(): BooleanResult = jsNative
            //member __.getChildTypeDescriptors(): TypeDescriptorCollection = jsNative
            member __.getParentTypeDescriptor(): TypeDescriptor = jsNative

        module Collections =
            type [<AllowNullLiteral>] [<Import("BusinessData.Collections.EntityFieldCollection","SP")>] EntityFieldCollection() =
                inherit ClientObjectCollection<EntityField>()
                member __.itemAt(index: float): EntityField = jsNative
                member __.get_item(index: float): EntityField = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Collections.EntityIdentifierCollection","SP")>] EntityIdentifierCollection() =
                inherit ClientObjectCollection<EntityIdentifier>()
                member __.itemAt(index: float): EntityIdentifier = jsNative
                member __.get_item(index: float): EntityIdentifier = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Collections.EntityInstanceCollection","SP")>] EntityInstanceCollection() = class end
                (*inherit ClientObjectCollection<EntityInstance>()
                member __.itemAt(index: float): EntityInstance = jsNative
                member __.get_item(index: float): EntityInstance = jsNative*)

            and [<AllowNullLiteral>] [<Import("BusinessData.Collections.FilterCollection","SP")>] FilterCollection() =
                inherit ClientObjectCollection<Filter>()
                member __.itemAt(index: float): Filter = jsNative
                member __.get_item(index: float): Filter = jsNative
                member __.setFilterValue(inputFilterName: string, valueIndex: float, value: obj): unit = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Collections.LobSystemInstanceCollection","SP")>] LobSystemInstanceCollection() =
                inherit ClientObjectCollection<LobSystemInstance>()
                member __.itemAt(index: float): LobSystemInstance = jsNative
                member __.get_item(index: float): LobSystemInstance = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Collections.TypeDescriptorCollection","SP")>] TypeDescriptorCollection() =
                inherit ClientObjectCollection<TypeDescriptor>()
                member __.itemAt(index: float): TypeDescriptor = jsNative
                member __.get_item(index: float): TypeDescriptor = jsNative



        module Infrastructure =
            type [<AllowNullLiteral>] [<Import("BusinessData.Infrastructure.ExternalSubscriptionStore","SP")>] ExternalSubscriptionStore(context: ClientRuntimeContext, web: Web) =
                inherit ClientObject()
                static member newObject(context: ClientRuntimeContext, web: Web): ExternalSubscriptionStore = jsNative
                member __.indexStore(): unit = jsNative



        module Runtime =
            type EntityEventType =
                | none = 0
                | itemAdded = 1
                | itemUpdated = 2
                | itemDeleted = 3

            and [<AllowNullLiteral>] [<Import("BusinessData.Runtime.EntityFieldValueDictionary","SP")>] EntityFieldValueDictionary() =
                inherit ClientObject()
                member __.get_fieldValues(): obj = jsNative
                member __.get_item(fieldName: string): obj = jsNative
                member __.set_item(fieldName: string, value: obj): unit = jsNative
                member __.refreshLoad(): unit = jsNative
                member __.fromXml(xml: string): unit = jsNative
                member __.toXml(): StringResult = jsNative
                member __.createInstance(fieldInstanceDotNotation: string, fieldDotNotation: string): unit = jsNative
                member __.createCollectionInstance(fieldDotNotation: string, size: float): unit = jsNative
                member __.getCollectionSize(fieldDotNotation: string): IntResult = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Runtime.EntityIdentity","SP")>] EntityIdentity(context: ClientRuntimeContext, identifierValues: ResizeArray<obj>) =
                inherit ClientObject()
                member __.get_fieldValues(): obj = jsNative
                member __.get_item(fieldName: string): obj = jsNative
                member __.get_identifierCount(): float = jsNative
                static member newObject(context: ClientRuntimeContext, identifierValues: ResizeArray<obj>): EntityIdentity = jsNative
                member __.refreshLoad(): unit = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Runtime.EntityInstance","SP")>] EntityInstance() =
                inherit ClientObject()
                member __.get_fieldValues(): obj = jsNative
                member __.get_item(fieldName: string): obj = jsNative
                member __.set_item(fieldName: string, value: obj): unit = jsNative
                member __.refreshLoad(): unit = jsNative
                member __.createInstance(fieldInstanceDotNotation: string, fieldDotNotation: string): unit = jsNative
                member __.createCollectionInstance(fieldDotNotation: string, size: float): unit = jsNative
                member __.getIdentity(): EntityIdentity = jsNative
                member __.deleteObject(): unit = jsNative
                member __.update(): unit = jsNative
                member __.fromXml(xml: string): unit = jsNative
                member __.toXml(): StringResult = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Runtime.NotificationCallback","SP")>] NotificationCallback(context: ClientRuntimeContext, notificationEndpoint: string) =
                inherit ClientObject()
                member __.get_notificationContext(): string = jsNative
                member __.set_notificationContext(value: string): unit = jsNative
                member __.get_notificationEndpoint(): string = jsNative
                member __.get_notificationForwarderType(): string = jsNative
                member __.set_notificationForwarderType(value: string): unit = jsNative
                static member newObject(context: ClientRuntimeContext, notificationEndpoint: string): NotificationCallback = jsNative

            and [<AllowNullLiteral>] [<Import("BusinessData.Runtime.Subscription","SP")>] Subscription(context: ClientRuntimeContext, id: obj, hash: string) =
                inherit ClientObject()
                member __.get_hash(): string = jsNative
                member __.get_iD(): obj = jsNative
                static member newObject(context: ClientRuntimeContext, id: obj, hash: string): Subscription = jsNative



    module Sharing =
        type [<AllowNullLiteral>] [<Import("Sharing.DocumentSharingManager","SP")>] DocumentSharingManager() =
            static member getRoleDefinition(context: ClientRuntimeContext, role: Role): RoleDefinition = jsNative
            static member isDocumentSharingEnabled(context: ClientRuntimeContext, list: List): BooleanResult = jsNative
            static member updateDocumentSharingInfo(context: ClientRuntimeContext, resourceAddress: string, userRoleAssignments: ResizeArray<UserRoleAssignment>, validateExistingPermissions: bool, additiveMode: bool, sendServerManagedNotification: bool, customMessage: string, includeAnonymousLinksInNotification: bool): ResizeArray<UserSharingResult> = jsNative

        and Role =
            | none = 0
            | view = 1
            | edit = 2
            | owner = 3

        and [<AllowNullLiteral>] [<Import("Sharing.UserRoleAssignment","SP")>] UserRoleAssignment() =
            inherit ClientValueObject()
            member __.get_role(): Role = jsNative
            member __.set_role(value: Role): unit = jsNative
            member __.get_userId(): string = jsNative
            member __.set_userId(value: string): unit = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Sharing.UserSharingResult","SP")>] UserSharingResult() =
            inherit ClientValueObject()
            member __.get_allowedRoles(): ResizeArray<Role> = jsNative
            member __.get_currentRole(): Role = jsNative
            member __.get_isUserKnown(): bool = jsNative
            member __.get_message(): string = jsNative
            member __.get_status(): bool = jsNative
            member __.get_user(): string = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative



    module Social =
        type SocialActorType =
            | user = 0
            | document = 1
            | site = 2
            | tag = 3

        and SocialActorTypes =
            | none = 0
            | users = 1
            | documents = 2
            | sites = 3
            | tags = 4
            | excludeContentWithoutFeeds = 5
            | all = 6

        and SocialAttachmentActionKind =
            | navigate = 0
            | adHocAction = 1

        and SocialAttachmentKind =
            | image = 0
            | video = 1
            | document = 2

        and SocialDataItemType =
            | user = 0
            | document = 1
            | site = 2
            | tag = 3
            | link = 4

        and SocialDataOverlayType =
            | link = 0
            | actors = 1

        and SocialFeedSortOrder =
            | byModifiedTime = 0
            | byCreatedTime = 1

        and SocialFeedType =
            | personal = 0
            | news = 1
            | timeline = 2
            | likes = 3
            | everyone = 4

        and SocialFeedAttributes =
            | none = 0
            | moreThreadsAvailable = 1

        and SocialPostAttributes =
            | none = 0
            | canLike = 1
            | canDelete = 2
            | useAuthorImage = 3
            | useSmallImage = 4
            | canFollowUp = 5

        and SocialPostDefinitionDataItemType =
            | text = 0
            | user = 1
            | document = 2
            | site = 3
            | tag = 4
            | link = 5

        and SocialPostType =
            | root = 0
            | reply = 1

        and SocialStatusCode =
            | OK = 0
            | invalidRequest = 1
            | accessDenied = 2
            | itemNotFound = 3
            | invalidOperation = 4
            | itemNotModified = 5
            | internalError = 6
            | cacheReadError = 7
            | cacheUpdateError = 8
            | personalSiteNotFound = 9
            | failedToCreatePersonalSite = 10
            | notAuthorizedToCreatePersonalSite = 11
            | cannotCreatePersonalSite = 12
            | limitReached = 13
            | attachmentError = 14
            | partialData = 15
            | featureDisabled = 16

        and SocialThreadAttributes =
            | none = 0
            | isDigest = 1
            | canReply = 2
            | canLock = 3
            | isLocked = 4
            | replyLimitReached = 5

        and SocialThreadType =
            | normal = 0
            | likeReference = 1
            | replyReference = 2
            | mentionReference = 3
            | tagReference = 4

        and [<AllowNullLiteral>] [<Import("Social.SocialActor","SP")>] SocialActor() =
            inherit ClientValueObject()
            member __.get_accountName(): string = jsNative
            member __.get_actorType(): SocialActorType = jsNative
            member __.get_canFollow(): bool = jsNative
            member __.get_contentUri(): string = jsNative
            member __.get_emailAddress(): string = jsNative
            member __.get_followedContentUri(): string = jsNative
            member __.get_id(): string = jsNative
            member __.get_imageUri(): string = jsNative
            member __.get_isFollowed(): bool = jsNative
            member __.get_libraryUri(): string = jsNative
            member __.get_name(): string = jsNative
            member __.get_personalSiteUri(): string = jsNative
            member __.get_status(): SocialStatusCode = jsNative
            member __.get_statusText(): string = jsNative
            member __.get_tagGuid(): string = jsNative
            member __.get_title(): string = jsNative
            member __.get_uri(): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialActorInfo","SP")>] SocialActorInfo() =
            inherit ClientValueObject()
            member __.get_accountName(): string = jsNative
            member __.set_accountName(value: string): string = jsNative
            member __.get_actorType(): SocialActorType = jsNative
            member __.set_actorType(value: SocialActorType): SocialActorType = jsNative
            member __.get_contentUri(): string = jsNative
            member __.set_contentUri(value: string): string = jsNative
            member __.get_id(): string = jsNative
            member __.set_id(value: string): string = jsNative
            member __.get_tagGuid(): string = jsNative
            member __.set_tagGuid(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialAttachment","SP")>] SocialAttachment() =
            inherit ClientValueObject()
            member __.get_attachmentKind(): SocialAttachmentKind = jsNative
            member __.set_attachmentKind(value: SocialAttachmentKind): SocialAttachmentKind = jsNative
            member __.get_clickAction(): SocialAttachmentAction = jsNative
            member __.set_clickAction(value: SocialAttachmentAction): SocialAttachmentAction = jsNative
            member __.get_contentUri(): string = jsNative
            member __.set_contentUri(value: string): string = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): string = jsNative
            member __.get_height(): float = jsNative
            member __.set_height(value: float): float = jsNative
            member __.get_length(): float = jsNative
            member __.set_length(value: float): float = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_previewUri(): string = jsNative
            member __.set_previewUri(value: string): string = jsNative
            member __.get_uri(): string = jsNative
            member __.set_uri(value: string): string = jsNative
            member __.get_width(): float = jsNative
            member __.set_width(value: float): float = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialAttachmentAction","SP")>] SocialAttachmentAction() =
            inherit ClientValueObject()
            member __.get_actionKind(): SocialAttachmentActionKind = jsNative
            member __.set_actionKind(value: SocialAttachmentActionKind): SocialAttachmentActionKind = jsNative
            member __.get_actionUri(): string = jsNative
            member __.set_actionUri(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialDataItem","SP")>] SocialDataItem() =
            inherit ClientValueObject()
            member __.get_accountName(): string = jsNative
            member __.set_accountName(value: string): string = jsNative
            member __.get_itemType(): SocialDataItemType = jsNative
            member __.set_itemType(value: SocialDataItemType): SocialDataItemType = jsNative
            member __.get_tagGuid(): string = jsNative
            member __.set_tagGuid(value: string): string = jsNative
            member __.get_text(): string = jsNative
            member __.set_text(value: string): string = jsNative
            member __.get_uri(): string = jsNative
            member __.set_uri(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialDataOverlay","SP")>] SocialDataOverlay() =
            inherit ClientValueObject()
            member __.get_actorIndexes(): ResizeArray<float> = jsNative
            member __.get_index(): float = jsNative
            member __.get_length(): float = jsNative
            member __.get_linkUri(): string = jsNative
            member __.get_overlayType(): SocialDataOverlayType = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialExceptionDetails","SP")>] SocialExceptionDetails() =
            inherit ClientValueObject()
            member __.get_internalErrorCode(): float = jsNative
            member __.get_internalMessage(): string = jsNative
            member __.get_internalStackTrace(): string = jsNative
            member __.get_internalTypeName(): string = jsNative
            member __.get_status(): SocialStatusCode = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialFeed","SP")>] SocialFeed() =
            inherit ClientValueObject()
            member __.get_attributes(): SocialFeedAttributes = jsNative
            member __.get_newestProcessed(): string = jsNative
            member __.get_oldestProcessed(): string = jsNative
            member __.get_threads(): ResizeArray<SocialThread> = jsNative
            member __.get_unreadMentionCount(): float = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialFeedManager","SP")>] SocialFeedManager(context: ClientRuntimeContext) =
            inherit ClientObject()
            member __.get_owner(): SocialActor = jsNative
            member __.get_personalSitePortalUri(): string = jsNative
            member __.createPost(targetId: string, creationData: SocialPostCreationData): SocialThread = jsNative
            member __.deletePost(postId: string): SocialThread = jsNative
            member __.getAllLikers(postId: string): ResizeArray<SocialActor> = jsNative
            member __.getFeed(``type``: SocialFeedType, options: SocialFeedOptions): SocialFeed = jsNative
            member __.getFeedFor(actorId: string, options: SocialFeedOptions): SocialFeed = jsNative
            member __.getFullThread(threadId: string): SocialThread = jsNative
            member __.getMentions(clearUnreadMentions: bool, options: SocialFeedOptions): SocialFeed = jsNative
            member __.getUnreadMentionCount(): IntResult = jsNative
            member __.likePost(postId: string): SocialThread = jsNative
            member __.unlikePost(postId: string): SocialThread = jsNative
            member __.lockThread(threadId: string): SocialThread = jsNative
            member __.unlockThread(threadId: string): SocialThread = jsNative
            member __.suppressThreadNotifications(threadId: string): unit = jsNative
            member __.createImageAttachment(name: string, description: string, imageData: obj): SocialAttachment = jsNative
            member __.getPreview(itemUrl: string): SocialAttachment = jsNative
            member __.getPreviewImage(url: string, key: string, iv: string): obj = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialFeedOptions","SP")>] SocialFeedOptions() =
            inherit ClientObject()
            member __.get_maxThreadCount(): float = jsNative
            member __.set_maxThreadCount(value: float): float = jsNative
            member __.get_newerThan(): string = jsNative
            member __.set_newerThan(value: string): string = jsNative
            member __.get_olderThan(): string = jsNative
            member __.set_olderThan(value: string): string = jsNative
            member __.get_sortOrder(): SocialFeedSortOrder = jsNative
            member __.set_sortOrder(value: SocialFeedSortOrder): SocialFeedSortOrder = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialFollowingManager","SP")>] SocialFollowingManager(context: ClientRuntimeContext) =
            inherit ClientObject()
            member __.get_followedDocumentsUri(): string = jsNative
            member __.get_followedSitesUri(): string = jsNative
            member __.follow(actor: SocialActorInfo): IntResult = jsNative
            member __.stopFollowing(actor: SocialActorInfo): BooleanResult = jsNative
            member __.isFollowed(actor: SocialActorInfo): BooleanResult = jsNative
            member __.getFollowed(types: SocialActorTypes): ResizeArray<SocialActor> = jsNative
            member __.getFollowedCount(types: SocialActorTypes): IntResult = jsNative
            member __.getFollowers(): ResizeArray<SocialActor> = jsNative
            member __.getSuggestions(): ResizeArray<SocialActor> = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialLink","SP")>] SocialLink() =
            inherit ClientValueObject()
            member __.get_text(): string = jsNative
            member __.set_text(value: string): string = jsNative
            member __.get_uri(): string = jsNative
            member __.set_uri(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialPost","SP")>] SocialPost() =
            inherit ClientValueObject()
            member __.get_attachment(): SocialAttachment = jsNative
            member __.get_attributes(): SocialPostAttributes = jsNative
            member __.get_authorIndex(): float = jsNative
            member __.get_createdTime(): string = jsNative
            member __.get_id(): string = jsNative
            member __.get_likerInfo(): SocialPostActorInfo = jsNative
            member __.get_modifiedTime(): string = jsNative
            member __.get_overlays(): ResizeArray<SocialDataOverlay> = jsNative
            member __.get_postType(): SocialPostType = jsNative
            member __.get_preferredImageUri(): string = jsNative
            member __.get_source(): SocialLink = jsNative
            member __.get_text(): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialPostActorInfo","SP")>] SocialPostActorInfo() =
            inherit ClientValueObject()
            member __.get_includesCurrentUser(): bool = jsNative
            member __.get_indexes(): ResizeArray<float> = jsNative
            member __.get_totalCount(): float = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialPostCreationData","SP")>] SocialPostCreationData() =
            inherit ClientValueObject()
            member __.get_attachment(): SocialAttachment = jsNative
            member __.set_attachment(value: SocialAttachment): SocialAttachment = jsNative
            member __.get_contentItems(): SocialDataItem = jsNative
            member __.set_contentItems(value: SocialDataItem): SocialDataItem = jsNative
            member __.get_contentText(): string = jsNative
            member __.set_contentText(value: string): string = jsNative
            member __.get_definitionData(): SocialPostDefinitionData = jsNative
            member __.set_definitionData(value: SocialPostDefinitionData): SocialPostDefinitionData = jsNative
            member __.get_source(): SocialLink = jsNative
            member __.set_source(value: SocialLink): SocialLink = jsNative
            member __.get_securityUris(): ResizeArray<string> = jsNative
            member __.set_securityUris(value: ResizeArray<string>): ResizeArray<string> = jsNative
            member __.get_updateStatusText(): bool = jsNative
            member __.set_updateStatusText(value: bool): bool = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialPostDefinitionData","SP")>] SocialPostDefinitionData() =
            inherit ClientValueObject()
            member __.get_items(): ResizeArray<SocialPostDefinitionDataItem> = jsNative
            member __.set_items(value: ResizeArray<SocialPostDefinitionDataItem>): ResizeArray<SocialPostDefinitionDataItem> = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialPostDefinitionDataItem","SP")>] SocialPostDefinitionDataItem() =
            inherit ClientValueObject()
            member __.get_accountName(): string = jsNative
            member __.set_accountName(value: string): string = jsNative
            member __.get_itemType(): SocialPostDefinitionDataItemType = jsNative
            member __.set_itemType(value: SocialPostDefinitionDataItemType): SocialPostDefinitionDataItemType = jsNative
            member __.get_placeholderName(): string = jsNative
            member __.set_placeholderName(value: string): string = jsNative
            member __.get_tagGuid(): string = jsNative
            member __.set_tagGuid(value: string): string = jsNative
            member __.get_text(): string = jsNative
            member __.set_text(value: string): string = jsNative
            member __.get_uri(): string = jsNative
            member __.set_uri(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialPostReference","SP")>] SocialPostReference() =
            inherit ClientValueObject()
            member __.get_digest(): SocialThread = jsNative
            member __.get_post(): SocialPost = jsNative
            member __.get_threadId(): string = jsNative
            member __.get_threadOwnerIndex(): float = jsNative

        and [<AllowNullLiteral>] [<Import("Social.SocialThread","SP")>] SocialThread() =
            inherit ClientValueObject()
            member __.get_actors(): ResizeArray<SocialActor> = jsNative
            member __.get_attributes(): SocialThreadAttributes = jsNative
            member __.get_id(): string = jsNative
            member __.get_ownerIndex(): float = jsNative
            member __.get_permalink(): string = jsNative
            member __.get_postReference(): SocialPostReference = jsNative
            member __.get_replies(): ResizeArray<SocialPost> = jsNative
            member __.get_rootPost(): SocialPost = jsNative
            member __.get_status(): SocialStatusCode = jsNative
            member __.get_threadType(): SocialThreadType = jsNative
            member __.get_totalReplyCount(): float = jsNative



    module Taxonomy =
        type StringMatchOption =
            | startsWith = 0
            | exactMatch = 1

        and ChangeItemType =
            | unknown = 0
            | term = 1
            | termSet = 2
            | group = 3
            | termStore = 4
            | site = 5

        and ChangeOperationType =
            | unknown = 0
            | add = 1
            | edit = 2
            | deleteObject = 3
            | move = 4
            | copy = 5
            | pathChange = 6
            | merge = 7
            | importObject = 8
            | restore = 9

        and [<AllowNullLiteral>] [<Import("Taxonomy.TaxonomySession","SP")>] TaxonomySession() =
            inherit ClientObject()
            static member getTaxonomySession(context: ClientContext): TaxonomySession = jsNative
            member __.get_offlineTermStoreNames(): ResizeArray<string> = jsNative
            member __.get_termStores(): TermStoreCollection = jsNative
            member __.getTerms(labelMatchInformation: LabelMatchInformation): TermCollection = jsNative
            member __.updateCache(): unit = jsNative
            member __.getTerm(guid: Guid): Term = jsNative
            member __.getTermsById(termIds: ResizeArray<Guid>): TermCollection = jsNative
            member __.getTermsInDefaultLanguage(termLabel: string, defaultLabelOnly: bool, stringMatchOption: StringMatchOption, resultCollectionSize: float, trimUnavailable: bool, trimDeprecated: bool): TermCollection = jsNative
            member __.getTermsInWorkingLocale(termLabel: string, defaultLabelOnly: bool, stringMatchOption: StringMatchOption, resultCollectionSize: float, trimUnavailable: bool, trimDeprecated: bool): TermCollection = jsNative
            member __.getTermsWithCustomProperty(customPropertyName: string, trimUnavailable: bool): TermCollection = jsNative
            member __.getTermsWithCustomProperty(customPropertyMatchInformation: CustomPropertyMatchInformation): TermCollection = jsNative
            member __.getTermSetsByName(termSetName: string, lcid: float): TermSetCollection = jsNative
            member __.getTermSetsByTermLabel(requiredTermLabels: ResizeArray<string>, lcid: float): TermSetCollection = jsNative
            member __.getDefaultKeywordsTermStore(): TermStore = jsNative
            member __.getDefaultSiteCollectionTermStore(): TermStore = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermStoreCollection","SP")>] TermStoreCollection() =
            inherit ClientObjectCollection<TermStore>()
            member __.itemAt(index: float): TermStore = jsNative
            member __.get_item(index: float): TermStore = jsNative
            member __.getById(id: Guid): TermStore = jsNative
            member __.getByName(name: string): TermStore = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermStore","SP")>] TermStore() =
            inherit ClientObject()
            member __.get_contentTypePublishingHub(): string = jsNative
            member __.get_defaultLanguage(): float = jsNative
            member __.set_defaultLanguage(value: float): unit = jsNative
            member __.get_groups(): TermGroupCollection = jsNative
            member __.get_hashTagsTermSet(): TermSet = jsNative
            member __.get_id(): Guid = jsNative
            member __.get_isOnline(): bool = jsNative
            member __.get_keywordsTermSet(): TermSet = jsNative
            member __.get_languages(): ResizeArray<float> = jsNative
            member __.get_name(): string = jsNative
            member __.get_orphanedTermsTermSet(): TermSet = jsNative
            member __.get_systemGroup(): TermGroup = jsNative
            member __.get_workingLanguage(): float = jsNative
            member __.set_workingLanguage(value: float): unit = jsNative
            member __.addLanguage(lcid: float): unit = jsNative
            member __.commitAll(): unit = jsNative
            member __.createGroup(name: string): TermGroup = jsNative
            member __.createGroup(name: string, groupId: Guid): TermGroup = jsNative
            member __.deleteLanguage(lcid: float): unit = jsNative
            member __.getChanges(changeInformation: ChangeInformation): ChangedItemCollection = jsNative
            member __.getGroup(id: Guid): TermGroup = jsNative
            member __.getTerm(termId: Guid): Term = jsNative
            member __.getTermInTermSet(termSetId: Guid, termId: Guid): Term = jsNative
            member __.getTermsById(termIds: ResizeArray<Guid>): TermCollection = jsNative
            member __.getTerms(termLabel: string, trimUnavailable: bool): TermCollection = jsNative
            member __.getTerms(labelMatchInformation: LabelMatchInformation): TermCollection = jsNative
            member __.getTermSetsByName(termSetName: string, lcid: float): TermSetCollection = jsNative
            member __.getTermSetsByTermLabel(requiredTermLabels: ResizeArray<string>, lcid: float): TermSetCollection = jsNative
            member __.getTermsWithCustomProperty(customPropertyName: string, trimUnavailable: bool): TermCollection = jsNative
            member __.getTermsWithCustomProperty(customPropertyMatchInformation: CustomPropertyMatchInformation): TermCollection = jsNative
            member __.getTermSet(termSetId: Guid): TermSet = jsNative
            member __.getTermSetsWithCustomProperty(customPropertyMatchInformation: CustomPropertyMatchInformation): TermSetCollection = jsNative
            member __.rollbackAll(): unit = jsNative
            member __.updateCache(): unit = jsNative
            member __.getSiteCollectionGroup(currentSite: Site, createIfMissing: bool): TermGroup = jsNative
            member __.updateUsedTermsOnSite(currentSite: Site): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TaxonomyItem","SP")>] TaxonomyItem() =
            inherit ClientObject()
            static member normalizeName(context: ClientContext, name: string): StringResult = jsNative
            member __.get_createdDate(): DateTime = jsNative
            member __.get_id(): Guid = jsNative
            member __.get_lastModifiedDate(): DateTime = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): unit = jsNative
            member __.get_termStore(): TermStore = jsNative
            member __.deleteObject(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermGroupCollection","SP")>] TermGroupCollection() =
            inherit ClientObjectCollection<TermGroup>()
            member __.itemAt(index: float): TermGroup = jsNative
            member __.get_item(index: float): TermGroup = jsNative
            member __.getById(id: Guid): TermGroup = jsNative
            member __.getByName(name: string): TermGroup = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermGroup","SP")>] TermGroup() =
            inherit TaxonomyItem()
            member __.get_description(): string = jsNative
            member __.set_description(value: string): unit = jsNative
            member __.get_isSiteCollectionGroup(): bool = jsNative
            member __.get_isSystemGroup(): bool = jsNative
            member __.get_termSets(): TermSetCollection = jsNative
            member __.createTermSet(name: string, newTermSetId: Guid, lcid: float): TermSet = jsNative
            member __.exportObject(): StringResult = jsNative
            member __.getChanges(changeInformation: ChangeInformation): ChangedItemCollection = jsNative
            member __.getTermSetsWithCustomProperty(customPropertyMatchInformation: CustomPropertyMatchInformation): TermSetCollection = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermSetItem","SP")>] TermSetItem() =
            inherit TaxonomyItem()
            member __.get_customProperties(): obj = jsNative
            member __.get_customSortOrder(): string = jsNative
            member __.set_customSortOrder(value: string): unit = jsNative
            member __.get_isAvailableForTagging(): bool = jsNative
            member __.set_isAvailableForTagging(value: bool): unit = jsNative
            member __.get_owner(): string = jsNative
            member __.set_owner(value: string): unit = jsNative
            member __.get_terms(): TermCollection = jsNative
            member __.createTerm(name: string, lcid: float, newTermId: Guid): Term = jsNative
            member __.reuseTerm(sourceTerm: Term, reuseBranch: bool): Term = jsNative
            member __.reuseTermWithPinning(sourceTerm: Term): Term = jsNative
            member __.deleteCustomProperty(name: string): unit = jsNative
            member __.deleteAllCustomProperties(): unit = jsNative
            member __.setCustomProperty(name: string, value: string): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermSetCollection","SP")>] TermSetCollection() =
            inherit ClientObjectCollection<TermSet>()
            member __.itemAt(index: float): TermSet = jsNative
            member __.get_item(index: float): TermSet = jsNative
            member __.getById(id: Guid): TermSet = jsNative
            member __.getByName(name: string): TermSet = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermSet","SP")>] TermSet() =
            inherit TermSetItem()
            member __.get_contact(): string = jsNative
            member __.set_contact(value: string): unit = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): unit = jsNative
            member __.get_group(): TermGroup = jsNative
            member __.get_isOpenForTermCreation(): bool = jsNative
            member __.set_isOpenForTermCreation(value: bool): unit = jsNative
            member __.get_stakeholders(): ResizeArray<string> = jsNative
            member __.addStakeholder(stakeholderName: string): unit = jsNative
            member __.copy(): TermSet = jsNative
            member __.deleteStakeholder(stakeholderName: string): unit = jsNative
            member __.exportObject(): StringResult = jsNative
            member __.getAllTerms(): TermCollection = jsNative
            member __.getChanges(changeInformation: ChangeInformation): ChangedItemCollection = jsNative
            member __.getTerm(termId: Guid): Term = jsNative
            member __.getTerms(pagingLimit: float): TermCollection = jsNative
            member __.getTerms(termLabel: string, trimUnavailable: bool): TermCollection = jsNative
            member __.getTerms(labelMatchInformation: LabelMatchInformation): TermCollection = jsNative
            member __.getTermsWithCustomProperty(customPropertyName: string, trimUnavailable: bool): TermCollection = jsNative
            member __.getTermsWithCustomProperty(customPropertyMatchInformation: CustomPropertyMatchInformation): TermCollection = jsNative
            member __.move(targetGroup: TermGroup): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TermCollection","SP")>] TermCollection() =
            inherit ClientObjectCollection<Term>()
            member __.itemAt(index: float): Term = jsNative
            member __.get_item(index: float): Term = jsNative
            member __.getById(id: Guid): Term = jsNative
            member __.getByName(name: string): Term = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.Term","SP")>] Term() =
            inherit TermSetItem()
            member __.get_description(): string = jsNative
            member __.get_isDeprecated(): bool = jsNative
            member __.get_isKeyword(): bool = jsNative
            member __.get_isPinned(): bool = jsNative
            member __.get_isPinnedRoot(): bool = jsNative
            member __.get_isReused(): bool = jsNative
            member __.get_isRoot(): bool = jsNative
            member __.get_isSourceTerm(): bool = jsNative
            member __.get_labels(): LabelCollection = jsNative
            member __.get_localCustomProperties(): obj = jsNative
            member __.get_mergedTermIds(): ResizeArray<Guid> = jsNative
            member __.get_parent(): Term = jsNative
            member __.get_pathOfTerm(): string = jsNative
            member __.get_pinSourceTermSet(): TermSet = jsNative
            member __.get_reusedTerms(): TermCollection = jsNative
            member __.get_sourceTerm(): Term = jsNative
            member __.get_termsCount(): float = jsNative
            member __.get_termSet(): TermSet = jsNative
            member __.get_termSets(): TermSetCollection = jsNative
            member __.copy(doCopyChildren: bool): Term = jsNative
            member __.createLabel(labelName: string, lcid: float, isDefault: bool): Label = jsNative
            member __.deleteLocalCustomProperty(name: string): unit = jsNative
            member __.deleteAllLocalCustomProperties(): unit = jsNative
            member __.deprecate(doDepricate: bool): unit = jsNative
            member __.getAllLabels(lcid: float): LabelCollection = jsNative
            member __.getDefaultLabel(lcid: float): Label = jsNative
            member __.getDescription(lcid: float): StringResult = jsNative
            member __.getTerms(pagingLimit: float): TermCollection = jsNative
            member __.getTerms(termLabel: string, lcid: float, defaultLabelOnly: bool, stringMatchOption: StringMatchOption, resultCollectionSize: float, trimUnavailable: bool): TermCollection = jsNative
            member __.merge(termToMerge: Term): unit = jsNative
            member __.move(newParnt: TermSetItem): unit = jsNative
            member __.reassignSourceTerm(reusedTerm: Term): unit = jsNative
            member __.setDescription(description: string, lcid: float): unit = jsNative
            member __.setLocalCustomProperty(name: string, value: string): unit = jsNative
            member __.getIsDescendantOf(ancestorTerm: Term): BooleanResult = jsNative
            member __.getPath(lcid: float): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.LabelCollection","SP")>] LabelCollection() =
            inherit ClientObjectCollection<Label>()
            member __.itemAt(index: float): Label = jsNative
            member __.get_item(index: float): Label = jsNative
            member __.getByValue(name: string): Label = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.Label","SP")>] Label() =
            inherit ClientObject()
            member __.get_isDefaultForLanguage(): bool = jsNative
            member __.get_language(): float = jsNative
            member __.set_language(value: float): unit = jsNative
            member __.get_term(): Term = jsNative
            member __.get_value(): string = jsNative
            member __.set_value(value: string): unit = jsNative
            member __.deleteObject(): unit = jsNative
            member __.setAsDefaultForLanguage(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.LabelMatchInformation","SP")>] LabelMatchInformation(context: ClientContext) =
            inherit ClientObject()
            member __.get_defaultLabelOnly(): bool = jsNative
            member __.set_defaultLabelOnly(value: bool): unit = jsNative
            member __.get_excludeKeyword(): bool = jsNative
            member __.set_excludeKeyword(value: bool): unit = jsNative
            member __.get_lcid(): float = jsNative
            member __.set_lcid(value: float): unit = jsNative
            member __.get_resultCollectionSize(): float = jsNative
            member __.set_resultCollectionSize(value: float): unit = jsNative
            member __.get_stringMatchOption(): StringMatchOption = jsNative
            member __.set_stringMatchOption(value: StringMatchOption): unit = jsNative
            member __.get_termLabel(): string = jsNative
            member __.set_termLabel(value: string): unit = jsNative
            member __.get_trimDeprecated(): bool = jsNative
            member __.set_trimDeprecated(value: bool): unit = jsNative
            member __.get_trimUnavailable(): bool = jsNative
            member __.set_trimUnavailable(value: bool): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.CustomPropertyMatchInformation","SP")>] CustomPropertyMatchInformation(context: ClientContext) =
            inherit ClientObject()
            member __.get_customPropertyName(): string = jsNative
            member __.set_customPropertyName(value: string): unit = jsNative
            member __.get_customPropertyValue(): string = jsNative
            member __.set_customPropertyValue(value: string): unit = jsNative
            member __.get_resultCollectionSize(): float = jsNative
            member __.set_resultCollectionSize(value: float): unit = jsNative
            member __.get_stringMatchOption(): StringMatchOption = jsNative
            member __.set_stringMatchOption(value: StringMatchOption): unit = jsNative
            member __.get_trimUnavailable(): bool = jsNative
            member __.set_trimUnavailable(value: bool): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangeInformation","SP")>] ChangeInformation(context: ClientContext) =
            inherit ClientObject()
            member __.get_itemType(): ChangeItemType = jsNative
            member __.set_itemType(value: ChangeItemType): unit = jsNative
            member __.get_operationType(): ChangeOperationType = jsNative
            member __.set_operationType(value: ChangeOperationType): unit = jsNative
            member __.get_startTime(): DateTime = jsNative
            member __.set_startTime(value: DateTime): unit = jsNative
            member __.get_withinTimeSpan(): float = jsNative
            member __.set_withinTimeSpan(value: float): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedItemCollection","SP")>] ChangedItemCollection() =
            inherit ClientObjectCollection<ChangedItem>()
            member __.itemAt(index: float): ChangedItem = jsNative
            member __.get_item(index: float): ChangedItem = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedItem","SP")>] ChangedItem() =
            inherit ClientObject()
            member __.get_changedBy(): string = jsNative
            member __.get_changedTime(): DateTime = jsNative
            member __.get_id(): Guid = jsNative
            member __.get_itemType(): ChangeItemType = jsNative
            member __.get_operation(): ChangeOperationType = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedSite","SP")>] ChangedSite() =
            inherit ChangedItem()
            member __.get_siteId(): Guid = jsNative
            member __.get_termId(): Guid = jsNative
            member __.get_termSetId(): Guid = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedGroup","SP")>] ChangedGroup() =
            inherit ChangedItem()


        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedTerm","SP")>] ChangedTerm() =
            inherit ChangedItem()
            member __.get_changedCustomProperties(): ResizeArray<string> = jsNative
            member __.get_changedLocalCustomProperties(): ResizeArray<string> = jsNative
            member __.get_groupId(): Guid = jsNative
            member __.get_lcidsForChangedDescriptions(): ResizeArray<float> = jsNative
            member __.get_lcidsForChangedLabels(): ResizeArray<float> = jsNative
            member __.get_termSetId(): Guid = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedTermSet","SP")>] ChangedTermSet() =
            inherit ChangedItem()
            member __.get_fromGroupId(): Guid = jsNative
            member __.get_groupId(): Guid = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.ChangedTermStore","SP")>] ChangedTermStore() =
            inherit ChangedItem()
            member __.get_changedLanguage(): float = jsNative
            member __.get_isDefaultLanguageChanged(): bool = jsNative
            member __.get_isFullFarmRestore(): bool = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TaxonomyField","SP")>] TaxonomyField(context: ClientContext, fields: FieldCollection, filedName: string) =
            inherit FieldLookup()
            member __.get_anchorId(): Guid = jsNative
            member __.set_anchorId(value: Guid): unit = jsNative
            member __.get_createValuesInEditForm(): bool = jsNative
            member __.set_createValuesInEditForm(value: bool): unit = jsNative
            member __.get_isAnchorValid(): bool = jsNative
            member __.get_isKeyword(): bool = jsNative
            member __.set_isKeyword(value: bool): unit = jsNative
            member __.get_isPathRendered(): bool = jsNative
            member __.set_isPathRendered(value: bool): unit = jsNative
            member __.get_isTermSetValid(): bool = jsNative
            member __.get_open(): bool = jsNative
            member __.set_open(value: bool): unit = jsNative
            member __.get_sspId(): Guid = jsNative
            member __.set_sspId(value: Guid): unit = jsNative
            member __.get_targetTemplate(): string = jsNative
            member __.set_targetTemplate(value: string): unit = jsNative
            member __.get_termSetId(): Guid = jsNative
            member __.set_termSetId(value: Guid): unit = jsNative
            member __.get_textField(): Guid = jsNative
            member __.get_userCreated(): Guid = jsNative
            member __.set_userCreated(value: Guid): unit = jsNative
            member __.getFieldValueAsText(value: TaxonomyFieldValue): StringResult = jsNative
            member __.getFieldValueAsTaxonomyFieldValue(value: string): TaxonomyFieldValue = jsNative
            member __.getFieldValueAsTaxonomyFieldValueCollection(value: string): TaxonomyFieldValueCollection = jsNative
            member __.setFieldValueByTerm(listItem: ListItem, term: Term, lcid: float): unit = jsNative
            member __.setFieldValueByTermCollection(listItem: ListItem, terms: TermCollection, lcid: float): unit = jsNative
            member __.setFieldValueByCollection(listItem: ListItem, terms: ResizeArray<Term>, lcid: float): unit = jsNative
            member __.setFieldValueByValue(listItem: ListItem, taxValue: TaxonomyFieldValue): unit = jsNative
            member __.setFieldValueByValueCollection(listItem: ListItem, taxValueCollection: TaxonomyFieldValueCollection): unit = jsNative
            member __.getFieldValueAsHtml(value: TaxonomyFieldValue): StringResult = jsNative
            member __.getValidatedString(value: TaxonomyFieldValue): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TaxonomyFieldValueCollection","SP")>] TaxonomyFieldValueCollection(context: ClientContext, fieldValue: string, creatingField: Field) =
            inherit ClientObjectCollection<TaxonomyFieldValue>()
            member __.itemAt(index: float): TaxonomyFieldValue = jsNative
            member __.get_item(index: float): TaxonomyFieldValue = jsNative
            member __.populateFromLabelGuidPairs(text: string): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.TaxonomyFieldValue","SP")>] TaxonomyFieldValue() =
            inherit ClientValueObject()
            member __.get_label(): string = jsNative
            member __.set_label(value: string): unit = jsNative
            member __.get_termGuid(): Guid = jsNative
            member __.set_termGuid(value: Guid): unit = jsNative
            member __.get_wssId(): float = jsNative
            member __.set_wssId(value: float): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Taxonomy.MobileTaxonomyField","SP")>] MobileTaxonomyField() =
            inherit ClientObject()
            member __.get_readOnly(): bool = jsNative



    module DocumentSet =
        type [<AllowNullLiteral>] [<Import("DocumentSet.DocumentSet","SP")>] DocumentSet() =
            ////interface ClientObject
            static member create(context: ClientContext, parentFolder: Folder, name: string, ctid: ContentTypeId): StringResult = jsNative



    module Video =
        type [<AllowNullLiteral>] [<Import("Video.EmbedCodeConfiguration","SP")>] EmbedCodeConfiguration() =
            ////interface ClientValueObject
            member __.get_autoPlay(): bool = jsNative
            member __.set_autoPlay(value: bool): bool = jsNative
            member __.get_displayTitle(): bool = jsNative
            member __.set_displayTitle(value: bool): bool = jsNative
            member __.get_linkToOwnerProfilePage(): bool = jsNative
            member __.set_linkToOwnerProfilePage(value: bool): bool = jsNative
            member __.get_linkToVideoHomePage(): bool = jsNative
            member __.set_linkToVideoHomePage(value: bool): bool = jsNative
            member __.get_loop(): bool = jsNative
            member __.set_loop(value: bool): bool = jsNative
            member __.get_pixelHeight(): float = jsNative
            member __.set_pixelHeight(value: float): float = jsNative
            member __.get_pixelWidth(): float = jsNative
            member __.set_pixelWidth(value: float): float = jsNative
            member __.get_startTime(): float = jsNative
            member __.set_startTime(value: float): float = jsNative
            member __.get_previewImagePath(): string = jsNative
            member __.set_previewImagePath(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Video.VideoSet","SP")>] VideoSet() =
            //interface DocumentSet.DocumentSet
            static member createVideo(context: ClientContext, parentFolder: Folder, name: string, ctid: ContentTypeId): StringResult = jsNative
            static member uploadVideo(context: ClientContext, list: List, fileName: string, file: ResizeArray<obj>, overwriteIfExists: bool, parentFolderPath: string): StringResult = jsNative
            static member getEmbedCode(context: ClientContext, videoPath: string, properties: EmbedCodeConfiguration): StringResult = jsNative
            static member migrateVideo(context: ClientContext, videoFile: File): ListItem = jsNative



    module UI =
        module ApplicationPages =
            type [<AllowNullLiteral>] [<Import("UI.ApplicationPages.SelectorSelectionEventArgs","SP")>] SelectorSelectionEventArgs(entities: obj) =
                //interface Sys.EventArgs
                member __.get_entities(): obj = jsNative

            and [<AllowNullLiteral>] ISelectorComponent =
                abstract get_selectedEntities: unit -> obj
                abstract set_selectedEntities: value: obj -> unit
                //abstract get_callback: unit -> Func<obj, Sys.EventArgs, unit>
                //abstract set_callback: value: Func<obj, Sys.EventArgs, unit> -> unit
                abstract get_scopeKey: unit -> string
                abstract get_componentType: unit -> SelectorType
                abstract revertTo: ent: ResolveEntity -> unit
                abstract removeEntity: ent: ResolveEntity -> unit
                abstract setEntity: ent: ResolveEntity -> unit

            and SelectorType =
                | none = 0
                | resource = 1
                | people = 2
                | people_And_Resource = 3
                | event = 4

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.CalendarSelector","SP")>] CalendarSelector() =
                //interface Sys.Component
                static member instance(): CalendarSelector = jsNative
                member __.registerSelector(selector: ISelectorComponent): unit = jsNative
                member __.getSelector(``type``: SelectorType, scopeKey: string): ISelectorComponent = jsNative
                member __.addHandler(scopeKey: string, people: bool, resource: bool, handler: Func<obj, SelectorSelectionEventArgs, unit>): unit = jsNative
                member __.revertTo(scopeKey: string, ent: ResolveEntity): unit = jsNative
                member __.removeEntity(scopeKey: string, ent: ResolveEntity): unit = jsNative

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.BaseSelectorComponent","SP")>] BaseSelectorComponent(key: string, ``type``: SelectorType) =
                interface ISelectorComponent with
                member __.get_scopeKey(): string = jsNative
                member __.get_componentType(): SelectorType = jsNative
                member __.get_selectedEntities(): obj = jsNative
                member __.set_selectedEntities(value: obj): unit = jsNative
                //member __.get_callback(): Func<obj, Sys.EventArgs, unit> = jsNative
                //member __.set_callback(value: Func<obj, Sys.EventArgs, unit>): unit = jsNative
                member __.revertTo(ent: ResolveEntity): unit = jsNative
                member __.removeEntity(ent: ResolveEntity): unit = jsNative
                member __.setEntity(ent: ResolveEntity): unit = jsNative

            and [<AllowNullLiteral>] ICalendarController =
                abstract moveToDate: date: string -> unit
                abstract moveToViewType: viewType: string -> unit
                abstract moveToViewDate: scope: CalendarScope * date: string -> unit
                abstract moveToView: scope: CalendarScope -> unit
                abstract expandAll: unit -> unit
                abstract collapseAll: unit -> unit
                abstract refreshItems: unit -> unit
                abstract getActiveScope: unit -> CalendarScope
                abstract newItemDialog: contentTypeId: string -> unit
                abstract deleteItem: itemId: string -> unit

            and CalendarScope =
                | nothing = 0
                | monthly = 1
                | weeklyGroup = 2
                | daily = 3
                | weekly = 4
                | dailyGroup = 5

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.CalendarInstanceRepository","SP")>] CalendarInstanceRepository() =
                static member registerInstance(instanceId: string, contoller: ICalendarController): unit = jsNative
                static member lookupInstance(instanceId: string): ICalendarController = jsNative
                static member firstInstance(): ICalendarController = jsNative

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.ResolveEntity","SP")>] ResolveEntity() =
                member __.tYPE_EVENT with get(): string = jsNative and set(v: string): unit = jsNative
                member __.tYPE_USER with get(): string = jsNative and set(v: string): unit = jsNative
                member __.tYPE_RESOURCE with get(): string = jsNative and set(v: string): unit = jsNative
                member __.tYPE_EXCHANGE with get(): string = jsNative and set(v: string): unit = jsNative
                member __.entityType with get(): string = jsNative and set(v: string): unit = jsNative
                member __.displayName with get(): string = jsNative and set(v: string): unit = jsNative
                member __.email with get(): string = jsNative and set(v: string): unit = jsNative
                member __.accountName with get(): string = jsNative and set(v: string): unit = jsNative
                member __.id with get(): string = jsNative and set(v: string): unit = jsNative
                member __.members with get(): ResizeArray<ResolveEntity> = jsNative and set(v: ResizeArray<ResolveEntity>): unit = jsNative
                member __.needResolve with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.isGroup with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.get_key(): string = jsNative

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.ClientPeoplePickerQueryParameters","SP")>] ClientPeoplePickerQueryParameters() =
                inherit ClientValueObject()
                member __.get_allowEmailAddresses(): bool = jsNative
                member __.set_allowEmailAddresses(value: bool): unit = jsNative
                member __.get_allowMultipleEntities(): bool = jsNative
                member __.set_allowMultipleEntities(value: bool): unit = jsNative
                member __.get_allUrlZones(): bool = jsNative
                member __.set_allUrlZones(value: bool): unit = jsNative
                member __.get_enabledClaimProviders(): string = jsNative
                member __.set_enabledClaimProviders(value: string): unit = jsNative
                member __.get_forceClaims(): bool = jsNative
                member __.set_forceClaims(value: bool): unit = jsNative
                member __.get_maximumEntitySuggestions(): float = jsNative
                member __.set_maximumEntitySuggestions(value: float): unit = jsNative
                (*member __.get_principalSource(): PrincipalSource = jsNative
                member __.set_principalSource(value: PrincipalSource): unit = jsNative
                member __.get_principalType(): PrincipalType = jsNative
                member __.set_principalType(value: PrincipalType): unit = jsNative *)
                member __.get_queryString(): string = jsNative
                member __.set_queryString(value: string): unit = jsNative
                member __.get_required(): bool = jsNative
                member __.set_required(value: bool): unit = jsNative
                member __.get_sharePointGroupID(): float = jsNative
                member __.set_sharePointGroupID(value: float): unit = jsNative
                member __.get_urlZone(): UrlZone = jsNative
                member __.set_urlZone(value: UrlZone): unit = jsNative
                member __.get_urlZoneSpecified(): bool = jsNative
                member __.set_urlZoneSpecified(value: bool): unit = jsNative
                member __.get_web(): Web = jsNative
                member __.set_web(value: Web): unit = jsNative
                member __.get_webApplicationID(): Guid = jsNative
                member __.set_webApplicationID(value: Guid): unit = jsNative
                member __.get_typeId(): string = jsNative
                member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.ClientPeoplePickerWebServiceInterface","SP")>] ClientPeoplePickerWebServiceInterface() =
                static member clientPeoplePickerSearchUser(context: ClientRuntimeContext, queryParams: ClientPeoplePickerQueryParameters): StringResult = jsNative
                static member clientPeoplePickerResolveUser(context: ClientRuntimeContext, queryParams: ClientPeoplePickerQueryParameters): StringResult = jsNative

            and [<AllowNullLiteral>] [<Import("UI.ApplicationPages.PeoplePickerWebServiceInterface","SP")>] PeoplePickerWebServiceInterface() =
                static member getSearchResultsByHierarchy(context: ClientRuntimeContext, providerID: string, hierarchyNodeID: string, entityTypes: string, contextUrl: string): StringResult = jsNative
                static member getSearchResults(context: ClientRuntimeContext, searchPattern: string, providerID: string, hierarchyNodeID: string, entityTypes: string): StringResult = jsNative



        type [<AllowNullLiteral>] [<Import("UI.PopoutMenu","SP")>] PopoutMenu(launcherId: string, menuId: string, iconId: string, launcherOpenCssClass: string, textDirection: string, closeIconUrl: string, isClustered: bool, closeIconOffsetLeft: float, closeIconOffsetTop: float, closeIconHeight: float, closeIconWidth: float) =
            //interface Sys.IDisposable
            member __.launchMenu(): unit = jsNative
            member __.closeMenu(): unit = jsNative
            static member createPopoutMenuInstanceAndLaunch(anchorId: string, menuId: string, iconId: string, anchorOpenCss: string, textDirection: string, closeIconUrl: string, isClustered: bool, x: float, y: float, height: float, width: float): unit = jsNative
            static member closeActivePopoutMenuInstance(): unit = jsNative
            member __.dispose(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UI.AttractModeControl","SP")>] AttractModeControl() =
            //interface Control
            member __.defaultAttractModeIcon with get(): string = jsNative and set(v: string): unit = jsNative
            member __.cssAttractMode with get(): string = jsNative and set(v: string): unit = jsNative
            member __.cssAttractModeBackground with get(): string = jsNative and set(v: string): unit = jsNative
            member __.cssAttractModeCell with get(): string = jsNative and set(v: string): unit = jsNative
            member __.cssAttractModeWrapper with get(): string = jsNative and set(v: string): unit = jsNative
            member __.cssAttractModeIcon with get(): string = jsNative and set(v: string): unit = jsNative
            member __.cssAttractModeText with get(): string = jsNative and set(v: string): unit = jsNative
            member __.get_imageElement(): obj = jsNative
            member __.get_textElement(): HTMLElement = jsNative

        and [<AllowNullLiteral>] [<Import("UI.Status","SP")>] Status() =
            static member addStatus(strTitle: string, ?strHtml: string, ?atBegining: bool): string = jsNative
            static member appendStatus(sid: string, strTitle: string, strHtml: string): string = jsNative
            static member updateStatus(sid: string, strHtml: string): unit = jsNative
            static member setStatusPriColor(sid: string, strColor: string): unit = jsNative
            static member removeStatus(sid: string): unit = jsNative
            static member removeAllStatus(hide: bool): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UI.Menu","SP")>] Menu() =
            static member create(id: string): Menu = jsNative
            member __.addMenuItem(text: string, actionScriptText: string, imageSourceUrl: string, imageAlternateText: string, sequenceNumber: float, description: string, id: string): HTMLElement = jsNative
            member __.addSeparator(): unit = jsNative
            member __.addSubMenu(text: string, imageSourceUrl: string, imageAlternateText: string, sequenceNumber: float, description: string, id: string): Menu = jsNative
            member __.show(relativeElement: HTMLElement, forceRefresh: bool, flipTopLevelMenu: bool, yOffset: float): unit = jsNative
            member __.showFilterMenu(relativeElement: HTMLElement, forceRefresh: bool, flipTopLevelMenu: bool, yOffset: float, fShowClose: bool, fShowCheckBoxes: bool): unit = jsNative
            member __.hideIcons(): unit = jsNative
            member __.showIcons(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UI.MenuTest","SP")>] MenuTest() =
            static member setup(relativeElement: HTMLElement): unit = jsNative

        and DialogResult =
            | invalid = 0
            | cancel = 1
            | OK = 2

        and [<AllowNullLiteral>] DialogReturnValueCallback =
            [<Emit("$0($1...)")>] abstract Invoke: dialogResult: DialogResult * returnValue: obj -> unit

        and [<AllowNullLiteral>] IDialogOptions =
            abstract title: string option with get, set
            abstract x: float option with get, set
            abstract y: float option with get, set
            abstract showMaximized: bool option with get, set
            abstract url: string option with get, set
            abstract showClose: bool option with get, set
            abstract allowMaximize: bool option with get, set
            abstract dialogReturnValueCallback: DialogReturnValueCallback option with get, set
            abstract autoSize: bool option with get, set
            abstract autoSizeStartWidth: float option with get, set
            abstract includeScrollBarPadding: bool option with get, set
            abstract width: float option with get, set
            abstract height: float option with get, set
            abstract html: HTMLElement option with get, set
            abstract args: obj option with get, set

        and [<AllowNullLiteral>] [<Import("UI.DialogOptions","SP")>] DialogOptions() =
            interface IDialogOptions with
                member __.title with get(): string option = jsNative and set(v: string option): unit = jsNative
                member __.x with get(): float option = jsNative and set(v: float option): unit = jsNative
                member __.y with get(): float option = jsNative and set(v: float option): unit = jsNative
                member __.showMaximized with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                member __.url with get(): string option = jsNative and set(v: string option): unit = jsNative
                member __.showClose with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                member __.allowMaximize with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                member __.dialogReturnValueCallback with get(): DialogReturnValueCallback option = jsNative and set(v: DialogReturnValueCallback option): unit = jsNative
                member __.autoSize with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                member __.autoSizeStartWidth with get(): float option = jsNative and set(v: float option): unit = jsNative
                member __.includeScrollBarPadding with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                member __.width with get(): float option = jsNative and set(v: float option): unit = jsNative
                member __.height with get(): float option = jsNative and set(v: float option): unit = jsNative
                member __.html with get(): HTMLElement option = jsNative and set(v: HTMLElement option): unit = jsNative
                member __.args with get(): obj option = jsNative and set(v: obj option): unit = jsNative


        and [<AllowNullLiteral>] [<Import("UI.Dialog","SP")>] Dialog() =
            member __.get_firstTabStop(): HTMLElement = jsNative
            member __.get_lastTabStop(): HTMLElement = jsNative
            member __.get_url(): string = jsNative
            member __.get_html(): string = jsNative
            member __.get_title(): string = jsNative
            member __.get_args(): obj = jsNative
            member __.get_allowMaximize(): bool = jsNative
            member __.get_showClose(): bool = jsNative
            member __.get_returnValue(): obj = jsNative
            member __.set_returnValue(value: obj): unit = jsNative
            member __.get_frameElement(): HTMLFrameElement = jsNative
            member __.get_dialogElement(): HTMLElement = jsNative
            member __.get_isMaximized(): bool = jsNative
            member __.get_closed(): bool = jsNative
            member __.autoSizeSuppressScrollbar(resizePageCallBack: obj): unit = jsNative
            member __.autoSize(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UI.ModalDialog","SP")>] ModalDialog() =
            //interface Dialog
            static member showModalDialog(options: IDialogOptions): ModalDialog = jsNative
            static member commonModalDialogClose(dialogResult: DialogResult, returnValue: obj): unit = jsNative
            static member commonModalDialogOpen(url: string, options: IDialogOptions, ?callback: DialogReturnValueCallback, ?args: obj): unit = jsNative
            static member RefreshPage(dialogResult: DialogResult): unit = jsNative
            static member ShowPopupDialog(url: string): unit = jsNative
            static member OpenPopUpPage(url: string, callback: DialogReturnValueCallback, ?width: float, ?height: float): unit = jsNative
            static member showWaitScreenWithNoClose(title: string, ?message: string, ?height: float, ?width: float): ModalDialog = jsNative
            static member showWaitScreenSize(title: string, ?message: string, ?callbackFunc: DialogReturnValueCallback, ?height: float, ?width: float): ModalDialog = jsNative
            static member showPlatformFirstRunDialog(url: string, callbackFunc: DialogReturnValueCallback): ModalDialog = jsNative
            static member get_childDialog(): ModalDialog = jsNative
            member __.close(dialogResult: DialogResult): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UI.Command","SP")>] Command(name: string, displayName: string) =
            member __.get_displayName(): string = jsNative
            member __.set_displayName(value: string): string = jsNative
            member __.get_tooltip(): string = jsNative
            member __.set_tooltip(value: string): string = jsNative
            member __.get_isEnabled(): bool = jsNative
            member __.set_isEnabled(value: bool): bool = jsNative
            member __.get_href(): string = jsNative
            member __.get_name(): string = jsNative
            member __.get_elementIDPrefix(): string = jsNative
            member __.set_elementIDPrefix(value: string): string = jsNative
            member __.get_linkElement(): HTMLAnchorElement = jsNative
            member __.get_isDropDownCommand(): bool = jsNative
            member __.set_isDropDownCommand(value: bool): bool = jsNative
            member __.attachEvents(): unit = jsNative
            member __.render(builder: HtmlBuilder): unit = jsNative
            member __.onClick(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UI.CommandBar","SP")>] CommandBar() =
            member __.get_commands(): ResizeArray<Command> = jsNative
            member __.get_dropDownThreshold(): float = jsNative
            member __.set_dropDownThreshold(value: float): float = jsNative
            member __.get_elementID(): string = jsNative
            member __.get_overrideClass(): string = jsNative
            member __.set_overrideClass(value: string): string = jsNative
            member __.addCommand(action: Command): unit = jsNative
            member __.insertCommand(action: Command, position: float): unit = jsNative
            member __.render(builder: HtmlBuilder): unit = jsNative
            member __.attachEvents(): unit = jsNative
            member __.findCommandByName(name: string): Command = jsNative

        and [<AllowNullLiteral>] [<Import("UI.PagingControl","SP")>] PagingControl(id: string) =
            member __.ButtonIDs with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ButtonState with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.render(innerContent: string): string = jsNative
            member __.postRender(): unit = jsNative
            member __.get_innerContent(): HTMLSpanElement = jsNative
            member __.get_innerContentClass(): string = jsNative
            member __.setButtonState(buttonId: float, state: float): unit = jsNative
            member __.getButtonState(buttonId: float): float = jsNative
            member __.onWindowResized(): unit = jsNative
            member __.onPrev(): unit = jsNative
            member __.onNext(): unit = jsNative

        type [<Import("UI","SP")>] Globals =
            static member ``$create_DialogOptions``(): DialogOptions = jsNative

        module Notify =
            type [<AllowNullLiteral>] [<Import("UI.Notify.Notification","SP")>] Notification(containerId: SPNotifications.ContainerID, strHtml: string, ?bSticky: bool, ?strTooltip: string, ?onclickHandler: Func<unit, unit>, ?extraData: SPStatusNotificationData) =
                member __.get_id(): string = jsNative
                member __.Show(bNoAnimate: bool): unit = jsNative
                member __.Hide(bNoAnimate: bool): unit = jsNative

            and [<AllowNullLiteral>] [<Import("UI.Notify.NotificationContainer","SP")>] NotificationContainer(id: float, element: obj, layer: float, ?notificationLimit: float) =
                member __.Clear(): unit = jsNative
                member __.GetCount(): float = jsNative
                member __.SetEventHandler(eventId: SPNotifications.EventID, eventHandler: obj): unit = jsNative

            type [<Import("UI.Notify","SP")>] Globals =
                static member addNotification(strHtml: string, bSticky: bool): string = jsNative
                static member removeNotification(nid: string): unit = jsNative
                static member showLoadingNotification(bSticky: bool): string = jsNative



        module Workspace =
            type [<Import("UI.Workspace","SP")>] Globals =
                static member add_resized(handler: Func<unit, unit>): unit = jsNative
                static member remove_resized(handler: Func<unit, unit>): unit = jsNative



        module Workplace =
            type [<Import("UI.Workplace","SP")>] Globals =
                static member add_resized(handler: Function): unit = jsNative
                static member remove_resized(handler: Function): unit = jsNative



        module UIUtility =
            type [<Import("UI.UIUtility","SP")>] Globals =
                static member generateRandomElementId(): string = jsNative
                static member cancelEvent(evt: Event): unit = jsNative
                static member clearChildNodes(elem: HTMLElement): unit = jsNative
                static member hideElement(elem: HTMLElement): unit = jsNative
                static member showElement(elem: HTMLElement): unit = jsNative
                static member insertBefore(elem: HTMLElement, targetElement: HTMLElement): unit = jsNative
                static member insertAfter(elem: HTMLElement, targetElement: HTMLElement): unit = jsNative
                static member removeNode(elem: HTMLElement): unit = jsNative
                static member calculateOffsetLeft(elem: HTMLElement): float = jsNative
                static member calculateOffsetTop(elem: HTMLElement): float = jsNative
                static member createHtmlInputText(text: string): HTMLInputElement = jsNative
                static member createHtmlInputCheck(isChecked: bool): HTMLInputElement = jsNative
                static member setInnerText(elem: HTMLElement, value: string): unit = jsNative
                static member getInnerText(elem: HTMLElement): string = jsNative
                static member isTextNode(elem: HTMLElement): bool = jsNative
                static member isSvgNode(elem: HTMLElement): bool = jsNative
                static member isNodeOfType(elem: HTMLElement, tagNames: ResizeArray<string>): bool = jsNative
                static member focusValidOnThisNode(elem: HTMLElement): bool = jsNative

        module Controls =
            type [<AllowNullLiteral>] INavigationOptions =
                abstract assetId: string option with get, set
                abstract siteTitle: string option with get, set
                abstract siteUrl: string option with get, set
                abstract appTitle: string option with get, set
                abstract appTitleIconUrl: string option with get, set
                abstract rightToLeft: bool option with get, set
                abstract appStartPage: string option with get, set
                abstract appIconUrl: string option with get, set
                abstract appHelpPageUrl: string option with get, set
                abstract appHelpPageOnClick: string option with get, set
                abstract settingsLinks: ResizeArray<ISettingsLink> option with get, set
                abstract language: string option with get, set
                abstract clientTag: string option with get, set
                abstract appWebUrl: string option with get, set
                abstract onCssLoaded: string option with get, set
                abstract bottomHeaderVisible: bool option with get, set
                abstract topHeaderVisible: bool option with get, set

            and [<AllowNullLiteral>] [<Import("UI.Controls.NavigationOptions","SP")>] NavigationOptions() =
                interface INavigationOptions with
                    member __.assetId with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.siteTitle with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.siteUrl with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.appTitle with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.appTitleIconUrl with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.rightToLeft with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                    member __.appStartPage with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.appIconUrl with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.appHelpPageUrl with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.appHelpPageOnClick with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.settingsLinks with get(): ResizeArray<ISettingsLink> option = jsNative and set(v: ResizeArray<ISettingsLink> option): unit = jsNative
                    member __.language with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.clientTag with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.appWebUrl with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.onCssLoaded with get(): string option = jsNative and set(v: string option): unit = jsNative
                    member __.bottomHeaderVisible with get(): bool option = jsNative and set(v: bool option): unit = jsNative
                    member __.topHeaderVisible with get(): bool option = jsNative and set(v: bool option): unit = jsNative


            and [<AllowNullLiteral>] ISettingsLink =
                abstract linkUrl: string with get, set
                abstract displayName: string with get, set

            and [<AllowNullLiteral>] [<Import("UI.Controls.SettingsLink","SP")>] SettingsLink() =
                interface ISettingsLink with
                    member __.linkUrl with get(): string = jsNative and set(v: string): unit = jsNative
                    member __.displayName with get(): string = jsNative and set(v: string): unit = jsNative


            and [<AllowNullLiteral>] [<Import("UI.Controls.Navigation","SP")>] Navigation(placeholderDOMElementId: string, options: INavigationOptions) =
                member __.get_assetId(): string = jsNative
                member __.get_siteTitle(): string = jsNative
                member __.get_siteUrl(): string = jsNative
                member __.get_appTitle(): string = jsNative
                member __.set_appTitle(value: string): string = jsNative
                member __.get_appTitleIconUrl(): string = jsNative
                member __.set_appTitleIconUrl(value: string): string = jsNative
                member __.get_rightToLeft(): bool = jsNative
                member __.set_rightToLeft(value: bool): bool = jsNative
                member __.get_appStartPage(): string = jsNative
                member __.set_appStartPage(value: string): string = jsNative
                member __.get_appIconUrl(): string = jsNative
                member __.set_appIconUrl(value: string): string = jsNative
                member __.get_appHelpPageUrl(): string = jsNative
                member __.set_appHelpPageUrl(value: string): string = jsNative
                member __.get_appHelpPageOnClick(): string = jsNative
                member __.set_appHelpPageOnClick(value: string): string = jsNative
                member __.get_settingsLinks(): ResizeArray<ISettingsLink> = jsNative
                member __.set_settingsLinks(value: ResizeArray<ISettingsLink>): ResizeArray<ISettingsLink> = jsNative
                member __.setVisible(value: bool): unit = jsNative
                member __.setTopHeaderVisible(value: bool): unit = jsNative
                member __.setBottomHeaderVisible(value: bool): unit = jsNative
                member __.remove(): unit = jsNative
                static member getVersionedLayoutsUrl(pageName: string): string = jsNative

            and [<AllowNullLiteral>] [<Import("UI.Controls.ControlManager","SP")>] ControlManager() =
                static member getControl(placeHolderId: string): obj = jsNative



    module UserProfiles =
        type ChangeTypes =
            | none = 0
            | add = 1
            | modify = 2
            | remove = 3
            | metadata = 4
            | all = 5

        and [<AllowNullLiteral>] [<Import("UserProfiles.HashTag","SP")>] HashTag() =
            ////interface ClientValueObject
            member __.get_name(): string = jsNative
            member __.get_useCount(): float = jsNative

        and [<AllowNullLiteral>] [<Import("UserProfiles.HashTagCollection","SP")>] HashTagCollection() =
            inherit ClientObjectCollection<HashTag>()
            member __.itemAt(index: float): HashTag = jsNative
            member __.get_item(index: float): HashTag = jsNative

        and ObjectTypes =
            | none = 0
            | singleValueProperty = 1
            | multiValueProperty = 2
            | anniversary = 3
            | dlMembership = 4
            | siteMembership = 5
            | quickLink = 6
            | colleague = 7
            | personalizationSite = 8
            | userProfile = 9
            | webLog = 10
            | custom = 11
            | organizationProfile = 12
            | organizationMembership = 13
            | all = 14

        and [<AllowNullLiteral>] [<Import("UserProfiles.PeopleManager","SP")>] PeopleManager(context: ClientRuntimeContext) =
            inherit ClientObject()
            static member getTrendingTags(context: ClientRuntimeContext): HashTagCollection = jsNative
            static member isFollowing(context: ClientRuntimeContext, possibleFollowerAccountName: string, possibleFolloweeAccountName: string): BooleanResult = jsNative
            member __.get_editProfileLink(): string = jsNative
            member __.get_isMyPeopleListPublic(): bool = jsNative
            member __.getFollowedTags(numberOfTagsToFetch: float): ResizeArray<string> = jsNative
            member __.getMyProperties(): PersonProperties = jsNative
            member __.getPropertiesFor(accountName: string): PersonProperties = jsNative
            member __.getUserProfilePropertyFor(accountName: string, propertyName: string): string = jsNative
            member __.getUserProfilePropertiesFor(propertiesForUser: UserProfilePropertiesForUser): ResizeArray<obj> = jsNative
            member __.getMySuggestions(): ClientObjectList<PersonProperties> = jsNative
            member __.hideSuggestion(accountName: string): unit = jsNative
            member __.follow(accountName: string): unit = jsNative
            member __.stopFollowing(accountName: string): unit = jsNative
            member __.followTag(tagId: string): unit = jsNative
            member __.stopFollowingTag(tagId: string): unit = jsNative
            member __.amIFollowing(accountName: string): BooleanResult = jsNative
            member __.getPeopleFollowedByMe(): ClientObjectList<PersonProperties> = jsNative
            member __.getPeopleFollowedBy(accountName: string): ClientObjectList<PersonProperties> = jsNative
            member __.getMyFollowers(): ClientObjectList<PersonProperties> = jsNative
            member __.getFollowersFor(accountName: string): ClientObjectList<PersonProperties> = jsNative
            member __.amIFollowedBy(accountName: string): BooleanResult = jsNative
            member __.setMyProfilePicture(data: Base64EncodedByteArray): unit = jsNative

        and PersonalSiteCapabilities =
            | none = 0
            | profile = 1
            | social = 2
            | storage = 3
            | myTasksDashboard = 4
            | education = 5
            | guest = 6

        and PersonalSiteInstantiationState =
            | uninitialized = 0
            | enqueued = 1
            | created = 2
            | deleted = 3
            | permissionsGeneralFailure = 4
            | permissionsUPANotGranted = 5
            | permissionsUserNotLicensed = 6
            | permissionsSelfServiceSiteCreationDisabled = 7
            | permissionsNoMySitesInPeopleLight = 8
            | permissionsEmptyHostUrl = 9
            | permissionsHostFailedToInitializePersonalSiteContext = 10
            | errorGeneralFailure = 11
            | errorManagedPathDoesNotExist = 12
            | errorLanguageNotInstalled = 13
            | errorPartialCreate = 14
            | errorPersonalSiteAlreadyExists = 15
            | errorRootSiteNotPresent = 16
            | errorSelfServiceSiteCreateCallFailed = 17

        and SocialDataStoreExceptionCode =
            | socialListNotFound = 0
            | personalSiteNotFound = 1
            | cannotCreatePersonalSite = 2
            | noSocialFeatures = 3

        and [<AllowNullLiteral>] [<Import("UserProfiles.PersonProperties","SP")>] PersonProperties() =
            inherit ClientObject()
            member __.get_accountName(): string = jsNative
            member __.get_directReports(): ResizeArray<string> = jsNative
            member __.get_displayName(): string = jsNative
            member __.get_email(): string = jsNative
            member __.get_extendedManagers(): ResizeArray<string> = jsNative
            member __.get_extendedReports(): ResizeArray<string> = jsNative
            member __.get_isFollowed(): bool = jsNative
            member __.get_latestPost(): string = jsNative
            member __.get_peers(): ResizeArray<string> = jsNative
            member __.get_personalUrl(): string = jsNative
            member __.get_pictureUrl(): string = jsNative
            member __.get_title(): string = jsNative
            member __.get_userProfileProperties(): obj = jsNative
            member __.get_userUrl(): string = jsNative

        and [<AllowNullLiteral>] [<Import("UserProfiles.ProfileLoader","SP")>] ProfileLoader() =
            inherit ClientObject()
            static member getProfileLoader(context: ClientRuntimeContext): ProfileLoader = jsNative
            member __.getUserProfile(): UserProfile = jsNative

        and [<AllowNullLiteral>] [<Import("UserProfiles.UserProfile","SP")>] UserProfile() =
            inherit ClientObject()
            member __.get_followedContent(): FollowedContent = jsNative
            member __.get_personalSite(): Site = jsNative
            member __.get_personalSiteCapabilities(): PersonalSiteCapabilities = jsNative
            member __.get_personalSiteInstantiationState(): PersonalSiteInstantiationState = jsNative
            member __.get_pictureImportEnabled(): bool = jsNative
            member __.get_urlToCreatePersonalSite(): string = jsNative
            member __.shareAllSocialData(shareAll: bool): unit = jsNative
            member __.createPersonalSite(lcid: float): unit = jsNative
            member __.createPersonalSiteEnque(isInteractive: bool): unit = jsNative

        and [<AllowNullLiteral>] [<Import("UserProfiles.FollowedContent","SP")>] FollowedContent(context: ClientRuntimeContext) =
            inherit ClientObject()
            static member newObject(context: ClientRuntimeContext): FollowedContent = jsNative
            member __.get_followedDocumentsUrl(): string = jsNative
            member __.get_followedSitesUrl(): string = jsNative
            member __.follow(url: string, ?data: FollowedItemData): FollowResult = jsNative
            member __.followItem(item: FollowedItem): FollowResult = jsNative
            member __.stopFollowing(url: string): unit = jsNative
            member __.isFollowed(url: string): BooleanResult = jsNative
            member __.getFollowedStatus(url: string): IntResult = jsNative
            member __.getItem(url: string): FollowedItem = jsNative
            member __.getItems(options: FollowedContentQueryOptions, subtype: float): ResizeArray<FollowedItem> = jsNative
            member __.updateData(url: string, data: FollowedItemData): unit = jsNative
            member __.refreshFollowedItem(item: FollowedItem): FollowedItem = jsNative
            member __.findAndUpdateFollowedItem(url: string): FollowedItem = jsNative

        and [<AllowNullLiteral>] [<Import("UserProfiles.FollowedItem","SP")>] FollowedItem() =
            inherit ClientValueObject()
            member __.get_data(): obj = jsNative
            member __.set_data(value: obj): obj = jsNative
            member __.get_fileType(): string = jsNative
            member __.set_fileType(value: string): string = jsNative
            member __.get_fileTypeProgid(): string = jsNative
            member __.set_fileTypeProgid(value: string): string = jsNative
            member __.get_flags(): string = jsNative
            member __.set_flags(value: string): string = jsNative
            member __.get_hasFeed(): bool = jsNative
            member __.set_hasFeed(value: bool): bool = jsNative
            member __.get_hidden(): bool = jsNative
            member __.set_hidden(value: bool): bool = jsNative
            member __.get_iconUrl(): string = jsNative
            member __.set_iconUrl(value: string): string = jsNative
            member __.get_itemId(): float = jsNative
            member __.set_itemId(value: float): float = jsNative
            member __.get_itemType(): FollowedItemType = jsNative
            member __.set_itemType(value: FollowedItemType): FollowedItemType = jsNative
            member __.get_listId(): string = jsNative
            member __.set_listId(value: string): string = jsNative
            member __.get_parentUrl(): string = jsNative
            member __.set_parentUrl(value: string): string = jsNative
            member __.get_serverUrlProgid(): string = jsNative
            member __.set_serverUrlProgid(value: string): string = jsNative
            member __.get_siteId(): string = jsNative
            member __.set_siteId(value: string): string = jsNative
            member __.get_subtype(): float = jsNative
            member __.set_subtype(value: float): float = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): string = jsNative
            member __.get_uniqueId(): Guid = jsNative
            member __.set_uniqueId(value: Guid): Guid = jsNative
            member __.get_url(): string = jsNative
            member __.set_url(value: string): string = jsNative
            member __.get_webId(): Guid = jsNative
            member __.set_webId(value: Guid): obj = jsNative

        and FollowedItemType =
            | unknown = 0
            | document = 1
            | site = 2
            | all = 3

        and FollowedContentExceptionType =
            | itemAlreadyExists = 0
            | itemDoesNotExist = 1
            | invalidQueryString = 2
            | invalidSubtypeValue = 3
            | unsupportedItemType = 4
            | followLimitReached = 5
            | untrustedSource = 6
            | unsupportedSite = 7
            | internalError = 8

        and FollowedContentQueryOptions =
            | unset = 0
            | sites = 1
            | documents = 2
            | hidden = 3
            | nonFeed = 4
            | defaultOptions = 5
            | all = 6

        and FollowedStatus =
            | followed = 0
            | notFollowed = 1
            | notFollowable = 2

        and [<AllowNullLiteral>] [<Import("UserProfiles.FollowedItemData","SP")>] FollowedItemData() =
            inherit ClientObject()
            member __.get_properties(): obj = jsNative

        and [<AllowNullLiteral>] [<Import("UserProfiles.FollowResult","SP")>] FollowResult() =
            inherit ClientValueObject()
            member __.get_item(): FollowedItem = jsNative
            member __.get_resultType(): FollowResultType = jsNative

        and FollowResultType =
            | unknown = 0
            | followed = 1
            | refollowed = 2
            | hitFollowLimit = 3
            | failed = 4

        and [<AllowNullLiteral>] [<Import("UserProfiles.UserProfilePropertiesForUser","SP")>] UserProfilePropertiesForUser(context: ClientContext, accountName: string, propertyNames: ResizeArray<string>) =
            inherit ClientObject()
            member __.get_accountName(): string = jsNative
            member __.set_accountName(value: string): string = jsNative
            member __.getPropertyNames(): ResizeArray<string> = jsNative



    module Utilities =
        type [<AllowNullLiteral>] [<Import("Utilities.Utility","SP")>] Utility() =
            member __.lAYOUTS_LATESTVERSION_RELATIVE_URL with get(): string = jsNative and set(v: string): unit = jsNative
            member __.lAYOUTS_LATESTVERSION_URL with get(): string = jsNative and set(v: string): unit = jsNative
            static member get_layoutsLatestVersionRelativeUrl(): string = jsNative
            static member get_layoutsLatestVersionUrl(): string = jsNative
            static member getLayoutsPageUrl(pageName: string): string = jsNative
            static member getImageUrl(imageName: string): string = jsNative
            static member createWikiPageInContextWeb(context: ClientRuntimeContext, parameters: WikiPageCreationInformation): File = jsNative
            static member localizeWebPartGallery(context: ClientRuntimeContext, items: ListItemCollection): ClientObjectList<ListItem> = jsNative
            static member getAppLicenseInformation(context: ClientRuntimeContext, productId: Guid): AppLicenseCollection = jsNative
            static member importAppLicense(context: ClientRuntimeContext, licenseTokenToImport: string, contentMarket: string, billingMarket: string, appName: string, iconUrl: string, providerName: string, appSubtype: float): unit = jsNative
            static member getAppLicenseDeploymentId(context: ClientRuntimeContext): GuidResult = jsNative
            static member logCustomAppError(context: ClientRuntimeContext, error: string): IntResult = jsNative
            static member logCustomRemoteAppError(context: ClientRuntimeContext, productId: Guid, error: string): IntResult = jsNative
            static member getLocalizedString(context: ClientRuntimeContext, source: string, defaultResourceFile: string, language: float): StringResult = jsNative
            static member createNewDiscussion(context: ClientRuntimeContext, list: List, title: string): ListItem = jsNative
            static member createNewDiscussionReply(context: ClientRuntimeContext, parent: ListItem): ListItem = jsNative
            static member markDiscussionAsFeatured(context: ClientRuntimeContext, listID: string, topicIDs: string): unit = jsNative
            static member unmarkDiscussionAsFeatured(context: ClientRuntimeContext, listID: string, topicIDs: string): unit = jsNative
            static member searchPrincipals(context: ClientRuntimeContext, web: Web, input: string, scopes: PrincipalType, sources: PrincipalSource, usersContainer: UserCollection, maxCount: float): ResizeArray<PrincipalInfo> = jsNative
            static member getCurrentUserEmailAddresses(context: ClientRuntimeContext): StringResult = jsNative
            static member createEmailBodyForInvitation(context: ClientRuntimeContext, pageAddress: string): StringResult = jsNative
            static member getPeoplePickerURL(context: ClientRuntimeContext, web: Web, fieldUser: FieldUser): StringResult = jsNative
            static member resolvePrincipal(context: ClientRuntimeContext, web: Web, input: string, scopes: PrincipalType, sources: PrincipalSource, usersContainer: UserCollection, inputIsEmailOnly: bool): PrincipalInfo = jsNative
            static member getLowerCaseString(context: ClientRuntimeContext, sourceValue: string, lcid: float): StringResult = jsNative
            static member formatDateTime(context: ClientRuntimeContext, web: Web, datetime: DateTime, format: DateTimeFormat): StringResult = jsNative
            static member isUserLicensedForEntityInContext(context: ClientRuntimeContext, licensableEntity: string): BooleanResult = jsNative

        and DateTimeFormat =
            | dateTime = 0
            | dateOnly = 1
            | timeOnly = 2
            | iSO8601 = 3
            | monthDayOnly = 4
            | monthYearOnly = 5
            | longDate = 6
            | unknownFormat = 7

        and [<AllowNullLiteral>] [<Import("Utilities.EmailProperties","SP")>] EmailProperties() =
            inherit ClientValueObject()
            member __.get_additionalHeaders(): obj = jsNative
            member __.set_additionalHeaders(value: obj): unit = jsNative
            member __.get_bCC(): ResizeArray<string> = jsNative
            member __.set_bCC(value: ResizeArray<string>): unit = jsNative
            member __.get_body(): string = jsNative
            member __.set_body(value: string): unit = jsNative
            member __.get_cC(): ResizeArray<string> = jsNative
            member __.set_cC(value: ResizeArray<string>): unit = jsNative
            member __.get_from(): string = jsNative
            member __.set_from(value: string): unit = jsNative
            member __.get_subject(): string = jsNative
            member __.set_subject(value: string): unit = jsNative
            member __.get_to(): ResizeArray<string> = jsNative
            member __.set_to(value: ResizeArray<string>): unit = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and IconSize =
            | size16 = 0
            | size32 = 1
            | size256 = 2

        and LogAppErrorResult =
            | success = 0
            | errorsThrottled = 1
            | accessDenied = 2

        and [<AllowNullLiteral>] [<Import("Utilities.PrincipalInfo","SP")>] PrincipalInfo() =
            inherit ClientValueObject()
            member __.get_department(): string = jsNative
            member __.get_displayName(): string = jsNative
            member __.get_email(): string = jsNative
            member __.get_jobTitle(): string = jsNative
            member __.get_loginName(): string = jsNative
            member __.get_mobile(): string = jsNative
            member __.get_principalId(): float = jsNative
            member __.get_principalType(): PrincipalType = jsNative
            member __.get_sIPAddress(): string = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and PrincipalSource =
            | none = 0
            | userInfoList = 1
            | windows = 2
            | membershipProvider = 3
            | roleProvider = 4
            | all = 5

        and PrincipalType =
            | none = 0
            | user = 1
            | distributionList = 2
            | securityGroup = 3
            | sharePointGroup = 4
            | all = 5

        and SPWOPIFrameAction =
            | view = 0
            | edit = 1
            | mobileView = 2
            | interactivePreview = 3

        and [<AllowNullLiteral>] [<Import("Utilities.WikiPageCreationInformation","SP")>] WikiPageCreationInformation() =
            inherit ClientValueObject()
            member __.get_serverRelativeUrl(): string = jsNative
            member __.set_serverRelativeUrl(value: string): unit = jsNative
            member __.get_wikiHtmlContent(): string = jsNative
            member __.set_wikiHtmlContent(value: string): unit = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Utilities.DateUtility","SP")>] DateUtility() =
            static member isLeapYear(year: float): bool = jsNative
            static member dateToJulianDay(year: float, month: float, day: float): float = jsNative
            //static member julianDayToDate(julianDay: float): SimpleDate = jsNative
            static member daysInMonth(year: float, month: float): float = jsNative

        and [<AllowNullLiteral>] [<Import("Utilities.HttpUtility","SP")>] HttpUtility() =
            static member htmlEncode(stringToEncode: string): string = jsNative
            static member urlPathEncode(stringToEncode: string): string = jsNative
            static member urlKeyValueEncode(keyOrValueToEncode: string): string = jsNative
            static member ecmaScriptStringLiteralEncode(scriptLiteralToEncode: string): string = jsNative
            static member navigateTo(url: string): unit = jsNative
            static member appendSourceAndNavigateTo(url: string): unit = jsNative
            static member escapeXmlText(stringToEscape: string): string = jsNative
            static member navigateHttpFolder(urlSrc: string, frameTarget: string): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Utilities.UrlBuilder","SP")>] UrlBuilder(path: string) =
            static member urlCombine(path1: string, path2: string): string = jsNative
            static member replaceOrAddQueryString(url: string, key: string, value: string): string = jsNative
            static member removeQueryString(url: string, key: string): string = jsNative
            member __.combinePath(path: string): unit = jsNative
            member __.addKeyValueQueryString(key: string, value: string): unit = jsNative
            member __.get_url(): string = jsNative
            member __.toString(): string = jsNative

        and [<AllowNullLiteral>] [<Import("Utilities.LocUtility","SP")>] LocUtility() =
            static member getLocalizedCountValue(locText: string, intervals: string, count: float): string = jsNative

        and [<AllowNullLiteral>] [<Import("Utilities.VersionUtility","SP")>] VersionUtility() =
            static member get_layoutsLatestVersionRelativeUrl(): string = jsNative
            static member get_layoutsLatestVersionUrl(): string = jsNative
            static member getLayoutsPageUrl(pageName: string): string = jsNative
            static member getImageUrl(imageName: string): string = jsNative



    module DateTimeUtil =
        type [<AllowNullLiteral>] [<Import("DateTimeUtil.SimpleDate","SP")>] SimpleDate(year: float, month: float, day: float, era: float) =
            member __.get_year(): float = jsNative
            member __.set_year(value: float): unit = jsNative
            member __.get_month(): float = jsNative
            member __.set_month(value: float): unit = jsNative
            member __.get_day(): float = jsNative
            member __.set_day(value: float): unit = jsNative
            member __.get_era(): float = jsNative
            member __.set_era(value: float): unit = jsNative
            static member dateEquals(date1: SimpleDate, date2: SimpleDate): bool = jsNative
            static member dateLessEqual(date1: SimpleDate, date2: SimpleDate): bool = jsNative
            static member dateGreaterEqual(date1: SimpleDate, date2: SimpleDate): bool = jsNative
            static member dateLess(date1: SimpleDate, date2: SimpleDate): bool = jsNative
            static member dateGreater(date1: SimpleDate, date2: SimpleDate): bool = jsNative



    module WebParts =
        type [<AllowNullLiteral>] [<Import("WebParts.LimitedWebPartManager","SP")>] LimitedWebPartManager() =
            inherit ClientObject()
            member __.get_hasPersonalizedParts(): bool = jsNative
            member __.get_scope(): PersonalizationScope = jsNative
            member __.get_webParts(): WebPartDefinitionCollection = jsNative
            member __.addWebPart(webPart: WebPart, zoneId: string, zoneIndex: float): WebPartDefinition = jsNative
            member __.importWebPart(webPartXml: string): WebPartDefinition = jsNative

        and PersonalizationScope =
            | user = 0
            | shared = 1

        and [<AllowNullLiteral>] [<Import("WebParts.TileData","SP")>] TileData() =
            inherit ClientValueObject()
            member __.get_backgroundImageLocation(): string = jsNative
            member __.set_backgroundImageLocation(value: string): unit = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): unit = jsNative
            member __.get_iD(): float = jsNative
            member __.set_iD(value: float): unit = jsNative
            member __.get_linkLocation(): string = jsNative
            member __.set_linkLocation(value: string): unit = jsNative
            member __.get_tileOrder(): float = jsNative
            member __.set_tileOrder(value: float): unit = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): unit = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and [<AllowNullLiteral>] [<Import("WebParts.WebPart","SP")>] WebPart() =
            inherit ClientObject()
            member __.get_hidden(): bool = jsNative
            member __.set_hidden(value: bool): unit = jsNative
            member __.get_isClosed(): bool = jsNative
            member __.get_properties(): PropertyValues = jsNative
            member __.get_subtitle(): string = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): unit = jsNative
            member __.get_titleUrl(): string = jsNative
            member __.set_titleUrl(value: string): unit = jsNative
            member __.get_zoneIndex(): float = jsNative

        and [<AllowNullLiteral>] [<Import("WebParts.WebPartDefinition","SP")>] WebPartDefinition() =
            inherit ClientObject()
            member __.get_id(): Guid = jsNative
            member __.get_webPart(): WebPart = jsNative
            member __.saveWebPartChanges(): unit = jsNative
            member __.closeWebPart(): unit = jsNative
            member __.openWebPart(): unit = jsNative
            member __.deleteWebPart(): unit = jsNative
            member __.moveWebPartTo(zoneID: string, zoneIndex: float): unit = jsNative

        and [<AllowNullLiteral>] [<Import("WebParts.WebPartDefinitionCollection","SP")>] WebPartDefinitionCollection() =
            inherit ClientObjectCollection<WebPartDefinition>()
            member __.itemAt(index: float): WebPartDefinition = jsNative
            member __.get_item(index: float): WebPartDefinition = jsNative
            member __.getById(id: Guid): WebPartDefinition = jsNative
            member __.getByControlId(controlId: string): WebPartDefinition = jsNative



    module Workflow =
        type [<AllowNullLiteral>] [<Import("Workflow.WorkflowAssociation","SP")>] WorkflowAssociation() =
            inherit ClientObject()
            member __.get_allowManual(): bool = jsNative
            member __.set_allowManual(value: bool): unit = jsNative
            member __.get_associationData(): string = jsNative
            member __.set_associationData(value: string): unit = jsNative
            member __.get_autoStartChange(): bool = jsNative
            member __.set_autoStartChange(value: bool): unit = jsNative
            member __.get_autoStartCreate(): bool = jsNative
            member __.set_autoStartCreate(value: bool): unit = jsNative
            member __.get_baseId(): Guid = jsNative
            member __.get_created(): DateTime = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): unit = jsNative
            member __.get_enabled(): bool = jsNative
            member __.set_enabled(value: bool): unit = jsNative
            member __.get_historyListTitle(): string = jsNative
            member __.set_historyListTitle(value: string): unit = jsNative
            member __.get_id(): Guid = jsNative
            member __.get_instantiationUrl(): string = jsNative
            member __.get_internalName(): string = jsNative
            member __.get_isDeclarative(): bool = jsNative
            member __.get_listId(): Guid = jsNative
            member __.get_modified(): DateTime = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): unit = jsNative
            member __.get_taskListTitle(): string = jsNative
            member __.set_taskListTitle(value: string): unit = jsNative
            member __.get_webId(): Guid = jsNative
            member __.update(): unit = jsNative
            member __.deleteObject(): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Workflow.WorkflowAssociationCollection","SP")>] WorkflowAssociationCollection() =
            inherit ClientObjectCollection<WorkflowAssociation>()
            member __.itemAt(index: float): WorkflowAssociation = jsNative
            member __.get_item(index: float): WorkflowAssociation = jsNative
            member __.getById(associationId: Guid): WorkflowAssociation = jsNative
            member __.add(parameters: WorkflowAssociationCreationInformation): WorkflowAssociation = jsNative
            member __.getByName(name: string): WorkflowAssociation = jsNative

        and [<AllowNullLiteral>] [<Import("Workflow.WorkflowAssociationCreationInformation","SP")>] WorkflowAssociationCreationInformation() =
            inherit ClientValueObject()
            member __.get_contentTypeAssociationHistoryListName(): string = jsNative
            member __.set_contentTypeAssociationHistoryListName(value: string): unit = jsNative
            member __.get_contentTypeAssociationTaskListName(): string = jsNative
            member __.set_contentTypeAssociationTaskListName(value: string): unit = jsNative
            member __.get_historyList(): List = jsNative
            member __.set_historyList(value: List): unit = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): unit = jsNative
            member __.get_taskList(): List = jsNative
            member __.set_taskList(value: List): unit = jsNative
            member __.get_template(): WorkflowTemplate = jsNative
            member __.set_template(value: WorkflowTemplate): unit = jsNative
            member __.get_typeId(): string = jsNative
            member __.writeToXml(writer: XmlWriter, serializationContext: SerializationContext): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Workflow.WorkflowTemplate","SP")>] WorkflowTemplate() =
            inherit ClientObject()
            member __.get_allowManual(): bool = jsNative
            member __.get_associationUrl(): string = jsNative
            member __.get_autoStartChange(): bool = jsNative
            member __.get_autoStartCreate(): bool = jsNative
            member __.get_description(): string = jsNative
            member __.get_id(): Guid = jsNative
            member __.get_isDeclarative(): bool = jsNative
            member __.get_name(): string = jsNative
            member __.get_permissionsManual(): BasePermissions = jsNative

        and [<AllowNullLiteral>] [<Import("Workflow.WorkflowTemplateCollection","SP")>] WorkflowTemplateCollection() =
            inherit ClientObjectCollection<WorkflowTemplate>()
            member __.itemAt(index: float): WorkflowTemplate = jsNative
            member __.get_item(index: float): WorkflowTemplate = jsNative
            member __.getById(templateId: Guid): WorkflowTemplate = jsNative
            member __.getByName(name: string): WorkflowTemplate = jsNative



    module Publishing =
        type [<AllowNullLiteral>] [<Import("Publishing.PublishingWeb","SP")>] PublishingWeb() =
            //interface ClientObject
            static member getPublishingWeb(context: ClientContext, web: Web): PublishingWeb = jsNative
            member __.get_web(): Web = jsNative
            member __.addPublishingPage(pageInformation: PublishingPageInformation): PublishingPage = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.PublishingPageInformation","SP")>] PublishingPageInformation() =
            //interface ClientValueObject
            member __.get_folder(): Folder = jsNative
            member __.set_folder(value: Folder): Folder = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_pageLayoutListItem(): ListItem = jsNative
            member __.set_pageLayoutListItem(value: ListItem): ListItem = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.PublishingPage","SP")>] PublishingPage() =
            inherit ScheduledItem()
            static member getPublishingPage(context: ClientContext, sourceListItem: ListItem): PublishingPage = jsNative
            //member __.addFriendlyUrl(friendlyUrlSegment: string, editableParent: Navigation.NavigationTermSetItem, doAddToNavigation: bool): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.ScheduledItem","SP")>] ScheduledItem() =
            //interface ClientObject
            member __.get_listItem(): ListItem = jsNative
            member __.get_startDate(): DateTime = jsNative
            member __.set_startDate(value: DateTime): DateTime = jsNative
            member __.get_endDate(): DateTime = jsNative
            member __.set_endDate(value: DateTime): DateTime = jsNative
            member __.schedule(approvalComment: string): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.PublishingSite","SP")>] PublishingSite() =
            //interface ClientObject
            static member createPageLayout(context: ClientContext, parameters: PageLayoutCreationInformation): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.PageLayoutCreationInformation","SP")>] PageLayoutCreationInformation() =
            //interface ClientValueObject
            member __.get_web(): Web = jsNative
            member __.set_web(value: Web): Web = jsNative
            member __.get_associatedContentTypeId(): string = jsNative
            member __.set_associatedContentTypeId(value: string): string = jsNative
            member __.get_masterPageUrl(): string = jsNative
            member __.set_masterPageUrl(value: string): string = jsNative
            member __.get_newPageLayoutNameWithoutExtension(): string = jsNative
            member __.set_newPageLayoutNameWithoutExtension(value: string): string = jsNative
            member __.get_newPageLayoutEditablePath(): string = jsNative
            member __.set_newPageLayoutEditablePath(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.SiteServicesAddins","SP")>] SiteServicesAddins() =
            static member getSettings(context: ClientContext, addinId: Guid): AddinSettings = jsNative
            static member setSettings(context: ClientContext, addin: AddinSettings): unit = jsNative
            static member deleteSettings(context: ClientContext, addinId: Guid): unit = jsNative
            static member getPlugin(context: ClientContext, pluginName: string): AddinPlugin = jsNative
            static member setPlugin(context: ClientContext, addin: AddinPlugin): unit = jsNative
            static member deletePlugin(context: ClientContext, pluginName: string): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.AddinSettings","SP")>] AddinSettings(ctx: ClientContext, id: Guid) =
            //interface ClientObject
            member __.get_id(): Guid = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): string = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): string = jsNative
            member __.get_enabled(): bool = jsNative
            member __.set_enabled(value: bool): bool = jsNative
            member __.get_namespace(): bool = jsNative
            member __.set_namespace(value: bool): bool = jsNative
            member __.get_headScript(): string = jsNative
            member __.set_headScript(value: string): string = jsNative
            member __.get_htmlStartBody(): string = jsNative
            member __.set_htmlStartBody(value: string): string = jsNative
            member __.get_htmlEndBody(): string = jsNative
            member __.set_htmlEndBody(value: string): string = jsNative
            member __.get_metaTagPagePropertyMappings(): obj = jsNative
            member __.set_metaTagPagePropertyMappings(value: obj): obj = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.AddinPlugin","SP")>] AddinPlugin(ctx: ClientContext) =
            //interface ClientObject
            member __.get_description(): string = jsNative
            member __.set_description(value: string): string = jsNative
            member __.get_markup(): string = jsNative
            member __.set_markup(value: string): string = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.DesignPackage","SP")>] DesignPackage() =
            static member install(context: ClientContext, site: Site, info: DesignPackageInfo, path: string): unit = jsNative
            static member uninstall(context: ClientContext, site: Site, info: DesignPackageInfo): unit = jsNative
            static member apply(context: ClientContext, site: Site, info: DesignPackageInfo): unit = jsNative
            static member exportEnterprise(context: ClientContext, site: Site, includeSearchConfiguration: bool): ClientResult<DesignPackageInfo> = jsNative
            static member exportSmallBusiness(context: ClientContext, site: Site, packageName: string, includeSearchConfiguration: bool): ClientResult<DesignPackageInfo> = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.DesignPackageInfo","SP")>] DesignPackageInfo() =
            //interface ClientValueObject
            member __.get_packageName(): string = jsNative
            member __.set_packageName(value: string): string = jsNative
            member __.get_packageGuid(): Guid = jsNative
            member __.set_packageGuid(value: Guid): Guid = jsNative
            member __.get_majorVersion(): float = jsNative
            member __.set_majorVersion(value: float): float = jsNative
            member __.get_minorVersion(): float = jsNative
            member __.set_minorVersion(value: float): float = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.SiteImageRenditions","SP")>] SiteImageRenditions() =
            static member getRenditions(context: ClientContext): ResizeArray<ImageRendition> = jsNative
            static member setRenditions(context: ClientContext, renditions: ResizeArray<ImageRendition>): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.ImageRendition","SP")>] ImageRendition() =
            //interface ClientValueObject
            member __.get_id(): float = jsNative
            member __.get_version(): float = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_width(): float = jsNative
            member __.set_width(value: float): float = jsNative
            member __.get_height(): float = jsNative
            member __.set_height(value: float): float = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.Variations","SP")>] Variations() =
            //interface ClientObject
            static member getLabels(context: ClientContext): ClientObjectList<VariationLabel> = jsNative
            static member getPeerUrl(context: ClientContext, currentUrl: string, labelTitle: string): StringResult = jsNative
            static member updateListItems(context: ClientContext, listId: Guid, itemIds: ResizeArray<float>): unit = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.VariationLabel","SP")>] VariationLabel() =
            //interface ClientObject
            member __.get_displayName(): string = jsNative
            member __.set_displayName(value: string): string = jsNative
            member __.get_isSource(): bool = jsNative
            member __.set_isSource(value: bool): bool = jsNative
            member __.get_language(): string = jsNative
            member __.set_language(value: string): string = jsNative
            member __.get_locale(): string = jsNative
            member __.set_locale(value: string): string = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): string = jsNative
            member __.get_topWebUrl(): string = jsNative
            member __.set_topWebUrl(value: string): string = jsNative

        and [<AllowNullLiteral>] [<Import("Publishing.CustomizableString","SP")>] CustomizableString() =
            //interface ClientObject
            member __.get_defaultValue(): string = jsNative
            member __.get_value(): string = jsNative
            member __.set_value(value: string): string = jsNative
            member __.get_usesDefaultValue(): bool = jsNative
            member __.set_usesDefaultValue(value: bool): bool = jsNative

        module Navigation =
            type NavigationLinkType =
                | root = 0
                | friendlyUrl = 1
                | simpleLink = 2

            and StandardNavigationSource =
                | unknown = 0
                | portalProvider = 1
                | taxonomyProvider = 2
                | inheritFromParentWeb = 3

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.NavigationTermSetItem","SP")>] NavigationTermSetItem() =
                //interface ClientObject
                member __.get_id(): Guid = jsNative
                member __.get_isReadOnly(): bool = jsNative
                member __.get_linkType(): NavigationLinkType = jsNative
                member __.set_linkType(value: NavigationLinkType): NavigationLinkType = jsNative
                member __.get_targetUrlForChildTerms(): CustomizableString = jsNative
                member __.get_catalogTargetUrlForChildTerms(): CustomizableString = jsNative
                member __.get_taxonomyName(): string = jsNative
                member __.get_title(): CustomizableString = jsNative
                member __.get_terms(): NavigationTermCollection = jsNative
                member __.get_view(): NavigationTermSetView = jsNative
                member __.createTerm(termName: string, linkType: NavigationLinkType, termId: Guid): Taxonomy.Term = jsNative
                member __.getTaxonomyTermStore(): Taxonomy.TermStore = jsNative
                member __.getResolvedDisplayUrl(browserQueryString: string): StringResult = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.NavigationTermCollection","SP")>] NavigationTermCollection() = class end
                //interface ClientObjectCollection<NavigationTerm>


            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.NavigationTerm","SP")>] NavigationTerm() =
                inherit NavigationTermSetItem()
                member __.get_associatedFolderUrl(): string = jsNative
                member __.set_associatedFolderUrl(value: string): string = jsNative
                member __.get_catalogTargetUrl(): CustomizableString = jsNative
                member __.get_categoryImageUrl(): string = jsNative
                member __.set_categoryImageUrl(value: string): string = jsNative
                member __.get_excludedProviders(): NavigationTermProviderNameCollection = jsNative
                member __.get_excludeFromCurrentNavigation(): bool = jsNative
                member __.set_excludeFromCurrentNavigation(value: bool): bool = jsNative
                member __.get_excludeFromGlobalNavigation(): bool = jsNative
                member __.set_excludeFromGlobalNavigation(value: bool): bool = jsNative
                member __.get_friendlyUrlSegment(): CustomizableString = jsNative
                member __.get_hoverText(): string = jsNative
                member __.set_hoverText(value: string): string = jsNative
                member __.get_isDeprecated(): bool = jsNative
                member __.get_isPinned(): bool = jsNative
                member __.get_isPinnedRoot(): bool = jsNative
                member __.get_parent(): NavigationTerm = jsNative
                member __.get_simpleLinkUrl(): string = jsNative
                member __.set_simpleLinkUrl(value: string): string = jsNative
                member __.get_targetUrl(): CustomizableString = jsNative
                member __.get_termSet(): NavigationTermSet = jsNative
                member __.getAsEditable(taxonomySession: Taxonomy.TaxonomySession): NavigationTerm = jsNative
                member __.getWithNewView(newView: NavigationTermSetView): NavigationTerm = jsNative
                member __.getResolvedTargetUrl(browserQueryString: string, remainingUrlSegments: ResizeArray<string>): StringResult = jsNative
                member __.getResolvedTargetUrlWithoutQuery(): StringResult = jsNative
                member __.getResolvedAssociatedFolderUrl(): StringResult = jsNative
                member __.getWebRelativeFriendlyUrl(): StringResult = jsNative
                member __.getAllParentTerms(): NavigationTermCollection = jsNative
                member __.getTaxonomyTerm(): Taxonomy.Term = jsNative
                member __.move(newParent: NavigationTermSetItem): unit = jsNative
                member __.deleteObject(): unit = jsNative
                static member getAsResolvedByWeb(context: ClientContext, term: Taxonomy.Term, web: Web, siteMapProviderName: string): NavigationTerm = jsNative
                static member getAsResolvedByView(context: ClientContext, term: Taxonomy.Term, view: NavigationTermSetView): NavigationTerm = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.NavigationTermSet","SP")>] NavigationTermSet() =
                inherit NavigationTermSetItem()
                member __.get_isNavigationTermSet(): bool = jsNative
                member __.set_isNavigationTermSet(value: bool): bool = jsNative
                member __.get_lcid(): float = jsNative
                member __.get_loadedFromPersistedData(): bool = jsNative
                member __.get_termGroupId(): Guid = jsNative
                member __.get_termStoreId(): Guid = jsNative
                member __.getAsEditable(taxonomySession: Taxonomy.TaxonomySession): NavigationTermSet = jsNative
                member __.getWithNewView(newView: NavigationTermSetView): NavigationTermSet = jsNative
                member __.getTaxonomyTermSet(): Taxonomy.TermSet = jsNative
                member __.getAllTerms(): NavigationTermCollection = jsNative
                member __.findTermForUrl(url: string): NavigationTerm = jsNative
                static member getAsResolvedByWeb(context: ClientContext, termSet: Taxonomy.TermSet, web: Web, siteMapProviderName: string): NavigationTermSet = jsNative
                static member getAsResolvedByView(context: ClientContext, termSet: Taxonomy.TermSet, view: NavigationTermSetView): NavigationTermSet = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.NavigationTermProviderNameCollection","SP")>] NavigationTermProviderNameCollection() =
                //interface ClientObjectCollection<string>
                member __.Add(item: string): unit = jsNative
                member __.Clear(): unit = jsNative
                member __.Remove(item: string): BooleanResult = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.NavigationTermSetView","SP")>] NavigationTermSetView(context: ClientContext, web: Web, siteMapProviderName: string) =
                //interface ClientObject
                member __.get_excludeDeprecatedTerms(): bool = jsNative
                member __.set_excludeDeprecatedTerms(value: bool): bool = jsNative
                member __.get_excludeTermsByPermissions(): bool = jsNative
                member __.set_excludeTermsByPermissions(value: bool): bool = jsNative
                member __.get_excludeTermsByProvider(): bool = jsNative
                member __.set_excludeTermsByProvider(value: bool): bool = jsNative
                member __.get_serverRelativeSiteUrl(): string = jsNative
                member __.get_serverRelativeWebUrl(): string = jsNative
                member __.get_siteMapProviderName(): string = jsNative
                member __.set_siteMapProviderName(value: string): string = jsNative
                member __.get_webId(): Guid = jsNative
                member __.get_webTitle(): string = jsNative
                member __.getCopy(): NavigationTermSetView = jsNative
                static member createEmptyInstance(context: ClientContext): NavigationTermSetView = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.TaxonomyNavigation","SP")>] TaxonomyNavigation() =
                static member getWebNavigationSettings(context: ClientContext, web: Web): WebNavigationSettings = jsNative
                static member getTermSetForWeb(context: ClientContext, web: Web, siteMapProviderName: string, includeInheritedSettings: bool): NavigationTermSet = jsNative
                static member setCrawlAsFriendlyUrlPage(context: ClientContext, navigationTerm: Taxonomy.Term, crawlAsFriendlyUrlPage: bool): BooleanResult = jsNative
                static member getNavigationLcidForWeb(context: ClientContext, web: Web): IntResult = jsNative
                static member flushSiteFromCache(context: ClientContext, site: Site): unit = jsNative
                static member flushWebFromCache(context: ClientContext, web: Web): unit = jsNative
                static member flushTermSetFromCache(context: ClientContext, webForPermissions: Web, termStoreId: Guid, termSetId: Guid): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.WebNavigationSettings","SP")>] WebNavigationSettings(context: ClientContext, web: Web) =
                //interface ClientObject
                member __.get_addNewPagesToNavigation(): bool = jsNative
                member __.set_addNewPagesToNavigation(value: bool): bool = jsNative
                member __.get_createFriendlyUrlsForNewPages(): bool = jsNative
                member __.set_createFriendlyUrlsForNewPages(value: bool): bool = jsNative
                member __.get_currentNavigation(): StandardNavigationSettings = jsNative
                member __.get_globalNavigation(): StandardNavigationSettings = jsNative
                member __.update(taxonomySession: Taxonomy.TaxonomySession): unit = jsNative
                member __.resetToDefaults(): unit = jsNative

            and [<AllowNullLiteral>] [<Import("Publishing.Navigation.StandardNavigationSettings","SP")>] StandardNavigationSettings() =
                //interface ClientObject
                member __.get_termSetId(): Guid = jsNative
                member __.set_termSetId(value: Guid): Guid = jsNative
                member __.get_termStoreId(): Guid = jsNative
                member __.set_termStoreId(value: Guid): Guid = jsNative
                member __.get_source(): StandardNavigationSource = jsNative
                member __.set_source(value: StandardNavigationSource): StandardNavigationSource = jsNative



    module CompliancePolicy =
        type SPContainerType =
            | site = 0
            | web = 1
            | list = 2

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPContainerId","SP")>] SPContainerId() =
            //interface ClientObject
            static member createFromList(context: ClientRuntimeContext, list: List): SPContainerId = jsNative
            static member createFromWeb(context: ClientRuntimeContext, web: Web): SPContainerId = jsNative
            static member createFromSite(context: ClientRuntimeContext, site: Site): SPContainerId = jsNative
            static member create(context: ClientRuntimeContext, containerId: obj): SPContainerId = jsNative
            member __.get_containerType(): ContentType = jsNative
            member __.set_containerType(value: ContentType): ContentType = jsNative
            member __.get_listId(): Guid = jsNative
            member __.set_listId(value: Guid): Guid = jsNative
            member __.get_siteId(): Guid = jsNative
            member __.set_siteId(value: Guid): Guid = jsNative
            member __.get_siteUrl(): string = jsNative
            member __.set_siteUrl(value: string): string = jsNative
            member __.get_tenantId(): Guid = jsNative
            member __.set_tenantId(value: Guid): Guid = jsNative
            member __.get_title(): string = jsNative
            member __.set_title(value: string): string = jsNative
            member __.get_version(): obj = jsNative
            member __.set_version(value: obj): obj = jsNative
            member __.get_webId(): Guid = jsNative
            member __.set_webId(value: Guid): Guid = jsNative
            member __.serialize(): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPPolicyAssociation","SP")>] SPPolicyAssociation() =
            //interface ClientObject
            member __.get_allowOverride(): bool = jsNative
            member __.set_allowOverride(value: bool): bool = jsNative
            member __.get_comment(): string = jsNative
            member __.set_comment(value: string): string = jsNative
            member __.get_defaultPolicyDefinitionConfigId(): ResizeArray<obj> = jsNative
            member __.set_defaultPolicyDefinitionConfigId(value: ResizeArray<obj>): ResizeArray<obj> = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): string = jsNative
            member __.get_identity(): bool = jsNative
            member __.set_identity(value: bool): bool = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_policyApplyStatus(): obj = jsNative
            member __.set_policyApplyStatus(value: obj): obj = jsNative
            member __.get_policyDefinitionConfigIds(): ResizeArray<obj> = jsNative
            member __.set_policyDefinitionConfigIds(value: ResizeArray<obj>): ResizeArray<obj> = jsNative
            member __.get_scope(): obj = jsNative
            member __.set_scope(value: obj): obj = jsNative
            member __.get_source(): obj = jsNative
            member __.set_source(value: obj): obj = jsNative
            member __.get_version(): obj = jsNative
            member __.set_version(value: obj): obj = jsNative
            member __.get_whenAppliedUTC(): DateTime = jsNative
            member __.set_whenAppliedUTC(value: DateTime): DateTime = jsNative
            member __.get_whenChangedUTC(): DateTime = jsNative
            member __.set_whenChangedUTC(value: DateTime): DateTime = jsNative
            member __.get_whenCreatedUTC(): DateTime = jsNative
            member __.set_whenCreatedUTC(value: DateTime): DateTime = jsNative

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPPolicyBinding","SP")>] SPPolicyBinding() =
            //interface ClientObject
            member __.get_identity(): obj = jsNative
            member __.set_identity(value: obj): obj = jsNative
            member __.get_isExempt(): bool = jsNative
            member __.set_isExempt(value: bool): bool = jsNative
            member __.get_mode(): obj = jsNative
            member __.set_mode(value: obj): obj = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_policyApplyStatus(): obj = jsNative
            member __.set_policyApplyStatus(value: obj): obj = jsNative
            member __.get_policyAssociationConfigId(): obj = jsNative
            member __.set_policyAssociationConfigId(value: obj): obj = jsNative
            member __.get_policyDefinitionConfigId(): obj = jsNative
            member __.set_policyDefinitionConfigId(value: obj): obj = jsNative
            member __.get_policyRuleConfigId(): obj = jsNative
            member __.set_policyRuleConfigId(value: obj): obj = jsNative
            member __.get_scope(): obj = jsNative
            member __.set_scope(value: obj): obj = jsNative
            member __.get_source(): obj = jsNative
            member __.set_source(value: obj): obj = jsNative
            member __.get_version(): obj = jsNative
            member __.set_version(value: obj): obj = jsNative
            member __.get_whenAppliedUTC(): DateTime = jsNative
            member __.set_whenAppliedUTC(value: DateTime): DateTime = jsNative
            member __.get_whenChangedUTC(): DateTime = jsNative
            member __.set_whenChangedUTC(value: DateTime): DateTime = jsNative
            member __.get_whenCreatedUTC(): DateTime = jsNative
            member __.set_whenCreatedUTC(value: DateTime): DateTime = jsNative

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPPolicyDefinition","SP")>] SPPolicyDefinition() =
            //interface ClientObject
            member __.get_comment(): string = jsNative
            member __.set_comment(value: string): string = jsNative
            member __.get_createdBy(): obj = jsNative
            member __.set_createdBy(value: obj): obj = jsNative
            member __.get_defaultPolicyRuleConfigId(): obj = jsNative
            member __.set_defaultPolicyRuleConfigId(value: obj): obj = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): string = jsNative
            member __.get_enabled(): bool = jsNative
            member __.set_enabled(value: bool): bool = jsNative
            member __.get_identity(): obj = jsNative
            member __.set_identity(value: obj): obj = jsNative
            member __.get_lastModifiedBy(): obj = jsNative
            member __.set_lastModifiedBy(value: obj): obj = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_mode(): obj = jsNative
            member __.set_mode(value: obj): obj = jsNative
            member __.get_scenario(): obj = jsNative
            member __.set_scenario(value: obj): obj = jsNative
            member __.get_source(): obj = jsNative
            member __.set_source(value: obj): obj = jsNative
            member __.get_version(): obj = jsNative
            member __.set_version(value: obj): obj = jsNative
            member __.get_whenChangedUTC(): DateTime = jsNative
            member __.set_whenChangedUTC(value: DateTime): DateTime = jsNative
            member __.get_whenCreatedUTC(): DateTime = jsNative
            member __.set_whenCreatedUTC(value: DateTime): DateTime = jsNative

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPPolicyRule","SP")>] SPPolicyRule() =
            //interface ClientObject
            member __.get_comment(): string = jsNative
            member __.set_comment(value: string): string = jsNative
            member __.get_createdBy(): obj = jsNative
            member __.set_createdBy(value: obj): obj = jsNative
            member __.get_description(): string = jsNative
            member __.set_description(value: string): string = jsNative
            member __.get_enabled(): bool = jsNative
            member __.set_enabled(value: bool): bool = jsNative
            member __.get_identity(): obj = jsNative
            member __.set_identity(value: obj): obj = jsNative
            member __.get_lastModifiedBy(): obj = jsNative
            member __.set_lastModifiedBy(value: obj): obj = jsNative
            member __.get_mode(): obj = jsNative
            member __.set_mode(value: obj): obj = jsNative
            member __.get_name(): string = jsNative
            member __.set_name(value: string): string = jsNative
            member __.get_policyDefinitionConfigId(): obj = jsNative
            member __.set_policyDefinitionConfigId(value: obj): obj = jsNative
            member __.get_priority(): obj = jsNative
            member __.set_priority(value: obj): obj = jsNative
            member __.get_ruleBlob(): obj = jsNative
            member __.set_ruleBlob(value: obj): obj = jsNative
            member __.get_whenChangedUTC(): DateTime = jsNative
            member __.set_whenChangedUTC(value: DateTime): DateTime = jsNative
            member __.get_whenCreatedUTC(): DateTime = jsNative
            member __.set_whenCreatedUTC(value: DateTime): DateTime = jsNative

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPPolicyStore","SP")>] SPPolicyStore(context: ClientRuntimeContext, web: Web) =
            //interface ClientObject
            static member createPolicyDefinition(context: ClientRuntimeContext): SPPolicyDefinition = jsNative
            static member createPolicyBinding(context: ClientRuntimeContext): SPPolicyBinding = jsNative
            static member createPolicyAssociation(context: ClientRuntimeContext): SPPolicyAssociation = jsNative
            static member createPolicyRule(context: ClientRuntimeContext): SPPolicyRule = jsNative
            member __.updatePolicyRule(policyRule: SPPolicyRule): unit = jsNative
            member __.getPolicyRule(policyRuleId: obj, throwIfNull: bool): SPPolicyRule = jsNative
            member __.deletePolicyRule(policyRuleId: obj): unit = jsNative
            member __.notifyUnifiedPolicySync(notificationId: obj, syncSvcUrl: string, changeInfos: obj, syncNow: bool, fullSyncForTenant: bool): unit = jsNative
            member __.updatePolicyDefinition(policyDefinition: SPPolicyDefinition): unit = jsNative
            member __.getPolicyDefinition(policyDefinitionId: obj): SPPolicyDefinition = jsNative
            member __.deletePolicyDefinition(policyDefinitionId: obj): unit = jsNative
            member __.getPolicyDefinitions(scenario: obj): ClientObjectList<SPPolicyDefinition> = jsNative
            member __.updatePolicyBinding(policyBinding: SPPolicyBinding): unit = jsNative
            member __.getPolicyBinding(policyBindingId: obj): SPPolicyBinding = jsNative
            member __.deletePolicyBinding(policyBindingId: obj): unit = jsNative
            member __.updatePolicyAssociation(policyAssociation: SPPolicyAssociation): unit = jsNative
            member __.getPolicyAssociation(policyAssociationId: obj): SPPolicyAssociation = jsNative
            member __.getPolicyAssociationForContainer(containerId: SPContainerId): SPPolicyAssociation = jsNative
            member __.deletePolicyAssociation(policyAssociationId: obj): unit = jsNative

        and [<AllowNullLiteral>] [<Import("CompliancePolicy.SPPolicyStoreProxy","SP")>] SPPolicyStoreProxy(context: ClientRuntimeContext, web: Web) =
            //interface ClientObject
            member __.get_policyStoreUrl(): string = jsNative



    module Discovery =
        type ExportStatus =
            | notStarted = 0
            | started = 1
            | complete = 2
            | failed = 3

        and [<AllowNullLiteral>] [<Import("Discovery.Case","SP")>] Case(context: ClientRuntimeContext, web: Web) =
            //interface ClientObject
            member __.getExportContent(sourceIds: ResizeArray<float>): StringResult = jsNative

        and [<AllowNullLiteral>] [<Import("Discovery.Export","SP")>] Export(context: ClientRuntimeContext, item: ListItem) =
            //interface ClientObject
            member __.get_status(): ExportStatus = jsNative
            member __.set_status(value: ExportStatus): ExportStatus = jsNative
            member __.update(): unit = jsNative
            member __.getExportContent(): StringResult = jsNative



    module InformationPolicy =
        type [<AllowNullLiteral>] [<Import("InformationPolicy.ProjectPolicy","SP")>] ProjectPolicy(context: ClientRuntimeContext, objectPath: ObjectPath) =
            inherit ClientObject()
            member __.get_description(): string = jsNative
            member __.get_emailBody(): string = jsNative
            member __.set_emailBody(value: string): string = jsNative
            member __.get_emailBodyWithTeamMailbox(): string = jsNative
            member __.set_emailBodyWithTeamMailbox(value: string): string = jsNative
            member __.get_emailSubject(): string = jsNative
            member __.set_emailSubject(value: string): string = jsNative
            member __.get_name(): string = jsNative
            member __.savePolicy(): unit = jsNative
            static member getProjectPolicies(context: ClientRuntimeContext, web: Web): ClientObjectList<ProjectPolicy> = jsNative
            static member getCurrentlyAppliedProject(context: ClientRuntimeContext, web: Web): ProjectPolicy = jsNative
            static member applyProjectPolicy(context: ClientRuntimeContext, web: Web, projectPolicy: ProjectPolicy): unit = jsNative
            static member openProject(context: ClientRuntimeContext, web: Web): unit = jsNative
            static member closeProject(context: ClientRuntimeContext, web: Web): unit = jsNative
            static member postponeProject(context: ClientRuntimeContext, web: Web): unit = jsNative
            static member doesProjectHavePolicy(context: ClientRuntimeContext, web: Web): BooleanResult = jsNative
            static member isProjectClosed(context: ClientRuntimeContext, web: Web): BooleanResult = jsNative
            static member getProjectCloseDate(context: ClientRuntimeContext, web: Web): DateTimeResult = jsNative
            static member getProjectExpirationDate(context: ClientRuntimeContext, web: Web): DateTimeResult = jsNative



    module JsGrid =
        type TextDirection =
            | Default = 0
            | RightToLeft = 1
            | LeftToRight = 2

        and PaneId =
            | MainGrid = 0
            | PivotedGrid = 1
            | Gantt = 2

        and PaneLayout =
            | GridOnly = 0
            | GridAndGantt = 1
            | GridAndPivotedGrid = 2

        and EditMode =
            | ReadOnly = 0
            | ReadWrite = 1
            | ReadOnlyDefer = 2
            | ReadWriteDefer = 3
            | Defer = 4

        and GanttDrawBarFlags =
            | LeftLink = 0
            | RightLink = 1

        and GanttBarDateType =
            | Start = 0
            | End = 1

        and ValidationState =
            | Valid = 0
            | Pending = 1
            | Invalid = 2

        and HierarchyMode =
            | None = 0
            | Standard = 1
            | Grouping = 2

        and EditActorWriteType =
            | Both = 0
            | LocalizedOnly = 1
            | DataOnly = 2
            | Either = 3

        and EditActorReadType =
            | Both = 0
            | LocalizedOnly = 1
            | DataOnly = 2

        and EditActorUpdateType =
            | Committed = 0
            | Uncommitted = 1

        and SortMode =
            | Ascending = 0
            | Descending = 1
            | None = 2

        and RowHeaderStatePriorities =
            | Dirty = 0
            | Transfer = 1
            | CellError = 2
            | Conflict = 3
            | RowError = 4
            | NewRow = 5

        and UpdateSerializeMode =
            | Cancel = 0
            | Default = 1
            | PropDataOnly = 2
            | PropLocalizedOnly = 3
            | PropBoth = 4

        and UpdateTrackingMode =
            | PropData = 0
            | PropLocalized = 1
            | PropBoth = 2

        and ReadOnlyActiveState =
            | ReadOnlyActive = 0
            | ReadOnlyDisabled = 1

        and [<AllowNullLiteral>] IValue =
            abstract data: obj option with get, set
            abstract localized: string option with get, set

        and SelectionTypeFlags =
            | MultipleCellRanges = 0
            | MultipleRowRanges = 1
            | MultipleColRanges = 2

        (*
        and [<AllowNullLiteral>] [<Import("JsGrid.JsGridControl","SP")>] JsGridControl(parentNode: HTMLElement, bShowLoadingBanner: bool) =
            member __.IsInitialized(): bool = jsNative
            member __.ResetData(cache: TableCache): unit = jsNative
            //member __.Init(parameters: Parameters): unit = jsNative
            member __.Cleanup(): unit = jsNative
            member __.Dispose(): unit = jsNative
            member __.NotifyDataAvailable(): unit = jsNative
            member __.NotifySave(): unit = jsNative
            member __.NotifyHide(): unit = jsNative
            member __.NotifyResize(): unit = jsNative
            member __.ClearTableView(): unit = jsNative
            member __.HideInitialLoadingBanner(): unit = jsNative
            member __.ShowInitialGridErrorMsg(errorMsg: string): unit = jsNative
            member __.ShowGridErrorMsg(errorMsg: string): unit = jsNative
            member __.LaunchPrintView(additionalScriptFiles: obj, beforeInitFnName: obj, beforeInitFnArgsObj: obj, title: string, bEnableGantt: bool, ?optGanttDelegateNames: obj, ?optInitTableViewParamsFnName: obj, ?optInitTableViewParamsFnArgsObj: obj, ?optInitGanttStylesFnName: obj, ?optInitGanttStylesFnArgsObj: obj): unit = jsNative
            member __.GetAllDataJson(fnOnFinished: obj, ?optFnGetCellStyleID: obj): unit = jsNative
            member __.SetTableView(tableViewParams: obj): unit = jsNative
            member __.SetRowView(rowViewParam: obj): unit = jsNative
            member __.Enable(): unit = jsNative
            member __.Disable(?optMsg: string): unit = jsNative
            member __.EnableEditing(): unit = jsNative
            member __.DisableEditing(): unit = jsNative
            member __.TryBeginEdit(): bool = jsNative
            member __.FinalizeEditing(fnContinue: Function, fnError: Function): unit = jsNative
            //member __.GetDiffTracker(): DiffTracker = jsNative
            member __.Focus(): unit = jsNative
            member __.TryCommitFirstEntryRecords(fnCommitComplete: obj): unit = jsNative
            member __.ClearUncommitedEntryRecords(): unit = jsNative
            member __.AnyUncommitedEntryRecords(): bool = jsNative
            member __.AnyUncomittedProvisionalRecords(): bool = jsNative
            member __.GetRecord(recordKey: float): IRecord = jsNative
            member __.GetEntryRecord(key: obj): obj = jsNative
            member __.IsEntryRecord(recordKey: float): bool = jsNative
            member __.IsCellEditable(record: IRecord, fieldKey: string, ?optPaneId: obj): bool = jsNative
            member __.AddBuiltInRowHeaderState(recordKey: float, rowHeaderStateId: string): unit = jsNative
            member __.AddRowHeaderState(recordKey: float, rowHeaderState: RowHeaderState): unit = jsNative
            member __.RemoveRowHeaderState(recordKey: float, rowHeaderStateId: string): unit = jsNative
            member __.GetCheckSelectionManager(): obj = jsNative
            member __.UpdateProperties(propertyUpdates: obj, changeName: obj, ?optChangeKey: obj): obj = jsNative
            member __.GetLastRecordKey(): string = jsNative
            member __.InsertProvisionalRecordBefore(beforeRecordKey: float, newRecord: obj, initialValues: obj): obj = jsNative
            member __.InsertProvisionalRecordAfter(afterRecordKey: float, newRecord: obj, initialValues: obj): obj = jsNative
            member __.IsProvisionalRecordKey(recordKey: float): bool = jsNative
            member __.InsertRecordBefore(beforeRecordKey: float, newRecord: obj, ?optChangeKey: obj): obj = jsNative
            member __.InsertRecordAfter(afterRecordKey: float, newRecord: obj, ?optChangeKey: obj): obj = jsNative
            member __.InsertHiddenRecord(recordKey: float, changeKey: obj, ?optAfterRecordKey: obj): obj = jsNative
            member __.DeleteRecords(recordKeys: obj, ?optChangeKey: obj): obj = jsNative
            member __.IndentRecords(recordKeys: obj, ?optChangeKey: obj): obj = jsNative
            member __.OutdentRecords(recordKeys: obj, ?optChangeKey: obj): obj = jsNative
            member __.ReorderRecords(beginRecordKey: float, endRecordKey: float, afterRecordKey: float, bSelectAfterwards: bool): obj = jsNative
            member __.GetContiguousRowSelectionWithoutEntryRecords(): obj = jsNative
            member __.CanMoveRecordsUpByOne(recordKeys: obj): bool = jsNative
            member __.CanMoveRecordsDownByOne(recordKeys: obj): bool = jsNative
            member __.MoveRecordsUpByOne(recordKeys: obj): obj = jsNative
            member __.MoveRecordsDownByOne(recordKeys: obj): obj = jsNative
            member __.GetReorderRange(recordKeys: obj): obj = jsNative
            member __.GetNodeExpandCollapseState(recordKey: float): obj = jsNative
            member __.ToggleExpandCollapse(recordKey: float): unit = jsNative
            (*member __.AttachEvent(eventType: JsGrid.EventType, fnOnEvent: obj): unit = jsNative
            member __.DetachEvent(eventType: JsGrid.EventType, fnOnEvent: obj): unit = jsNative
            member __.SetDelegate(delegateKey: JsGrid.DelegateType, fn: obj): unit = jsNative
            member __.GetDelegate(delegateKey: JsGrid.DelegateType): obj = jsNative*)
            member __.RefreshRow(recordKey: float): unit = jsNative
            member __.RefreshAllRows(): unit = jsNative
            member __.ClearChanges(): unit = jsNative
            member __.GetGanttZoomLevel(): obj = jsNative
            member __.SetGanttZoomLevel(level: obj): unit = jsNative
            member __.ScrollGanttToDate(date: obj): unit = jsNative
            member __.GetTopRecordIndex(): float = jsNative
            member __.GetViewRecordCount(): float = jsNative
            member __.GetRecordKeyByViewIndex(viewIdx: float): float = jsNative
            member __.GetViewIndexOfRecord(recordKey: float): float = jsNative
            member __.GetTopRowIndex(): float = jsNative
            member __.GetOutlineLevel(record: obj): obj = jsNative
            member __.GetSplitterPosition(): obj = jsNative
            member __.SetSplitterPosition(pos: obj): unit = jsNative
            member __.GetLeftColumnIndex(?optPaneId: obj): obj = jsNative
            member __.EnsurePaneWidth(): unit = jsNative
            member __.ShowColumn(columnKey: string, ?atIdx: float): unit = jsNative
            member __.HideColumn(columnKey: string): unit = jsNative
            member __.UpdateColumns(columnInfoCollection: ColumnInfoCollection): unit = jsNative
            member __.GetColumns(?optPaneId: string): ResizeArray<ColumnInfo> = jsNative
            member __.GetColumnByFieldKey(fieldKey: string, ?optPaneId: obj): ColumnInfo = jsNative
            member __.AddColumn(columnInfo: ColumnInfo, gridField: GridField): unit = jsNative
            member __.RenameColumn(columnKey: string): unit = jsNative
            member __.ShowColumnConfigurationDialog(): unit = jsNative
            member __.AnyErrors(): bool = jsNative
            member __.AnyErrorsInRecord(recordKey: float): bool = jsNative
            member __.SetCellError(recordKey: float, fieldKey: string, errorMessage: string): float = jsNative
            member __.SetRowError(recordKey: float, errorMessage: string): float = jsNative
            member __.ClearCellError(recordKey: float, fieldKey: string, id: float): unit = jsNative
            member __.ClearAllErrorsOnCell(recordKey: float, fieldKey: string): unit = jsNative
            member __.ClearRowError(recordKey: float, id: float): unit = jsNative
            member __.ClearAllErrorsOnRow(recordKey: float): unit = jsNative
            member __.GetCellErrorMessage(recordKey: float, fieldKey: string): string = jsNative
            member __.GetRowErrorMessage(recordKey: float): string = jsNative
            member __.ScrollToAndExpandNextError(?minId: float, ?fnFilter: obj): obj = jsNative
            member __.ScrollToAndExpandNextErrorOnRecord(?minId: float, ?recordKey: float, ?fnFilter: obj, ?bDontExpand: bool): obj = jsNative
            member __.GetFocusedItem(): obj = jsNative
            //member __.SendKeyDownEvent(eventInfo: DomEvent): obj = jsNative
            member __.JumpToEntryRecord(): unit = jsNative
            member __.SelectRowRange(rowIdx1: float, rowIdx2: float, bAppend: bool, ?optPaneId: string): unit = jsNative
            member __.SelectColumnRange(colIdx1: float, colIdx2: float, bAppend: bool, ?optPaneId: string): unit = jsNative
            member __.SelectCellRange(rowIdx1: float, rowIdx2: float, colIdx1: float, colIdx2: float, bAppend: bool, ?optPaneId: string): unit = jsNative
            member __.SelectRowRangeByKey(rowKey1: obj, rowKey2: obj, bAppend: bool, ?optPaneId: string): unit = jsNative
            member __.SelectColumnRangeByKey(colKey1: obj, colKey2: obj, bAppend: bool, ?optPaneId: string): unit = jsNative
            member __.SelectCellRangeByKey(recordKey1: string, recordKey2: string, colKey1: obj, colKey2: obj, bAppend: bool, ?optPaneId: string): unit = jsNative
            member __.ChangeKeys(oldKey: obj, newKey: obj): unit = jsNative
            member __.GetSelectedRowRanges(?optPaneId: obj): obj = jsNative
            member __.GetSelectedColumnRanges(?optPaneId: obj): obj = jsNative
            member __.GetSelectedRanges(?optPaneId: obj): obj = jsNative
            member __.MarkPropUpdateInvalid(recordKey: float, fieldKey: obj, changeKey: obj, ?optErrorMsg: obj): obj = jsNative
            member __.GetCurrentChangeKey(): obj = jsNative
            member __.CreateAndSynchronizeToNewChangeKey(): obj = jsNative
            member __.CreateDataUpdateCmd(bUseCustomInitialUpdate: bool): obj = jsNative
            member __.IsChangeKeyApplied(changeKey: obj): obj = jsNative
            member __.GetChangeKeyForVersion(version: obj): obj = jsNative
            member __.TryReadPropForChangeKey(recordKey: float, fieldKey: obj, changeKey: obj): obj = jsNative
            member __.GetUnfilteredHierarchyMap(): obj = jsNative
            member __.GetHierarchyState(bDecompressGuidKeys: bool): obj = jsNative
            member __.IsGroupingRecordKey(recordKey: float): bool = jsNative
            member __.IsGroupingColumnKey(recordKey: float): bool = jsNative
            member __.GetSelectedRecordKeys(bDuplicatesAllowed: bool): obj = jsNative
            member __.CutToClipboard(): unit = jsNative
            member __.CopyToClipboard(): unit = jsNative
            member __.PasteFromClipboard(): unit = jsNative
            member __.TryRestoreFocusAfterInsertOrDeleteColumns(origFocus: obj): unit = jsNative
            member __.GetUndoManager(): CommandManager = jsNative
            member __.GetVisibleRecordCount(): float = jsNative
            member __.GetRecordIndicatorCheckBoxColumnIndex(): float = jsNative
            member __.IsRecordVisibleInView(recordKey: float): bool = jsNative
            member __.GetHierarchyQueryObject(): obj = jsNative
            member __.GetSpCsrRenderCtx(): obj = jsNative *)

        and [<AllowNullLiteral>] IChangeKey =
            abstract Reserve: unit -> unit
            abstract Release: unit -> unit
            abstract GetVersionNumber: unit -> float
            abstract CompareTo: changeKey: IChangeKey -> float

        and EventType =
            | OnCellFocusChanged = 0
            | OnRowFocusChanged = 1
            | OnCellEditBegin = 2
            | OnCellEditCompleted = 3
            | OnRightClick = 4
            | OnPropertyChanged = 5
            | OnRecordInserted = 6
            | OnRecordDeleted = 7
            | OnRecordChecked = 8
            | OnCellErrorStateChanged = 9
            | OnEntryRecordAdded = 10
            | OnEntryRecordCommitted = 11
            | OnEntryRecordPropertyChanged = 12
            | OnRowErrorStateChanged = 13
            | OnDoubleClick = 14
            | OnBeforeGridDispose = 15
            | OnSingleCellClick = 16
            | OnInitialChangesForChangeKeyComplete = 17
            | OnVacateChange = 18
            | OnGridErrorStateChanged = 19
            | OnSingleCellKeyDown = 20
            | OnRecordsReordered = 21
            | OnBeforePropertyChanged = 22
            | OnRowEscape = 23
            | OnBeginRenameColumn = 24
            | OnEndRenameColumn = 25
            | OnPasteBegin = 26
            | OnPasteEnd = 27
            | OnBeginRedoDataUpdateChange = 28
            | OnBeginUndoDataUpdateChange = 29

        and DelegateType =
            | ExpandColumnMenu = 0
            | AddColumnMenuItems = 1
            | Sort = 2
            | Filter = 3
            | InsertRecord = 4
            | DeleteRecords = 5
            | IndentRecords = 6
            | OutdentRecords = 7
            | IsRecordInsertInView = 8
            | ExpandDelayLoadedHierarchyNode = 9
            | AutoFilter = 10
            | ExpandConflictResolution = 11
            | GetAutoFilterEntries = 12
            | LaunchFilterDialog = 13
            | ShowColumnConfigurationDialog = 14
            | GetRecordEditMode = 15
            | GetGridRowStyleId = 16
            | CreateEntryRecord = 17
            | TryInsertEntryRecord = 18
            | WillAddColumnMenuItems = 19
            | NextPage = 20
            | AddNewColumn = 21
            | RemoveColumnFromView = 22
            | ReorderColumnPositionInView = 23
            | TryCreateProvisionalRecord = 24
            | CanReorderRecords = 25
            | AddNewColumnMenuItems = 26
            | TryBeginPaste = 27
            | AllowSelectionChange = 28
            | GetFieldEditMode = 29
            | GetFieldReadOnlyActiveState = 30
            | OnBeforeRecordReordered = 31

        and ClickContext =
            | SelectAllSquare = 0
            | RowHeader = 1
            | ColumnHeader = 2
            | Cell = 3
            | Gantt = 4
            | Other = 5
        (*
        and [<AllowNullLiteral>] [<Import("JsGrid.RowHeaderState","SP")>] RowHeaderState(id: string, img: Image, priority: RowHeaderStatePriorities, tooltip: string, fnOnClick: obj) =
            member __.GetId(): string = jsNative
            member __.GetImg(): Image = jsNative
            member __.GetPriority(): RowHeaderStatePriorities = jsNative
            member __.GetOnClick(): obj = jsNative
            member __.GetTooltip(): string = jsNative
            member __.toString(): string = jsNative

        and [<AllowNullLiteral>] [<Import("JsGrid.Image","SP")>] Image(imgSrc: string, bIsClustered: bool, optOuterCssNames: string, optImgCssNames: string, bIsAnimated: bool) =
            member __.imgSrc with get(): string = jsNative and set(v: string): unit = jsNative
            member __.bIsClustered with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.optOuterCssNames with get(): string = jsNative and set(v: string): unit = jsNative
            member __.imgCssNames with get(): string = jsNative and set(v: string): unit = jsNative
            member __.bIsAnimated with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.Render(altText: string, clickFn: obj, bHideTooltip: bool): HTMLElement = jsNative

        and [<AllowNullLiteral>] IEventArgs =
            interface end

        and [<AllowNullLiteral>] [<Import("JsGrid.CommandManager","SP")>] CommandManager() =
            class end

        and [<AllowNullLiteral>] [<Import("JsGrid.TableCache","SP")>] TableCache() =
            class end

        and [<AllowNullLiteral>] IStyleManager =
            //abstract gridPaneStyle: IStyleType.GridPane with get, set
            abstract columnHeaderStyleCollection: obj with get, set
            abstract rowHeaderStyleCollection: obj with get, set
            abstract splitterStyleCollection: obj with get, set
            //abstract defaultCellStyle: IStyleType.Cell with get, set
            //abstract readOnlyCellStyle: IStyleType.Cell with get, set
            //abstract readOnlyFocusedCellStyle: IStyleType.Cell with get, set
            //abstract timescaleTierStyle: IStyleType.TimescaleTier with get, set
            abstract groupingStyles: ResizeArray<obj> with get, set
            //abstract widgetDockStyle: IStyleType.Widget with get, set
            //abstract widgetDockHoverStyle: IStyleType.Widget with get, set
            //abstract widgetDockPressedStyle: IStyleType.Widget with get, set
            //abstract RegisterCellStyle: styleId: string * cellStyle: IStyleType.Cell -> unit
            (*abstract GetCellStyle: styleId: string -> IStyleType.Cell
            abstract UpdateSplitterStyleFromCss: styleObject: IStyleType.Splitter * splitterStyleNameCollection: obj -> unit
            abstract UpdateHeaderStyleFromCss: styleObject: IStyleType.Header * headerStyleNameCol: obj -> unit
            abstract UpdateGridPaneStyleFromCss: styleObject: IStyleType.GridPane * gridStyleNameCollection: obj -> unit
            abstract UpdateDefaultCellStyleFromCss: styleObject: IStyleType.Cell * cssClass: string -> unit
            abstract UpdateGroupStylesFromCss: styleObject: IStyleType.Cell * prefix: string -> unit
            *)
        and [<AllowNullLiteral>] IStyleType =
            interface end

        and [<AllowNullLiteral>] [<Import("JsGrid.Style","SP")>] Style() =
            member __.Type with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.SetRTL with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.MakeJsGridStyleManager with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.CreateStyleFromCss with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.CreateStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.MergeCellStyles with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ApplyCellStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ApplyRowHeaderStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ApplyCornerHeaderBorderStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ApplyHeaderInnerBorderStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ApplyColumnContextMenuStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ApplySplitterStyle with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.MakeBorderString with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.GetCellStyleDefaultBackgroundColor with get(): obj = jsNative and set(v: obj): unit = jsNative

        and [<AllowNullLiteral>] [<Import("JsGrid.ColumnInfoCollection","SP")>] ColumnInfoCollection(colInfoArray: ResizeArray<obj>) =
            member __.GetColumnByKey(key: string): obj = jsNative
            member __.GetColumnArray(?bVisibleOnly: bool): ResizeArray<obj> = jsNative
            member __.GetColumnMap(): obj = jsNative
            member __.AppendColumn(colInfo: obj): unit = jsNative
            member __.InsertColumnAt(idx: float, colInfo: obj): unit = jsNative
            member __.RemoveColumn(key: string): unit = jsNative
            member __.GetColumnPosition(key: string): float = jsNative

        and [<AllowNullLiteral>] [<Import("JsGrid.ColumnInfo","SP")>] ColumnInfo(name: string, imgSrc: string, key: string, width: float) =
            member __.name with get(): string = jsNative and set(v: string): unit = jsNative
            member __.imgSrc with get(): string = jsNative and set(v: string): unit = jsNative
            member __.imgRawSrc with get(): string = jsNative and set(v: string): unit = jsNative
            member __.columnKey with get(): string = jsNative and set(v: string): unit = jsNative
            member __.fieldKeys with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
            member __.width with get(): float = jsNative and set(v: float): unit = jsNative
            member __.bOpenMenuOnContentClick with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.isVisible with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.isHidable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.isResizable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.isSortable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.isAutoFilterable with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.isFooter with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.fnShouldLinkSingleValue with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnSingleValueClicked with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnGetCellEditMode with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnGetDisplayControlName with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnGetEditControlName with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnGetWidgetControlNames with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnGetCellStyleId with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.fnGetSingleValueTooltip with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.ColumnType(): string = jsNative

        and [<AllowNullLiteral>] IRecord =
            abstract bIsNewRow: bool with get, set
            abstract properties: obj with get, set
            abstract key: unit -> float
            abstract GetDataValue: fieldKey: string -> obj
            abstract GetLocalizedValue: fieldKey: string -> string
            abstract HasDataValue: fieldKey: string -> bool
            abstract HasLocalizedValue: fieldKey: string -> bool
            abstract GetProp: fieldKey: string -> IPropertyBase
            abstract SetProp: fieldKey: string * prop: IPropertyBase -> unit
            abstract AddFieldValue: fieldKey: string * value: obj -> unit
            abstract RemoveFieldValue: fieldKey: string -> unit

        and [<AllowNullLiteral>] [<Import("JsGrid.RecordFactory","SP")>] RecordFactory(gridFieldMap: obj, keyColumnName: string, fnGetPropType: obj) =
            member __.gridFieldMap with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.MakeRecord(dataPropMap: obj, localizedPropMap: obj, bKeepRawData: bool): IRecord = jsNative

        and [<AllowNullLiteral>] IPropertyBase =
            abstract HasLocalizedValue: unit -> bool
            abstract HasDataValue: unit -> bool
            abstract Clone: unit -> IPropertyBase
            abstract Update: dataValue: obj * localizedValue: string -> unit
            abstract GetLocalized: unit -> string
            abstract GetData: unit -> obj

        and [<AllowNullLiteral>] [<Import("JsGrid.Property","SP")>] Property() =
            static member MakeProperty(dataValue: obj, localizedValue: string, bHasDataValue: bool, bHasLocalizedValue: bool, propType: obj): IPropertyBase = jsNative
            static member MakePropertyFromGridField(gridField: obj, dataValue: obj, localizedVal: string, ?optPropType: obj): IPropertyBase = jsNative

        and [<AllowNullLiteral>] [<Import("JsGrid.GridField","SP")>] GridField(key: string, hasDataValue: bool, hasLocalizedValue: bool, textDirection: TextDirection, ?defaultCellStyleId: obj, ?editMode: EditMode, ?dateOnly: bool, ?csrInfo: obj) =
            member __.key with get(): string = jsNative and set(v: string): unit = jsNative
            member __.hasDataValue with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.hasLocalizedValue with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.textDirection with get(): TextDirection = jsNative and set(v: TextDirection): unit = jsNative
            member __.dateOnly with get(): bool = jsNative and set(v: bool): unit = jsNative
            member __.csrInfo with get(): obj = jsNative and set(v: obj): unit = jsNative
            member __.GetEditMode(): EditMode = jsNative
            member __.SetEditMode(mode: EditMode): unit = jsNative
            member __.GetDefaultCellStyleId(): obj = jsNative
            member __.CompareSingleDataEqual(dataValue1: obj, dataValue2: obj): bool = jsNative
            member __.GetPropType(): obj = jsNative
            member __.GetSingleValuePropType(): obj = jsNative
            member __.GetMultiValuePropType(): obj = jsNative
            member __.SetSingleValuePropType(svPropType: obj): unit = jsNative
            member __.SetIsMultiValue(listSeparator: obj): unit = jsNative
            member __.GetIsMultiValue(): bool = jsNative

        and [<AllowNullLiteral>] IEditActorGridContext =
            abstract jsGridObj: JsGridControl with get, set
            abstract parentNode: HTMLElement with get, set
            abstract styleManager: IStyleManager with get, set
            abstract RTL: obj with get, set
            abstract emptyValue: obj with get, set
            abstract bLightFocus: bool with get, set
            abstract OnKeyDown: obj with get, set

        and [<AllowNullLiteral>] IEditControlGridContext =
            inherit IEditActorGridContext
            abstract OnActivateActor: unit -> unit
            abstract OnDeactivateActor: unit -> unit

        and [<AllowNullLiteral>] IPropertyType =
            abstract ID: string with get, set
            abstract BeginValidateNormalizeConvert: recordKey: float * fieldKey: string * newValue: obj * bIsLocalized: bool * fnCallback: obj * fnError: obj -> unit

        and [<AllowNullLiteral>] ILookupPropertyType =
            inherit IPropertyType
            abstract GetItems: fnCallback: obj -> unit
            abstract DataToLocalized: dataValue: obj -> string
            abstract LocalizedToData: localized: string -> obj
            abstract GetImageSource: record: IRecord * dataValue: obj -> string
            abstract GetStyleId: dataValue: obj -> string
            abstract GetIsLimitedToList: unit -> bool
            abstract GetSerializableLookupPropType: unit -> obj

        and [<AllowNullLiteral>] IMultiValuePropertyType =
            inherit IPropertyType
            abstract bMultiValue: bool with get, set
            abstract separator: string with get, set
            abstract singleValuePropType: string with get, set
            abstract GetSerializableMultiValuePropType: unit -> obj
            abstract InitSingleValuePropType: unit -> unit
            abstract LocStrToLocStrArray: locStr: string -> ResizeArray<string>
            abstract LocStrArrayToLocStr: locStrArray: ResizeArray<string> -> string

        and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType","SP")>] PropertyType() =
            static member RegisterNewLookupPropType(id: string, items: ResizeArray<obj>, displayCtrlName: string, bLimitToList: bool): unit = jsNative
            static member RegisterNewCustomPropType(propType: IPropertyType, displayCtrlName: string, editControlName: string, widgetControlNames: ResizeArray<string>): unit = jsNative
            static member RegisterNewDerivedCustomPropType(propType: IPropertyType, baseTypeName: string): unit = jsNative

        and [<AllowNullLiteral>] IEditActorCellContext =
            abstract propType: IPropertyType with get, set
            abstract originalValue: IValue with get, set
            abstract record: IRecord with get, set
            abstract column: ColumnInfo with get, set
            abstract field: GridField with get, set
            abstract fieldKey: string with get, set
            abstract cellExpandSpace: obj with get, set
            abstract SetCurrentValue: value: obj -> unit

        and [<AllowNullLiteral>] IEditControlCellContext =
            inherit IEditActorCellContext
            abstract cellWidth: float with get, set
            abstract cellHeight: float with get, set
            abstract cellStyle: obj with get, set
            abstract cellRect: obj with get, set
            abstract NotifyExpandControl: unit -> unit
            abstract NotifyEditComplete: unit -> unit
            abstract Show: element: HTMLElement -> unit
            abstract Hide: element: HTMLElement -> unit

        and [<AllowNullLiteral>] IEditControl =
            abstract SupportedWriteMode: EditActorWriteType option with get, set
            abstract SupportedReadMode: EditActorReadType option with get, set
            abstract GetCellContext: unit -> IEditControlCellContext
            abstract GetOriginalValue: unit -> IValue
            abstract SetValue: value: IValue -> unit
            abstract Dispose: unit -> unit
            abstract GetInputElement: unit -> HTMLElement
            //abstract Focus: eventInfo: DomEvent -> unit
            abstract BindToCell: cellContext: IEditControlCellContext -> unit
            //abstract OnBeginEdit: eventInfo: DomEvent -> unit
            abstract Unbind: unit -> unit
            abstract OnEndEdit: unit -> unit
            abstract OnCellMove: unit -> unit
            abstract OnValueChanged: newValue: IValue -> unit
            abstract IsCurrentlyUsingGridTextInputElement: unit -> bool
            abstract SetSize: width: float * height: float -> unit

        and [<AllowNullLiteral>] [<Import("JsGrid.StaticDataSource","SP")>] StaticDataSource(jsGridData: IGridData, ?optFnGetPropType: Function) =
            member __.AddColumn(gridField: GridField, values: ResizeArray<IValue>): unit = jsNative
            member __.RemoveColumn(fieldKey: string): unit = jsNative
            //member __.InitJsGridParams(?optGridParams: JsGridControl.Parameters): JsGridControl.Parameters = jsNative

        and [<AllowNullLiteral>] IGridData =
            abstract MetaData: IGridMetadata with get, set
            abstract Fields: ResizeArray<IFieldInfo> with get, set
            abstract Columns: ResizeArray<IColumnInfo> with get, set
            abstract LocalizedTable: ResizeArray<obj> with get, set
            abstract UnlocalizedTable: ResizeArray<obj> with get, set
            abstract ViewInfo: ResizeArray<obj> with get, set
            abstract MultiValueSeparator: string option with get, set
            abstract LookupTableInfo: ResizeArray<ILookupTableInfo> option with get, set
            abstract PivotedColumns: ResizeArray<ColumnInfo> option with get, set
            abstract PaneLayout: PaneLayout option with get, set
            abstract GanttInfo: obj option with get, set
            abstract AutoFilterableColumns: bool option with get, set
            abstract AutoFilterState: obj option with get, set
            abstract SortState: ResizeArray<obj> option with get, set
            abstract HierarchyState: obj option with get, set
            abstract TopRecord: float option with get, set
            abstract RecordCount: float option with get, set
            abstract AdditionalParams: obj option with get, set
            abstract CellStyles: obj option with get, set
            abstract GroupingGridRowStyleIds: ResizeArray<obj> option with get, set
            abstract UnfilteredHierarchy: obj option with get, set
            abstract AutoFilterEntries: obj option with get, set
            abstract ViewDepKeys: ResizeArray<obj> option with get, set

        and [<AllowNullLiteral>] IColumnInfo =
            abstract name: string with get, set
            abstract imgSrc: string option with get, set
            abstract columnKey: string with get, set
            abstract fieldKey: string with get, set
            abstract fieldKeys: ResizeArray<string> with get, set
            abstract width: float with get, set
            abstract isVisible: bool option with get, set
            abstract isHidable: bool option with get, set
            abstract isResizable: bool option with get, set
            abstract isSortable: bool option with get, set
            abstract isAutoFilterable: bool option with get, set
            abstract isFooter: bool option with get, set

        and [<AllowNullLiteral>] IGridMetadata =
            abstract KeyColumnName: string with get, set
            abstract IsGanttEnabled: bool option with get, set
            abstract IsHierarchyEnabled: bool option with get, set
            abstract IsSorted: bool option with get, set
            abstract GroupingLevel: float option with get, set
            abstract GroupingPrefix: string option with get, set
            abstract RecordKeyHash: string option with get, set
            abstract RecordKeyOrderChanged: obj option with get, set
            abstract GridOperationalConstantsFieldKeyMap: obj option with get, set

        and [<AllowNullLiteral>] IFieldInfo =
            abstract fieldKey: string with get, set
            abstract propertyTypeId: string with get, set
            abstract editMode: EditMode option with get, set
            abstract hasDataValue: bool option with get, set
            abstract hasLocalizedValue: bool option with get, set
            abstract multiValue: bool option with get, set
            abstract textDirection: TextDirection option with get, set
            abstract dateOnly: bool option with get, set
            abstract defaultCellStyleId: obj option with get, set

        and [<AllowNullLiteral>] ILookupTableInfo =
            abstract id: string with get, set
            abstract showImage: bool option with get, set
            abstract showText: bool option with get, set
            abstract limitToList: bool option with get, set
            abstract lookup: ResizeArray<ILookupInfo> with get, set

        and [<AllowNullLiteral>] ILookupInfo =
            abstract localString: string with get, set
            abstract value: float with get, set

        module RowHeaderStyleId =
            type [<Import("JsGrid.RowHeaderStyleId","SP")>] Globals =
                static member Transfer with get(): string = jsNative and set(v: string): unit = jsNative
                static member Conflict with get(): string = jsNative and set(v: string): unit = jsNative



        module RowHeaderAutoStyleId =
            type [<Import("JsGrid.RowHeaderAutoStyleId","SP")>] Globals =
                static member Dirty with get(): string = jsNative and set(v: string): unit = jsNative
                static member Error with get(): string = jsNative and set(v: string): unit = jsNative
                static member NewRow with get(): string = jsNative and set(v: string): unit = jsNative



        module UserAction =
            type [<Import("JsGrid.UserAction","SP")>] Globals =
                static member UserEdit with get(): string = jsNative and set(v: string): unit = jsNative
                static member DeleteRecord with get(): string = jsNative and set(v: string): unit = jsNative
                static member InsertRecord with get(): string = jsNative and set(v: string): unit = jsNative
                static member Indent with get(): string = jsNative and set(v: string): unit = jsNative
                static member Outdent with get(): string = jsNative and set(v: string): unit = jsNative
                static member Fill with get(): string = jsNative and set(v: string): unit = jsNative
                static member Paste with get(): string = jsNative and set(v: string): unit = jsNative
                static member CutPaste with get(): string = jsNative and set(v: string): unit = jsNative



        module EventArgs =
            type [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnEntryRecordAdded","SP")>] OnEntryRecordAdded(recordKey: float) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.CellFocusChanged","SP")>] CellFocusChanged(newRecordKey: float, newFieldKey: string, oldRecordKey: float, oldFieldKey: string) =
                interface IEventArgs
                member __.newRecordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.newFieldKey with get(): string = jsNative and set(v: string): unit = jsNative
                member __.oldRecordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.oldFieldKey with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.RowFocusChanged","SP")>] RowFocusChanged(newRecordKey: float, oldRecordKey: float) =
                interface IEventArgs
                member __.newRecordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.oldRecordKey with get(): float = jsNative and set(v: float): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.CellEditBegin","SP")>] CellEditBegin(recordKey: float, fieldKey: string) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative

           // and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.CellEditCompleted","SP")>] CellEditCompleted(recordKey: float, fieldKey: string, changeKey: JsGrid.IChangeKey, bCancelled: bool) =
            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.CellEditCompleted","SP")>] CellEditCompleted(recordKey: float, fieldKey: string, changeKey: obj, bCancelled: bool) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative
                //member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative
                member __.bCancelled with get(): bool = jsNative and set(v: bool): unit = jsNative

            //and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.Click","SP")>] Click(eventInfo: DomEvent, context: JsGrid.ClickContext, recordKey: float, fieldKey: string) =
            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.Click","SP")>] Click(eventInfo: obj, context: obj, recordKey: float, fieldKey: string) =
                interface IEventArgs
                member __.eventInfo with get(): DomEvent = jsNative and set(v: DomEvent): unit = jsNative
                member __.context with get(): JsGrid.ClickContext = jsNative and set(v: JsGrid.ClickContext): unit = jsNative
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.PropertyChanged","SP")>] PropertyChanged(recordKey: float, fieldKey: string, oldProp: PropertyUpdate, newProp: PropertyUpdate, propType: IPropertyType, changeKey: IChangeKey, validationState: ValidationState) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative
                member __.oldProp with get(): PropertyUpdate = jsNative and set(v: PropertyUpdate): unit = jsNative
                member __.newProp with get(): PropertyUpdate = jsNative and set(v: PropertyUpdate): unit = jsNative
                member __.propType with get(): IPropertyType = jsNative and set(v: IPropertyType): unit = jsNative
                member __.changeKey with get(): IChangeKey = jsNative and set(v: IChangeKey): unit = jsNative
                member __.validationState with get(): ValidationState = jsNative and set(v: ValidationState): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.RecordInserted","SP")>] RecordInserted(recordKey: float, recordIdx: float, afterRecordKey: float, changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.recordIdx with get(): float = jsNative and set(v: float): unit = jsNative
                member __.afterRecordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.RecordDeleted","SP")>] RecordDeleted(recordKey: float, recordIdx: float, changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.recordIdx with get(): float = jsNative and set(v: float): unit = jsNative
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.RecordChecked","SP")>] RecordChecked(recordKeySet: Set, bChecked: bool) =
                interface IEventArgs
                member __.recordKeySet with get(): Set = jsNative and set(v: Set): unit = jsNative
                member __.bChecked with get(): bool = jsNative and set(v: bool): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnCellErrorStateChanged","SP")>] OnCellErrorStateChanged(recordKey: float, fieldKey: string, bAddingError: bool, bCellCurrentlyHasError: bool, bCellHadError: bool, errorId: float) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative
                member __.bAddingError with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bCellCurrentlyHasError with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bCellHadError with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.errorId with get(): float = jsNative and set(v: float): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnRowErrorStateChanged","SP")>] OnRowErrorStateChanged(recordKey: float, bAddingError: bool, bErrorCurrentlyInRow: bool, bRowHadError: bool, errorId: float, message: string) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.bAddingError with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bErrorCurrentlyInRow with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bRowHadError with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.errorId with get(): float = jsNative and set(v: float): unit = jsNative
                member __.message with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnEntryRecordCommitted","SP")>] OnEntryRecordCommitted(origRecKey: string, recordKey: float, changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.originalRecordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.SingleCellClick","SP")>] SingleCellClick(eventInfo: DomEvent, recordKey: float, fieldKey: string) =
                interface IEventArgs
                member __.eventInfo with get(): DomEvent = jsNative and set(v: DomEvent): unit = jsNative
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.PendingChangeKeyInitiallyComplete","SP")>] PendingChangeKeyInitiallyComplete(changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.VacateChange","SP")>] VacateChange(changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.GridErrorStateChanged","SP")>] GridErrorStateChanged(bAnyErrors: bool) =
                interface IEventArgs
                member __.bAnyErrors with get(): bool = jsNative and set(v: bool): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.SingleCellKeyDown","SP")>] SingleCellKeyDown(eventInfo: DomEvent, recordKey: float, fieldKey: string) =
                interface IEventArgs
                member __.eventInfo with get(): DomEvent = jsNative and set(v: DomEvent): unit = jsNative
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative
                member __.fieldKey with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnRecordsReordered","SP")>] OnRecordsReordered(recordKeys: ResizeArray<string>, changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.reorderedKeys with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnRowEscape","SP")>] OnRowEscape(recordKey: float) =
                interface IEventArgs
                member __.recordKey with get(): float = jsNative and set(v: float): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnEndRenameColumn","SP")>] OnEndRenameColumn(columnKey: string, originalColumnTitle: string, newColumnTitle: string) =
                interface IEventArgs
                member __.columnKey with get(): string = jsNative and set(v: string): unit = jsNative
                member __.originalColumnTitle with get(): string = jsNative and set(v: string): unit = jsNative
                member __.newColumnTitle with get(): string = jsNative and set(v: string): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnBeginRedoDataUpdateChange","SP")>] OnBeginRedoDataUpdateChange(changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.EventArgs.OnBeginUndoDataUpdateChange","SP")>] OnBeginUndoDataUpdateChange(changeKey: JsGrid.IChangeKey) =
                interface IEventArgs
                member __.changeKey with get(): JsGrid.IChangeKey = jsNative and set(v: JsGrid.IChangeKey): unit = jsNative



        module JsGridControl =
            type [<AllowNullLiteral>] [<Import("JsGrid.JsGridControl.Parameters","SP")>] Parameters() =
                member __.tableCache with get(): TableCache = jsNative and set(v: TableCache): unit = jsNative
                member __.name with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.bNotificationsEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.styleManager with get(): IStyleManager = jsNative and set(v: IStyleManager): unit = jsNative
                member __.minHeaderHeight with get(): float = jsNative and set(v: float): unit = jsNative
                member __.minRowHeight with get(): float = jsNative and set(v: float): unit = jsNative
                member __.commandMgr with get(): CommandManager = jsNative and set(v: CommandManager): unit = jsNative
                member __.enabledRowHeaderAutoStates with get(): Set = jsNative and set(v: Set): unit = jsNative
                member __.tableViewParams with get(): TableViewParameters = jsNative and set(v: TableViewParameters): unit = jsNative
                member __.bEnableDiffTracking with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.isRTL with get(): bool = jsNative and set(v: bool): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.JsGridControl.TableViewParameters","SP")>] TableViewParameters() =
                member __.paneLayout with get(): PaneLayout = jsNative and set(v: PaneLayout): unit = jsNative
                member __.defaultEditMode with get(): EditMode = jsNative and set(v: EditMode): unit = jsNative
                member __.allowedSelectionTypes with get(): SelectionTypeFlags = jsNative and set(v: SelectionTypeFlags): unit = jsNative
                member __.bMovableColumns with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bResizableColumns with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bHidableColumns with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bSortableColumns with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bAutoFilterableColumns with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bRowHeadersEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bRecordIndicatorCheckboxesEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bFillControlEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bEditingEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.bNewRowEnabled with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.checkSelectionCheckboxHiddenRecordKeys with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
                member __.checkSelectionCheckboxDisabledRecordKeys with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
                member __.checkSelectionCheckedRecordKeys with get(): ResizeArray<string> = jsNative and set(v: ResizeArray<string>): unit = jsNative
                member __.keyFieldName with get(): string = jsNative and set(v: string): unit = jsNative
                member __.gridFieldMap with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.columns with get(): ColumnInfoCollection = jsNative and set(v: ColumnInfoCollection): unit = jsNative
                member __.messageOverrides with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.operationalConstantsFieldKeyMap with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.ganttParams with get(): GanttParameters = jsNative and set(v: GanttParameters): unit = jsNative
                member __.pivotedGridParams with get(): PivotedGridParameters = jsNative and set(v: PivotedGridParameters): unit = jsNative
                member __.rowViewParams with get(): RowViewParameters = jsNative and set(v: RowViewParameters): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.JsGridControl.PivotedGridParameters","SP")>] PivotedGridParameters() =
                class end

            and [<AllowNullLiteral>] [<Import("JsGrid.JsGridControl.GanttParameters","SP")>] GanttParameters() =
                member __.columns with get(): ColumnInfoCollection = jsNative and set(v: ColumnInfoCollection): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.JsGridControl.RowViewParameters","SP")>] RowViewParameters() =
                member __.hierarchyMode with get(): HierarchyMode = jsNative and set(v: HierarchyMode): unit = jsNative
                member __.view with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.topViewIdx with get(): float = jsNative and set(v: float): unit = jsNative
                member __.groupingLevel with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.groupingRecordKeyPrefix with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.autoFilterState with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.unfilteredHierarchyMgr with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.hierarchyDelayLoadKeys with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.hierarchyState with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.sortState with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.filterState with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.autoFilterEntries with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.filteredDescCounts with get(): obj = jsNative and set(v: obj): unit = jsNative



        module IStyleType =
            type [<AllowNullLiteral>] Splitter =
                inherit IStyleType
                abstract outerBorderColor: obj with get, set
                abstract leftInnerBorderColor: obj with get, set
                abstract innerBorderColor: obj with get, set
                abstract backgroundColor: obj with get, set

            and [<AllowNullLiteral>] SplitterHandle =
                inherit IStyleType
                abstract outerBorderColor: obj with get, set
                abstract leftInnerBorderColor: obj with get, set
                abstract innerBorderColor: obj with get, set
                abstract backgroundColor: obj with get, set
                abstract gripUpperColor: obj with get, set
                abstract gripLowerColor: obj with get, set

            and [<AllowNullLiteral>] GridPane =
                abstract verticalBorderColor: obj with get, set
                abstract verticalBorderStyle: obj with get, set
                abstract horizontalBorderColor: obj with get, set
                abstract horizontalBorderStyle: obj with get, set
                abstract backgroundColor: obj with get, set
                abstract columnDropIndicatorColor: obj with get, set
                abstract rowDropIndicatorColor: obj with get, set
                abstract linkColor: obj with get, set
                abstract visitedLinkColor: obj with get, set
                abstract copyRectForeBorderColor: obj with get, set
                abstract copyRectBackBorderColor: obj with get, set
                abstract focusRectBorderColor: obj with get, set
                abstract selectionRectBorderColor: obj with get, set
                abstract selectedCellBgColor: obj with get, set
                abstract SelectionRectBorderColor: obj with get, set
                abstract changeHighlightCellBgColor: obj with get, set
                abstract fillRectBorderColor: obj with get, set
                abstract errorRectBorderColor: obj with get, set

            and [<AllowNullLiteral>] Header =
                abstract font: obj with get, set
                abstract fontSize: obj with get, set
                abstract fontWeight: obj with get, set
                abstract textColor: obj with get, set
                abstract backgroundColor: obj with get, set
                abstract outerBorderColor: obj with get, set
                abstract innerBorderColor: obj with get, set
                abstract eyeBrowBorderColor: obj with get, set
                abstract eyeBrowColor: obj with get, set
                abstract menuColor: obj with get, set
                abstract menuBorderColor: obj with get, set
                abstract resizeColor: obj with get, set
                abstract resizeBorderColor: obj with get, set
                abstract menuHoverColor: obj with get, set
                abstract menuHoverBorderColor: obj with get, set
                abstract resizeHoverColor: obj with get, set
                abstract resizeHoverBorderColor: obj with get, set
                abstract eyeBrowHoverColor: obj with get, set
                abstract eyeBrowHoverBorderColor: obj with get, set
                abstract elementClickColor: obj with get, set
                abstract elementClickBorderColor: obj with get, set

            and [<AllowNullLiteral>] Cell =
                inherit IStyleType
                abstract font: obj with get, set
                abstract fontSize: obj with get, set
                abstract fontWeight: obj with get, set
                abstract fontStyle: obj with get, set
                abstract textColor: obj with get, set
                abstract backgroundColor: obj with get, set
                abstract textAlign: obj with get, set

            and [<AllowNullLiteral>] Widget =
                abstract backgroundColor: obj with get, set
                abstract borderColor: obj with get, set

            and [<AllowNullLiteral>] RowHeaderStyle =
                abstract backgroundColor: obj with get, set
                abstract outerBorderColor: obj with get, set
                abstract innerBorderColor: obj with get, set

            and [<AllowNullLiteral>] TimescaleTier =
                abstract font: obj with get, set
                abstract fontSize: obj with get, set
                abstract fontWeight: obj with get, set
                abstract textColor: obj with get, set
                abstract backgroundColor: obj with get, set
                abstract verticalBorderColor: obj with get, set
                abstract verticalBorderStyle: obj with get, set
                abstract horizontalBorderColor: obj with get, set
                abstract horizontalBorderStyle: obj with get, set
                abstract outerBorderColor: obj with get, set
                abstract todayLineColor: obj with get, set



        module PropertyType =
            type [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.String","SP")>] String() =
                interface IPropertyType
                member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
                member __.BeginValidateNormalizeConvert(recordKey: float, fieldKey: string, newValue: obj, bIsLocalized: bool, fnCallback: obj, fnError: obj): unit = jsNative
                member __.toString(): string = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.LookupTable","SP")>] LookupTable(items: ResizeArray<obj>, id: string, bLimitToList: bool) =
                interface ILookupPropertyType
                member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
                member __.BeginValidateNormalizeConvert(recordKey: float, fieldKey: string, newValue: obj, bIsLocalized: bool, fnCallback: obj, fnError: obj): unit = jsNative
                member __.GetItems(fnCallback: obj): unit = jsNative
                member __.DataToLocalized(dataValue: obj): string = jsNative
                member __.LocalizedToData(localized: string): obj = jsNative
                member __.GetImageSource(record: IRecord, dataValue: obj): string = jsNative
                member __.GetStyleId(dataValue: obj): string = jsNative
                member __.GetIsLimitedToList(): bool = jsNative
                member __.GetSerializableLookupPropType(): obj = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.CheckBoxBoolean","SP")>] CheckBoxBoolean() =
                interface IPropertyType
                member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
                member __.BeginValidateNormalizeConvert(recordKey: float, fieldKey: string, newValue: obj, bIsLocalized: bool, fnCallback: obj, fnError: obj): unit = jsNative
                member __.DataToLocalized(dataValue: obj): string = jsNative
                member __.GetBool(dataValue: obj): bool = jsNative
                member __.toString(): string = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.DropDownBoolean","SP")>] DropDownBoolean() =
                interface IPropertyType
                member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
                member __.BeginValidateNormalizeConvert(recordKey: float, fieldKey: string, newValue: obj, bIsLocalized: bool, fnCallback: obj, fnError: obj): unit = jsNative
                member __.DataToLocalized(dataValue: obj): string = jsNative
                member __.GetBool(dataValue: obj): bool = jsNative
                member __.toString(): string = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.MultiValuePropType","SP")>] MultiValuePropType() =
                interface IMultiValuePropertyType
                member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
                member __.bMultiValue with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.separator with get(): string = jsNative and set(v: string): unit = jsNative
                member __.singleValuePropType with get(): string = jsNative and set(v: string): unit = jsNative
                member __.BeginValidateNormalizeConvert(recordKey: float, fieldKey: string, newValue: obj, bIsLocalized: bool, fnCallback: obj, fnError: obj): unit = jsNative
                member __.GetSerializableMultiValuePropType(): obj = jsNative
                member __.InitSingleValuePropType(): unit = jsNative
                member __.LocStrToLocStrArray(locStr: string): ResizeArray<string> = jsNative
                member __.LocStrArrayToLocStr(locStrArray: ResizeArray<string>): string = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.HyperLink","SP")>] HyperLink() =
                interface IPropertyType
                member __.ID with get(): string = jsNative and set(v: string): unit = jsNative
                member __.bHyperlink with get(): bool = jsNative and set(v: bool): unit = jsNative
                member __.BeginValidateNormalizeConvert(recordKey: float, fieldKey: string, newValue: obj, bIsLocalized: bool, fnCallback: obj, fnError: obj): unit = jsNative
                member __.DataToLocalized(dataValue: obj): string = jsNative
                member __.GetAddress(dataValue: obj): string = jsNative
                member __.GetCopyValue(record: IRecord, dataValue: obj, locValue: string): string = jsNative
                member __.toString(): string = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.PropertyType.Utils","SP")>] Utils() =
                static member RegisterDisplayControl(name: string, singleton: obj, requiredFunctionNames: ResizeArray<string>): unit = jsNative
                static member RegisterEditControl(name: string, factory: Func<IEditControlGridContext, HTMLElement, IEditControl>, requiredFunctionNames: ResizeArray<string>): unit = jsNative
                static member RegisterWidgetControl(name: string, factory: obj, requiredFunctionNames: ResizeArray<string>): unit = jsNative
                static member UpdateDisplayControlForPropType(propTypeName: string, displayControlType: string): unit = jsNative



        module WidgetControl =
            type [<AllowNullLiteral>] [<Import("JsGrid.WidgetControl.Type","SP")>] Type() =
                member __.Demo with get(): string = jsNative and set(v: string): unit = jsNative
                member __.Date with get(): string = jsNative and set(v: string): unit = jsNative
                member __.AddressBook with get(): string = jsNative and set(v: string): unit = jsNative
                member __.Hyperlink with get(): string = jsNative and set(v: string): unit = jsNative



        module Internal =
            type [<AllowNullLiteral>] [<Import("JsGrid.Internal.DiffTracker","SP")>] DiffTracker(objBag: obj, fnGetChange: Function) =
                member __.ExternalAPI with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.Clear(): unit = jsNative
                member __.NotifySynchronizeToChange(changeKey: IChangeKey): unit = jsNative
                member __.NotifyRollbackChange(changeKey: IChangeKey): unit = jsNative
                member __.NotifyVacateChange(changeKey: IChangeKey): unit = jsNative

            and [<AllowNullLiteral>] [<Import("JsGrid.Internal.PropertyUpdate","SP")>] PropertyUpdate(data: obj, localized: string) =
                interface IValue
                member __.data with get(): obj = jsNative and set(v: obj): unit = jsNative
                member __.localized with get(): string = jsNative and set(v: string): unit = jsNative



        module EditControl =


    module Utilities =
        type [<AllowNullLiteral>] [<Import("Utilities.Set","SP")>] Set(?items: obj) =
            member __.IsEmpty(): bool = jsNative
            member __.First(): obj = jsNative
            member __.GetCollection(): obj = jsNative
            member __.ToArray(): ResizeArray<obj> = jsNative
            member __.AddArray(array: ResizeArray<obj>): Set = jsNative
            member __.Add(item: obj): obj = jsNative
            member __.Remove(item: obj): obj = jsNative
            member __.Clear(): Set = jsNative
            member __.Contains(item: obj): bool = jsNative
            member __.Clone(): Set = jsNative
            member __.SymmetricDifference(otherSet: Set): Set = jsNative
            member __.Difference(otherSet: Set): Set = jsNative
            member __.Union(otherSet: Set): Set = jsNative
            member __.UnionWith(otherSet: Set): Set = jsNative
            member __.Intersection(otherSet: Set): Set = jsNative



module SP =
    type [<AllowNullLiteral>] [<Import("GanttControl","SP")>] GanttControl() =
        member __.Instances with get(): ResizeArray<GanttControl> = jsNative and set(v: ResizeArray<GanttControl>): unit = jsNative
        member __.FnGanttCreationCallback with get(): ResizeArray<obj> = jsNative and set(v: ResizeArray<obj>): unit = jsNative
        static member WaitForGanttCreation(callack: Func<GanttControl, unit>): unit = jsNative
        member __.get_Columns(): ResizeArray<ColumnInfo> = jsNative


*)
