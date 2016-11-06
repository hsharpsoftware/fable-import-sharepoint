module SharePoint.Support
open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

open Browser.Support

open Microsoft.FSharp.Reflection

let onQueryFailed sender (args:ClientRequestFailedEventArgs) =
    let message = sprintf "Request failed. %s \n%s " (args.get_message()) (args.get_stackTrace())
    failwith message

type FieldType = 
    | AllDayEvent
    | Attachments 
    | Boolean 
    |Calculate 
    |Choice 
    |Computed 
    |ContenttypeID 
    |Counter 
    |CrossProjectLink 
    |Currency 
    |DateTime 
    |Error 
    |File 
    |Geolocation 
    |GridChoice 
    |Guid 
    |Integer 
    |Invalid 
    |MaxItems 
    |ModStat 
    |MultiChoice 
    |Note 
    |Number 
    |OutcomeChoice 
    |PageSeparator 
    |Recurrence 
    |Text 
    |ThreadIndex 
    |Threading 
    |Url
    | User 
    |WorkflowEventType 
    |WorkflowStatus
    with member this.toString = 
       match this with
        | AllDayEvent -> "AllDayEvent"
        | Attachments -> "Attachments" 
        | Boolean  -> "Boolean"
        |Calculate -> "Calculate"
        |Choice -> "Choice"
        |Computed  -> "Computed"
        |ContenttypeID   -> "ContenttypeID"
        |Counter   -> "Counter"
        |CrossProjectLink   -> "CrossProjectLink"
        |Currency   -> "Currency"
        |DateTime   -> "DateTime"
        |Error   -> "Error"
        |File   -> "File"
        |Geolocation   -> "Geolocation"
        |GridChoice   -> "GridChoice"
        |Guid   -> "Guid"
        |Integer   -> "Integer"
        |Invalid   -> "Invalid"
        |MaxItems   -> "MaxItems"
        |ModStat   -> "ModStat"
        |MultiChoice   -> "MultiChoice"
        |Note   -> "Note"
        |Number   -> "Number"
        |OutcomeChoice   -> "OutcomeChoice"
        |PageSeparator   -> "PageSeparator"
        |Recurrence   -> "Recurrence"
        |Text   -> "Text"
        |ThreadIndex   -> "ThreadIndex"
        |Threading   -> "Threading"
        |Url  -> "Url"
        | User   -> "User"
        |WorkflowEventType   -> "WorkflowEventType"
        |WorkflowStatus  -> "WorkflowStatus"

type StandardFieldDefinition = {
    Name : string
    DisplayName : string
    Required : bool
    FieldType : FieldType
    ID : string
}

type LookupFieldDefinition = {
    Name : string
    DisplayName : string
    Required : bool
    LookupListName : string
    LookupFieldDisplayName : string
    ID : string
}

type FieldDefinition =
| StandardFieldDefinition of StandardFieldDefinition
| LookupFieldDefinition of LookupFieldDefinition

type ListDefinition = {
    DisplayName : string
    Url : string
    Fields : FieldDefinition array
}

let executeQueryAsyncWithFallback (clientContext:ClientContext) (fallback) =
    Async.FromContinuations( fun( cont, econt, ccont ) ->
        clientContext.executeQueryAsync(
            System.Func<_,_,_>(fun _ _ -> cont() ),
            System.Func<_,_,_>(fallback)
        )        
    )

let executeQueryAsync (clientContext:ClientContext) =
    executeQueryAsyncWithFallback clientContext onQueryFailed

let createCustomList title url (clientContext : ClientContext) =
    async {
        let web = clientContext.get_web()
        let listCollection = web.get_lists()
        clientContext.load(listCollection)
        let list1 = listCollection.getByTitle(title)
        clientContext.load(list1)
        let doCreateList () = 
                async {
                    let listCreationInfo = ListCreationInformation()
                    listCreationInfo.set_title(title)
                    listCreationInfo.set_url("Lists/"+url)
                    listCreationInfo.set_templateType(100.0)
                    let list1 = web.get_lists().add(listCreationInfo)

                    clientContext.load(list1);
                    do! executeQueryAsync clientContext
                } |> Async.StartImmediate
        do! executeQueryAsyncWithFallback clientContext  (  fun _ _ -> doCreateList () )                
    } |> Async.StartImmediate

