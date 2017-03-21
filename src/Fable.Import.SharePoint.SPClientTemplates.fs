namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module SPClientTemplates =
    type FileSystemObjectType =
        | Invalid = 0
        | File = 1
        | Folder = 2
        | Web = 3

    and ChoiceFormatType =
        | Dropdown = 0
        | Radio = 1

    and ClientControlMode =
        | Invalid = 0
        | DisplayForm = 1
        | EditForm = 2
        | NewForm = 3
        | View = 4

    and RichTextMode =
        | Compatible = 0
        | FullHtml = 1
        | HtmlAsXml = 2
        | ThemeHtml = 3

    and UrlFormatType =
        | Hyperlink = 0
        | Image = 1

    and DateTimeDisplayFormat =
        | DateOnly = 0
        | DateTime = 1
        | TimeOnly = 2

    and DateTimeCalendarType =
        | None = 0
        | Gregorian = 1
        | Japan = 2
        | Taiwan = 3
        | Korea = 4
        | Hijri = 5
        | Thai = 6
        | Hebrew = 7
        | GregorianMEFrench = 8
        | GregorianArabic = 9
        | GregorianXLITEnglish = 10
        | GregorianXLITFrench = 11
        | KoreaJapanLunar = 12
        | ChineseLunar = 13
        | SakaEra = 14
        | UmAlQura = 15

    and UserSelectionMode =
        | PeopleOnly = 0
        | PeopleAndGroups = 1

    and [<AllowNullLiteral>] FieldSchema_InForm_Choice =
        inherit FieldSchema_InForm
        abstract Choices: ResizeArray<string> with get, set
        abstract FormatType: ChoiceFormatType with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_Lookup =
        inherit FieldSchema_InForm
        abstract AllowMultipleValues: bool with get, set
        abstract BaseDisplayFormUrl: string with get, set
        abstract DependentLookup: bool with get, set
        abstract Throttled: bool with get, set
        abstract MaxQueryResult: string with get, set
        abstract Choices: ResizeArray<obj> with get, set
        abstract ChoiceCount: float with get, set
        abstract LookupListId: string with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_DateTime =
        inherit FieldSchema_InForm
        abstract CalendarType: DateTimeCalendarType with get, set
        abstract DisplayFormat: DateTimeDisplayFormat with get, set
        abstract ShowWeekNumber: bool with get, set
        abstract TimeSeparator: string with get, set
        abstract TimeZoneDifference: string with get, set
        abstract FirstDayOfWeek: float with get, set
        abstract FirstWeekOfYear: float with get, set
        abstract HijriAdjustment: float with get, set
        abstract WorkWeek: string with get, set
        abstract LocaleId: string with get, set
        abstract LanguageId: string with get, set
        abstract MinJDay: float with get, set
        abstract MaxJDay: float with get, set
        abstract HoursMode24: bool with get, set
        abstract HoursOptions: ResizeArray<string> with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_Geolocation =
        inherit FieldSchema_InForm
        abstract BingMapsKey: string with get, set
        abstract IsBingMapBlockedInCurrentRegion: bool with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_MultiChoice =
        inherit FieldSchema_InForm
        abstract MultiChoices: ResizeArray<string> with get, set
        abstract FillInChoice: bool with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_MultiLineText =
        inherit FieldSchema_InForm
        abstract RichText: bool with get, set
        abstract AppendOnly: bool with get, set
        abstract RichTextMode: RichTextMode with get, set
        abstract NumberOfLines: float with get, set
        abstract AllowHyperlink: bool with get, set
        abstract ScriptEditorAdderId: string with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_Number =
        inherit FieldSchema_InForm
        abstract ShowAsPercentage: bool with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_Text =
        inherit FieldSchema_InForm
        abstract MaxLength: float with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_Url =
        inherit FieldSchema_InForm
        abstract DisplayFormat: UrlFormatType with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm_User =
        inherit FieldSchema_InForm
        abstract Presence: bool with get, set
        abstract WithPicture: bool with get, set
        abstract DefaultRender: bool with get, set
        abstract WithPictureDetail: bool with get, set
        abstract ListFormUrl: string with get, set
        abstract UserDisplayUrl: string with get, set
        abstract EntitySeparator: string with get, set
        abstract PictureOnly: bool with get, set
        abstract PictureSize: string with get, set

    and [<AllowNullLiteral>] FieldSchema =
        abstract AllowGridEditing: bool with get, set
        abstract FieldType: string with get, set
        abstract Name: string with get, set
        abstract Type: string with get, set

    and [<AllowNullLiteral>] FieldSchema_InForm =
        inherit FieldSchema
        abstract Description: string with get, set
        abstract Direction: string with get, set
        abstract Hidden: bool with get, set
        abstract Id: string with get, set
        abstract IMEMode: obj with get, set
        abstract ReadOnlyField: bool with get, set
        abstract Required: bool with get, set
        abstract RestrictedMode: bool with get, set
        abstract Title: string with get, set
        abstract UseMinWidth: bool with get, set

    and [<AllowNullLiteral>] ListSchema =
        abstract Field: ResizeArray<FieldSchema> with get, set

    and [<AllowNullLiteral>] ListSchema_InForm =
        inherit ListSchema
        abstract Field: ResizeArray<FieldSchema_InForm> with get, set

    and [<AllowNullLiteral>] ListData_InForm =
        abstract Items: ResizeArray<Item> with get, set

    and [<AllowNullLiteral>] RenderContext_FieldInForm =
        inherit RenderContext_Form
        abstract CurrentGroupIdx: float with get, set
        abstract CurrentGroup: Group with get, set
        abstract CurrentItems: ResizeArray<Item> with get, set
        abstract CurrentFieldSchema: FieldSchema_InForm with get, set
        abstract CurrentFieldValue: obj with get, set

    and [<AllowNullLiteral>] RenderContext_Form =
        inherit RenderContext
        abstract CurrentItem: Item with get, set
        abstract FieldControlModes: obj with get, set
        abstract FormContext: ClientFormContext with get, set
        abstract FormUniqueId: string with get, set
        abstract ListData: ListData_InForm with get, set
        abstract ListSchema: ListSchema_InForm with get, set
        abstract CSRCustomLayout: bool option with get, set

    and [<AllowNullLiteral>] FieldSchema_InView_LookupField =
        inherit FieldSchema_InView
        abstract AllowMultipleValues: string with get, set
        abstract DispFormUrl: string with get, set
        abstract HasPrefix: string with get, set

    and [<AllowNullLiteral>] FieldSchema_InView_UserField =
        inherit FieldSchema_InView
        abstract AllowMultipleValues: string with get, set
        abstract ImnHeader: string with get, set
        abstract HasPrefix: string with get, set
        abstract HasUserLink: string with get, set
        abstract DefaultRender: string with get, set

    and [<AllowNullLiteral>] FieldSchema_InView =
        inherit FieldSchema
        abstract CalloutMenu: string with get, set
        abstract ClassInfo: string with get, set
        abstract css: string with get, set
        abstract DisplayName: string with get, set
        abstract Explicit: string with get, set
        abstract fieldRenderer: obj with get, set
        abstract FieldTitle: string with get, set
        abstract Filterable: string with get, set
        abstract GroupField: string with get, set
        abstract GridActiveAndReadOnly: string with get, set
        abstract ID: string with get, set
        abstract listItemMenu: string with get, set
        abstract RealFieldName: string with get, set
        abstract ReadOnly: string with get, set
        abstract ResultType: string with get, set
        abstract Sortable: string with get, set

    and [<AllowNullLiteral>] ListSchema_InView =
        inherit ListSchema
        abstract Aggregate: obj with get, set
        abstract Collapse: string with get, set
        abstract DefaultItemOpen: string with get, set
        abstract Direction: string with get, set
        abstract EffectivePresenceEnabled: string with get, set
        abstract FieldSortParam: string with get, set
        abstract Filter: obj with get, set
        abstract ForceCheckout: string with get, set
        abstract group1: string with get, set
        abstract group2: string with get, set
        abstract HasTitle: string with get, set
        abstract HttpVDir: string with get, set
        abstract InplaceSearchEnabled: string with get, set
        abstract IsDocLib: string with get, set
        abstract LCID: string with get, set
        abstract ListRight_AddListItems: string with get, set
        abstract NoListItem: string with get, set
        abstract NoListItemHowTo: string with get, set
        abstract PagePath: string with get, set
        abstract ParentHierarchyDisplayField: string with get, set
        abstract PresenceAlt: string with get, set
        abstract PropertyBag: obj with get, set
        abstract RenderSaveAsNewViewButton: string with get, set
        abstract RenderViewSelectorPivotMenu: string with get, set
        abstract RenderViewSelectorPivotMenuAsync: string with get, set
        abstract RootFolderParam: string with get, set
        abstract SelectedID: string with get, set
        abstract ShowWebPart: string with get, set
        abstract StrikeThroughOnCompletedEnabled: string with get, set
        abstract TabularView: string with get, set
        abstract Toolbar: string with get, set
        abstract UIVersion: string with get, set
        abstract Userid: string with get, set
        abstract UserVanilla: obj with get, set
        abstract UserDispUrl: string with get, set
        abstract UseParentHierarchy: string with get, set
        abstract View: string with get, set
        abstract ViewSelectorPivotMenuOptions: string with get, set
        abstract ViewSelector_ViewParameters: string with get, set

    and [<AllowNullLiteral>] ListData_InView =
        abstract FilterLink: string with get, set
        abstract FilterFields: string with get, set
        abstract FirstRow: float with get, set
        abstract ForceNoHierarchy: string with get, set
        abstract HierarchyHasIndention: string with get, set
        abstract PrevHref: string with get, set
        abstract NextHref: string with get, set
        abstract SortField: string with get, set
        abstract SortDir: string with get, set
        abstract LastRow: float with get, set
        abstract Row: ResizeArray<Item> with get, set

    and [<AllowNullLiteral>] RenderContext_GroupInView =
        inherit RenderContext_InView
        abstract CurrentGroupIdx: float with get, set
        abstract CurrentGroup: Group with get, set
        abstract CurrentItems: ResizeArray<Item> with get, set

    and [<AllowNullLiteral>] RenderContext_InView =
        inherit RenderContext
        abstract AllowCreateFolder: bool with get, set
        abstract AllowGridMode: bool with get, set
        abstract BasePermissions: obj with get, set
        abstract bInitialRender: bool with get, set
        abstract CanShareLinkForNewDocument: bool with get, set
        abstract CascadeDeleteWarningMessage: string with get, set
        abstract clvp: HTMLElement with get, set
        abstract ContentTypesEnabled: bool with get, set
        abstract ctxId: float with get, set
        abstract ctxType: obj with get, set
        abstract CurrentUserId: float with get, set
        abstract CurrentUserIsSiteAdmin: bool with get, set
        abstract dictSel: obj with get, set
        abstract displayFormUrl: string with get, set
        abstract editFormUrl: string with get, set
        abstract EnableMinorVersions: bool with get, set
        abstract ExternalDataList: bool with get, set
        abstract enteringGridMode: bool with get, set
        abstract existingServerFilterHash: obj with get, set
        abstract HasRelatedCascadeLists: float with get, set
        abstract heroId: string with get, set
        abstract HttpPath: string with get, set
        abstract HttpRoot: string with get, set
        abstract imagesPath: string with get, set
        abstract inGridFullRender: obj with get, set
        abstract inGridMode: bool with get, set
        abstract IsAppWeb: bool with get, set
        abstract IsClientRendering: bool with get, set
        abstract isForceCheckout: bool with get, set
        abstract isModerated: bool with get, set
        abstract isPortalTemplate: obj with get, set
        abstract isWebEditorPreview: float with get, set
        abstract isVersions: float with get, set
        abstract isXslView: bool with get, set
        abstract LastRowIndexSelected: obj with get, set
        abstract LastSelectableRowIdx: obj with get, set
        abstract LastSelectedItemId: obj with get, set
        abstract leavingGridMode: bool with get, set
        abstract listBaseType: float with get, set
        abstract ListData: ListData_InView with get, set
        abstract ListDataJSONItemsKey: string with get, set
        abstract listName: string with get, set
        abstract ListSchema: ListSchema_InView with get, set
        abstract listTemplate: string with get, set
        abstract ListTitle: string with get, set
        abstract listUrlDir: string with get, set
        abstract loadingAsyncData: bool with get, set
        abstract ModerationStatus: float with get, set
        abstract NavigateForFormsPages: bool with get, set
        abstract newFormUrl: string with get, set
        abstract NewWOPIDocumentEnabled: obj with get, set
        abstract NewWOPIDocumentUrl: obj with get, set
        abstract noGroupCollapse: bool with get, set
        abstract OfficialFileName: string with get, set
        abstract OfficialFileNames: string with get, set
        abstract overrideDeleteConfirmation: string with get, set
        abstract overrideFilterQstring: string with get, set
        abstract PortalUrl: string with get, set
        abstract queryString: obj with get, set
        abstract recursiveView: bool with get, set
        abstract RecycleBinEnabled: float with get, set
        abstract RegionalSettingsTimeZoneBias: string with get, set
        abstract rootFolder: string with get, set
        abstract rootFolderForDisplay: obj with get, set
        abstract RowFocusTimerID: obj with get, set
        abstract SelectAllCbx: obj with get, set
        abstract SendToLocationName: string with get, set
        abstract SendToLocationUrl: string with get, set
        abstract serverUrl: obj with get, set
        abstract SiteTitle: string with get, set
        abstract StateInitDone: bool with get, set
        abstract TableCbxFocusHandler: obj with get, set
        abstract TableMouseOverHandler: obj with get, set
        abstract TotalListItems: float with get, set
        abstract verEnabled: float with get, set
        abstract view: string with get, set
        abstract viewTitle: string with get, set
        abstract WorkflowAssociated: bool with get, set
        abstract wpq: string with get, set
        abstract WriteSecurity: string with get, set

    and [<AllowNullLiteral>] RenderContext_ItemInView =
        inherit RenderContext_InView
        abstract CurrentItem: Item with get, set
        abstract CurrentItemIdx: float with get, set

    and [<AllowNullLiteral>] RenderContext_FieldInView =
        inherit RenderContext_ItemInView
        abstract CurrentFieldSchema: U2<FieldSchema_InForm, FieldSchema_InView> with get, set
        abstract CurrentFieldValue: obj with get, set
        abstract FieldControlsModes: obj with get, set
        abstract FormContext: ClientFormContext with get, set
        abstract FormUniqueId: string with get, set

    and [<AllowNullLiteral>] Item =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: fieldInternalName: string -> obj with get, set

    and [<AllowNullLiteral>] Group =
        abstract Items: ResizeArray<Item> with get, set

    and RenderCallback =
        Func<RenderContext, unit>

    and [<AllowNullLiteral>] RenderContext =
        abstract BaseViewID: float option with get, set
        abstract ControlMode: ClientControlMode option with get, set
        abstract CurrentCultureName: string option with get, set
        abstract CurrentLanguage: float option with get, set
        abstract CurrentSelectedItems: obj option with get, set
        abstract CurrentUICultureName: string option with get, set
        abstract ListTemplateType: float option with get, set
        abstract OnPostRender: U2<RenderCallback, ResizeArray<RenderCallback>> option with get, set
        abstract OnPreRender: U2<RenderCallback, ResizeArray<RenderCallback>> option with get, set
        abstract onRefreshFailed: obj option with get, set
        abstract RenderBody: Func<RenderContext, string> option with get, set
        abstract RenderFieldByName: Func<RenderContext, string, string> option with get, set
        abstract RenderFields: Func<RenderContext, string> option with get, set
        abstract RenderFooter: Func<RenderContext, string> option with get, set
        abstract RenderGroups: Func<RenderContext, string> option with get, set
        abstract RenderHeader: Func<RenderContext, string> option with get, set
        abstract RenderItems: Func<RenderContext, string> option with get, set
        abstract RenderView: Func<RenderContext, string> option with get, set
        abstract SiteClientTag: string option with get, set
        abstract Templates: Templates option with get, set

    and [<AllowNullLiteral>] SingleTemplateCallback =
        [<Emit("$0($1...)")>] abstract Invoke: renderContext: RenderContext_InView -> string

    and [<AllowNullLiteral>] GroupCallback =
        [<Emit("$0($1...)")>] abstract Invoke: renderContext: RenderContext_GroupInView -> string

    and [<AllowNullLiteral>] ItemCallback =
        [<Emit("$0($1...)")>] abstract Invoke: renderContext: RenderContext -> string

    and [<AllowNullLiteral>] FieldCallback =
        [<Emit("$0($1...)")>] abstract Invoke: renderContext: RenderContext -> string

    and [<AllowNullLiteral>] FieldInFormCallback =
        [<Emit("$0($1...)")>] abstract Invoke: renderContext: RenderContext_FieldInForm -> string

    and [<AllowNullLiteral>] FieldInViewCallback =
        [<Emit("$0($1...)")>] abstract Invoke: renderContext: RenderContext_FieldInView -> string

    and [<AllowNullLiteral>] FieldTemplateOverrides =
        abstract DisplayForm: FieldInFormCallback option with get, set
        abstract EditForm: FieldInFormCallback option with get, set
        abstract NewForm: FieldInFormCallback option with get, set
        abstract View: FieldInViewCallback option with get, set

    and [<AllowNullLiteral>] FieldTemplates =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: fieldInternalName: string -> FieldCallback with get, set

    and [<AllowNullLiteral>] Templates =
        abstract View: U2<RenderCallback, string> option with get, set
        abstract Body: U2<RenderCallback, string> option with get, set
        abstract Group: U2<GroupCallback, string> option with get, set
        abstract Item: U2<ItemCallback, string> option with get, set
        abstract Header: U2<SingleTemplateCallback, string> option with get, set
        abstract Footer: U2<SingleTemplateCallback, string> option with get, set
        abstract Fields: FieldTemplates option with get, set

    and [<AllowNullLiteral>] FieldTemplateMap =
        [<Emit("$0[$1]{{=$2}}")>] abstract Item: fieldInternalName: string -> FieldTemplateOverrides with get, set

    and [<AllowNullLiteral>] TemplateOverrides =
        abstract View: U2<RenderCallback, string> option with get, set
        abstract Body: U2<RenderCallback, string> option with get, set
        abstract Group: U2<GroupCallback, string> option with get, set
        abstract Item: U2<ItemCallback, string> option with get, set
        abstract Header: U2<SingleTemplateCallback, string> option with get, set
        abstract Footer: U2<SingleTemplateCallback, string> option with get, set
        abstract Fields: FieldTemplateMap option with get, set

    and [<AllowNullLiteral>] TemplateOverridesOptions =
        abstract Templates: TemplateOverrides option with get, set
        abstract OnPreRender: U2<RenderCallback, ResizeArray<RenderCallback>> option with get, set
        abstract OnPostRender: U2<RenderCallback, ResizeArray<RenderCallback>> option with get, set
        abstract ViewStyle: float option with get, set
        abstract ListTemplateType: float option with get, set
        abstract BaseViewID: U2<float, string> option with get, set

    and [<AllowNullLiteral>] [<Import("TemplateManager","SPClientTemplates")>] TemplateManager() =
        static member RegisterTemplateOverrides(renderCtx: TemplateOverridesOptions): unit = jsNative
        static member GetTemplates(renderCtx: RenderContext): Templates = jsNative

    and [<AllowNullLiteral>] ClientUserValue =
        abstract lookupId: float with get, set
        abstract lookupValue: string with get, set
        abstract displayStr: string with get, set
        abstract email: string with get, set
        abstract sip: string with get, set
        abstract title: string with get, set
        abstract picture: string with get, set
        abstract department: string with get, set
        abstract jobTitle: string with get, set

    and [<AllowNullLiteral>] ClientLookupValue =
        abstract LookupId: float with get, set
        abstract LookupValue: string with get, set

    and [<AllowNullLiteral>] ClientUrlValue =
        abstract URL: string with get, set
        abstract Description: string with get, set

    and [<AllowNullLiteral>] [<Import("Utility","SPClientTemplates")>] Utility() =
        member __.UserLookupDelimitString with get(): string = jsNative and set(v: string): unit = jsNative
        member __.UserMultiValueDelimitString with get(): string = jsNative and set(v: string): unit = jsNative
        static member ComputeRegisterTypeInfo(renderCtx: TemplateOverridesOptions): obj = jsNative
        static member ControlModeToString(mode: ClientControlMode): string = jsNative
        static member FileSystemObjectTypeToString(fileSystemObjectType: FileSystemObjectType): string = jsNative
        static member ChoiceFormatTypeToString(fileSystemObjectType: ChoiceFormatType): string = jsNative
        static member RichTextModeToString(fileSystemObjectType: RichTextMode): string = jsNative
        static member IsValidControlMode(mode: float): bool = jsNative
        static member Trim(str: string): string = jsNative