let private createCustomListInt title url (createContentType:bool) continue1 (listCollection:ListCollection) (web:Web) (clientContext : ClientContext) =
    let list1 = listCollection.getByTitle(title)
    clientContext.load(list1)
    let itemContentType = clientContext.get_web().get_contentTypes().getById("0x01")
    clientContext.load(itemContentType)
    
    let createContentType (list:List) (andThen) = 
        if createContentType then
            let contentTypeCreationInformation = ContentTypeCreationInformation()
            contentTypeCreationInformation.set_name(title)
            contentTypeCreationInformation.set_parentContentType(itemContentType)
            let newContentType = list.get_contentTypes().add(contentTypeCreationInformation)
            clientContext.load(newContentType)
            clientContext.executeQueryAsync(
                System.Func<_,_,_>(fun _ _ -> andThen (Some(newContentType)) ),
                System.Func<_,_,_>(onQueryFailed)
            )
        andThen None

    clientContext.executeQueryAsync(
        System.Func<_,_,_>(fun _ _ -> continue1 list1 None clientContext),
        System.Func<_,_,_>(fun _ _ -> 
                let listCreationInfo = ListCreationInformation()
                listCreationInfo.set_title(title)
                listCreationInfo.set_url("Lists/"+url)
                listCreationInfo.set_templateType(100.0)
                let list1 = web.get_lists().add(listCreationInfo)

                clientContext.load(list1);
                clientContext.executeQueryAsync(
                    System.Func<_,_,_>(fun _ _ -> 
                        let moveOn (contentType:ContentType option) : unit =
                            continue1 list1 contentType clientContext
                        createContentType list1 moveOn ),
                    System.Func<_,_,_>(onQueryFailed)
                )        
        )        
    )

let createListColumn (list : List) (contentType:ContentType option) id name displayName (fieldTypeName:string) required (lookupListId:Guid option) (lookupFieldName:string option) (clientContext : ClientContext) =
    async {
        let fields = list.get_fields()
        clientContext.load(fields) 
        do! executeQueryAsync clientContext
        let field = fields.getByTitle(displayName)
        clientContext.load(field) 
        do! executeQueryAsyncWithFallback clientContext (fun _ _ -> 
            async {
                    let field = 
                        match lookupListId, lookupFieldName with
                        | None, None ->
                            fields.addFieldAsXml(
                                sprintf """<Field ID="{%s}" StaticName="%s" Name="%s" DisplayName="%s" Type="%s" Required="%s" />""" id name name displayName fieldTypeName (required.ToString().ToLower()), 
                                true, 
                                AddFieldOptions.addToAllContentTypes
                            )
                        | Some(lName), Some(fName) ->
                            fields.addFieldAsXml(
                                sprintf """<Field ID="{%s}" StaticName="%s" Name="%s" DisplayName="%s" Type="%s" List="{%s}" ShowField="%s" Required="%s" />""" id name name displayName fieldTypeName (lName.toString()) fName (required.ToString().ToLower()), 
                                true, 
                                AddFieldOptions.addToAllContentTypes
                            )
                    clientContext.load(field) 
                    do! executeQueryAsync clientContext
                    match contentType with
                    | Some(c) -> 
                        let fieldLinkCreatingInformation = FieldLinkCreationInformation()
                        fieldLinkCreatingInformation.set_field( field )
                        c.get_fieldLinks().add(fieldLinkCreatingInformation) |> ignore
                        c.update(true)
                        do! executeQueryAsync clientContext
                    | _ -> ()
                } |> Async.StartImmediate
           )
    } |> Async.StartImmediate
    

let getListId title (listCollection:ListCollection) (clientContext : ClientContext) = 
    async {
        let list1 = listCollection.getByTitle(title)
        clientContext.load(list1, "Id")
        do! executeQueryAsync clientContext
        return list1
    } |> Async.RunSynchronously

let fixColumnName (name:string) = name.Replace(" ", "_x0020_")

let createCustomLists (listDefinitions:ListDefinition array) continue1 (clientContext : ClientContext) =
    let web = clientContext.get_web()
    let listCollection = web.get_lists()
    let fixColumnId (s:string) =
        if System.String.IsNullOrWhiteSpace(s) then
            System.Guid.NewGuid().ToString()
        else
            "{" + s + "}"
    clientContext.load(listCollection)
    let rec continue0 index fieldsIndex list (contentType:ContentType option)  (clientContext : ClientContext) =        
        if index < listDefinitions.Length then
            if fieldsIndex >= 0 then
                if fieldsIndex < listDefinitions.[index].Fields.Length then
                    let fieldDefinition = listDefinitions.[index].Fields.[fieldsIndex]
                    match fieldDefinition with
                    | StandardFieldDefinition(fieldDefinition) ->
                        createListColumn list contentType (fixColumnId(fieldDefinition.ID)) fieldDefinition.Name fieldDefinition.DisplayName fieldDefinition.FieldType.toString fieldDefinition.Required None None clientContext
                        (continue0 index (fieldsIndex+1) list contentType ) clientContext
                    | LookupFieldDefinition(fieldDefinition) ->
                        let list = getListId fieldDefinition.LookupListName listCollection clientContext                        
                        createListColumn list contentType (fixColumnId(fieldDefinition.ID)) fieldDefinition.Name fieldDefinition.DisplayName "Lookup" fieldDefinition.Required (Some(list.get_id())) (Some(fixColumnName(fieldDefinition.LookupFieldDisplayName))) clientContext
                        (continue0 index (fieldsIndex+1) list contentType ) clientContext                     
                else
                    continue0 (index+1) -1 null None clientContext 
            else
                let listDefinition =  listDefinitions.[index]
                createCustomListInt listDefinition.DisplayName listDefinition.Url true (continue0 index (fieldsIndex+1) ) listCollection web clientContext
        else continue1(clientContext)
    continue0 0 -1 null None clientContext

type SPCascadeDropDownSetup = {
    relationshipList : string
    relationshipListParentColumn : string
    relationshipListChildColumn : string
    parentColumn : string
    childColumn : string
    debug : bool
 }

let uploadMasterPage (content) (clientContext:ClientContext) =
    let web = clientContext.get_web()
    let folder = web.getFolderByServerRelativeUrl("")
    let files = folder.get_files()
    let file : FileCreationInformation = FileCreationInformation()
    file.set_content(content)
    let file = files.add(file)
    file.checkOut()
    
let convert<'T> (source:Fable.Import.SharePoint.IEnumerable<'T>) : array<'T> =
    let enumerator = source.getEnumerator()
    seq {
        while enumerator.moveNext() do
            yield enumerator.get_current()
    } |> Seq.toArray

[<Emit("new SP.WorkflowServices.WorkflowServicesManager($0, $1)")>]
let WorkflowServicesManager (context:ClientContext, web:Web) = jsNative

let getSubscriptionsByList (context:ClientContext) (web:Web) (listId) =   
    async { 
        let sMgr = WorkflowServicesManager (context, web)
        let sservice = sMgr?getWorkflowSubscriptionService()
        let ssubs = sservice?enumerateSubscriptionsByList(listId) :?> ClientObject
        context.load(ssubs)
        do! executeQueryAsync context
        let e = ssubs?getEnumerator()
        while (e?moveNext() :?> bool) do
           let c =  e?get_current()
           log("Name :" + c?get_name().ToString() + " sID: " + c?get_id().ToString())
    } |> Async.StartImmediate

[<Emit("SP.WorkflowServices")>]
let WorkflowServices () = jsNative

let startWorkFlow (context:ClientContext) (web:Web) (itemId) (subscriptionId) =
    async {
        let wfServiceManager = WorkflowServices()?WorkflowServicesManager?newObject(context, web)
        let subscription = wfServiceManager?getWorkflowSubscriptionService()?getSubscription(subscriptionId) :?> ClientObject
        log "Loading subscription"
        context.load(subscription)
        do! executeQueryAsync context
        let inputParameters = new System.Collections.Generic.Dictionary<string, obj>()
        log "Successfully starting workflow."
        wfServiceManager?getWorkflowInstanceService()?startWorkflowOnListItem(subscription, itemId, inputParameters) |> ignore
        do! executeQueryAsync context
        log "workflow started successfully"
    }
    |> Async.StartImmediate

[<Emit("SPDragDropManager")>]
let SPDragDropManager() = jsNative

[<Emit("DragDropMode")>]
let DragDropMode() = jsNative

let disableDragAndDrop () =
    window?g_uploadType <- DragDropMode()?NOTSUPPORTED
    SPDragDropManager()?DragDropMode <- DragDropMode()?NOTSUPPORTED

[<Emit("ExecuteOrDelayUntilScriptLoaded($0,$1)")>]
let ExecuteOrDelayUntilScriptLoaded (callback:unit->unit) (script:string) = jsNative