//        static member InitContext(webUrl: string): SP.ClientContext = jsNative
        static member GetControlOptions(control: HTMLElement): obj = jsNative
        static member TryParseInitialUserValue(userStr: string): ResizeArray<ClientUserValue> = jsNative
        static member TryParseUserControlValue(userStr: string, separator: string): ResizeArray<obj> = jsNative
        static member GetPropertiesFromPageContextInfo(context: RenderContext): unit = jsNative
        static member ReplaceUrlTokens(tokenUrl: string): string = jsNative
        static member ParseLookupValue(valueStr: string): ClientLookupValue = jsNative
        static member ParseMultiLookupValues(valueStr: string): ResizeArray<ClientLookupValue> = jsNative
        static member BuildLookupValuesAsString(choiceArray: ResizeArray<ClientLookupValue>, isMultiLookup: bool, setGroupDesc: bool): string = jsNative
        static member ParseURLValue(value: string): ClientUrlValue = jsNative
        static member GetFormContextForCurrentField(context: RenderContext_Form): ClientFormContext = jsNative

    and [<AllowNullLiteral>] [<Import("ClientFormContext","SPClientTemplates")>] ClientFormContext() =
        member __.fieldValue with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.fieldSchema with get(): FieldSchema_InForm = jsNative and set(v: FieldSchema_InForm): unit = jsNative
        member __.fieldName with get(): string = jsNative and set(v: string): unit = jsNative
        member __.controlMode with get(): float = jsNative and set(v: float): unit = jsNative
        member __.webAttributes with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.itemAttributes with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.listAttributes with get(): obj = jsNative and set(v: obj): unit = jsNative
        member __.registerInitCallback(fieldname: string, callback: Func<unit, unit>): unit = jsNative
        member __.registerFocusCallback(fieldname: string, callback: Func<unit, unit>): unit = jsNative
        member __.registerValidationErrorCallback(fieldname: string, callback: Func<obj, unit>): unit = jsNative
        member __.registerGetValueCallback(fieldname: string, callback: Func<unit, obj>): unit = jsNative
        member __.updateControlValue(fieldname: string, value: obj): unit = jsNative
        member __.registerClientValidator(fieldname: string, validator: obj): unit = jsNative
        member __.registerHasValueChangedCallback(fieldname: string, callback: Func<obj, unit>): unit = jsNative


