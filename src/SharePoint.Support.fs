module SharePoint.Support
open Fable.Import.SharePoint.SP
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open Fable.PowerPack

open Browser.Support

open Microsoft.FSharp.Reflection

[<Emit("log4javascript.getLogger().debug($0)")>]
let log (message:string) : unit = jsNative

[<Emit("log4javascript.getLogger().debug($0)")>]
let logO (value:obj) : unit = jsNative

[<Emit("log4javascript.getLogger().debug($0, $1)")>]
let logO2 (message:string) (value:obj) : unit = jsNative

let onQueryFailed sender (args:ClientRequestFailedEventArgs) =
    let message = sprintf "Request failed. %s \n%s\n " (args.get_message()) (args.get_stackTrace())
    log message
    logO args
    log "------------------------------------------------------------------------"
    failwith message

let nothingOnQueryFailed sender (args:ClientRequestFailedEventArgs) =
    ()


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

let executeQueryAsyncWithSuccessAndFallback (clientContext:ClientContext) (success) (fallback) =
  Async.FromContinuations( fun( cont, econt, ccont ) ->
      clientContext.executeQueryAsync(
          System.Func<_,_,_>(success),
          System.Func<_,_,_>(fallback)
      )        
  )

let executeQueryAsyncWithSuccessCallback (clientContext:ClientContext) (onSuccess) =
    executeQueryAsyncWithSuccessAndFallback clientContext onSuccess onQueryFailed

let executeQueryAsync (clientContext:ClientContext) =
    executeQueryAsyncWithFallback clientContext onQueryFailed

let executeSilentQueryAsync (clientContext:ClientContext) =
    executeQueryAsyncWithFallback clientContext nothingOnQueryFailed

[<Emit("jQuery.Deferred()")>]
let deferred() = jsNative

let executeQuery (clientContext:ClientContext) : Fable.Import.JS.Promise<unit> =
    let deferred = deferred()
    clientContext.executeQueryAsync(
        System.Func<_,_,_>( fun _ arguments -> deferred?resolve(arguments) |> ignore ),
        System.Func<_,_,_>( fun _ arguments -> deferred?reject(arguments) |> ignore )
    )            
    downcast deferred?promise()

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

let getListIdAsync title (listCollection:ListCollection) (clientContext : ClientContext) = 
    promise {
        let list1 = listCollection.getByTitle(title)
        clientContext.load(list1, "Id")
        let execQuery () = clientContext |> executeQuery
        do! execQuery  ()
        return list1
    }

let fixColumnName (name:string) = name.Replace(" ", "_x0020_")

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
    //logO2 "enumerator" enumerator
    let mResult = 
        seq {
            while enumerator.moveNext() do
                let result = enumerator.get_current()
                //logO2 "result" result
                yield result
        } |> Seq.toArray
    //logO2 "mResult" mResult
    mResult

[<Emit("new SP.WorkflowServices.WorkflowServicesManager($0, $1)")>]
let WorkflowServicesManager (context:ClientContext, web:Web) = jsNative

let getSubscriptionsByList (context:ClientContext) (web:Web) (listId) =   
    promise { 
        let sMgr = WorkflowServicesManager (context, web)
        let sservice = sMgr?getWorkflowSubscriptionService()
        let ssubs = sservice?enumerateSubscriptionsByList(listId) :?> ClientObject
        context.load(ssubs)
        let execQuery () = context |> executeQuery
        do! execQuery  ()
        let e = ssubs?getEnumerator()
        while (e?moveNext() :?> bool) do
           let c =  e?get_current()
           log("Name :" + c?get_name().ToString() + " sID: " + c?get_id().ToString())
    } |> Promise.iter( ignore )

[<Emit("SP.WorkflowServices")>]
let WorkflowServices () = jsNative

let getSubscriptionById (context:ClientContext) (web:Web) (subscriptionId:string)=
    let wfServiceManager = WorkflowServices()?WorkflowServicesManager?newObject(context, web)
    let subscription = wfServiceManager?getWorkflowSubscriptionService()?getSubscription(subscriptionId) :?> ClientObject
    //log "Loading subscription"
    context.load(subscription)
    subscription
    
let startWorkFlow (context:ClientContext) (web:Web) (subscription) (itemId:int) =
    promise {
        let wfServiceManager = WorkflowServices()?WorkflowServicesManager?newObject(context, web)
        let inputParameters = new System.Collections.Generic.Dictionary<string, obj>()
        //log "Successfully starting workflow."
        wfServiceManager?getWorkflowInstanceService()?startWorkflowOnListItem(subscription, itemId, inputParameters) |> ignore
        let execQuery () = context |> executeQuery
        do! execQuery  ()
        //log "workflow started successfully"
    }
    |> Promise.iter( ignore )

let startSiteWorkFlow (context:ClientContext) (web:Web) (subscription) (inputParameters) =
    promise {
        let wfServiceManager = WorkflowServices()?WorkflowServicesManager?newObject(context, web)
        //log "Successfully starting workflow."
        wfServiceManager?getWorkflowInstanceService()?startWorkflow(subscription, inputParameters) |> ignore
        let execQuery () = context |> executeQuery
        do! execQuery  ()
        //log "workflow started successfully"
    }
    |> Promise.iter( ignore )

[<Emit("SPDragDropManager")>]
let SPDragDropManager() = jsNative

[<Emit("DragDropMode")>]
let DragDropMode() = jsNative

let disableDragAndDrop () =
    window?g_uploadType <- DragDropMode()?NOTSUPPORTED
    SPDragDropManager()?DragDropMode <- DragDropMode()?NOTSUPPORTED

[<Emit("ExecuteOrDelayUntilScriptLoaded($0,$1)")>]
let ExecuteOrDelayUntilScriptLoaded (callback:unit->unit) (script:string) = jsNative
let nearestTd el = 
    el?parents("td")

[<Literal>]
let idAttachmentsRow = "idAttachmentsRow"

[<Emit("GetUrlKeyValue($0,$1,$2,$3)")>]
let GetUrlKeyValue (keyName, bNoDecode, url, bCaseInsensitive) = jsNative

[<Emit("GetUrlKeyValue($0)")>]
let GetUrlKeyValue1 (keyName) = jsNative


[<Emit("SP.UI.ModalDialog.commonModalDialogClose($0,$1)")>]
let commonModalDialogClose(dialogResult, returnValue) = jsNative

[<Emit("rlfiShowMore()")>]
let rlfiShowMore () = jsNative

let isCurrentUserMemberOfGroup (clientContext:ClientContext) (groupName:string) =
    promise {
        let web = clientContext.get_web()
        let currentUser = web.get_currentUser()
        clientContext.load(currentUser)
        let userGroups = currentUser.get_groups()
        clientContext.load(userGroups)
        let execQuery () = clientContext |> executeQuery
        do! execQuery ()

        return userGroups |> convert<Group> |> Array.exists( fun p -> p.get_title() = groupName )
    }

[<Emit("SP.ListOperation.Selection.getSelectedItems()")>]
let getSelectedItems () = jsNative

let getCurrentUserAsync (clientContext:ClientContext) =
    promise {
        let web = clientContext.get_web()
        let currentUser = web.get_currentUser()
        clientContext.load(currentUser)
        let userGroups = currentUser.get_groups()
        clientContext.load(userGroups)
        let execQuery () = clientContext |> executeQuery
        do! execQuery () 
        return currentUser
    }

let getUserByIdAsync (context:ClientContext) (web: Web) (id: float) =
   promise {
      let user = web.get_siteUsers().getById(id)
      let execQuery () = context |> executeQuery
      context.load(user)
      do! execQuery ()
      return user
   } 

let approveOrRejectTask (clientContext:ClientContext) (taskId: float) (listName: string) (approve: bool) =
  promise {
      let list = clientContext.get_web().get_lists().getByTitle(listName)
      let task = list.getItemById(taskId)
      let status = 
            match approve with
            | true -> "Approved"
            | false -> "Rejected"
              
      task.set_item("Completed",true)
      task.set_item("PercentComplete",1)
      task.set_item("Status",status)
      task.set_item("WorkflowOutcome",status)
      task.update()
      let execQuery () = clientContext |> executeQuery
      do! execQuery ()
  }

[<Emit("new SP.ClientContext($0)")>]
let getClientContext(url : string) = jsNative : ClientContext

[<Emit("new SP.ListItemCreationInformation()")>]
let getListItemCreationInformation() = jsNative : ListItemCreationInformation

[<Emit("new SP.FieldLookupValue()")>]
let getLookupFieldValue() = jsNative : FieldLookupValue

[<Emit("createInfo.set_underlyingObjectType(SP.FileSystemObjectType.folder)")>]
let setFolder() = jsNative 

let createFolders (context: ClientContext) (library: List) (folderNames: string []) =
  promise {
    log "createFolder() started"
    let execQuery () = context |> executeQuery

    folderNames 
    |> Array.iter(fun folderName ->
            try
                let createInfo = getListItemCreationInformation()
                setFolder()
                createInfo.set_leafName(folderName)    
                let item = library.addItem(createInfo)
                item.update()
                context.load(item)
            with
            | ex -> log (sprintf "Creation of subfolder %s failed with %A" folderName ex )
    )

    do! execQuery()
  }

[<Emit("getCurrentCtx()")>]
let getCurrentCtx() = jsNative : Fable.Import.SharePoint.ContextInfo

[<Emit("SP.ListOperation.Selection.getSelectedList()")>]
let getSelectedList() = jsNative 

let updateColumnValue (context:ClientContext) (web: Web) (listName: string) (itemId: float) (columnName: string) (columnValue: obj) =
  promise {
      let item = web.get_lists().getByTitle(listName).getItemById(itemId)
      item.set_item(columnName, columnValue)
      item.update()
      //do! executeQueryAsync context
  }

let getAllListItems (context: ClientContext) (web: Web) (listName: string) (includePart: string) =
  promise {
        let list = web.get_lists().getByTitle(listName)
        let execQuery () = context |> executeQuery
        
        match includePart.Equals("") with 
        | true -> context.load(list)
        | false -> context.load(list, includePart)
        do! execQuery ()

        let query = CamlQuery.createAllItemsQuery()

        let items = list.getItems(query)
        context.load(items)
        do! execQuery ()

        log(sprintf "listItems.get_count %A" (items.get_count()) )
        return items
  }

let getSiteNameFromUrl() =
    let urlParts = location.href.Split('/')
    let committees =  
        if location.href.Contains("/eon/") then "eon"
        else "committees"
    let index =
        urlParts
        |> Array.findIndex(fun f -> f.Equals(committees))
    urlParts.[index+2]

let getNormalizedSiteName () =
      let urlSpace = "%20"
      let originalBoardName = getSiteNameFromUrl()
      let boardName = originalBoardName.Replace(urlSpace, " ")
      boardName

let getListNameFromUrl() =
    let urlParts = location.href.Split('/')
    let indexOfAspx =
      urlParts
      |> Array.findIndex(fun x -> x.Contains(".aspx"))
    urlParts.[(indexOfAspx-1)]

let getLibraryNameFromUrl() =
    let urlParts = location.href.Split('/')
    let indexOfAspx =
      urlParts
      |> Array.findIndex(fun x -> x.Contains(".aspx"))
    urlParts.[(indexOfAspx-2)]

let getVal (columnName:string) (item:ListItem)  = 
    item.get_item(fixColumnName(columnName))

[<Emit("jQuery('<div>').html($0).text()")>]
let convertSimpleHtmlToText(text:string) = jsNative : string

let toStringSafe v =
    if v = null then
        ""
    else
        let vs = v.ToString()
        if vs="null" then "" else vs

let getValS (columnName:string) (item:ListItem)  = 
  getVal columnName item |> toStringSafe |> convertSimpleHtmlToText

let getListItemsByCaml (web:Web) (context:ClientContext) (listName: string) (fieldNames: string) (camlQuery: string) (mapper)  =
    console.log("getListItemsByCaml started for " + listName)
    promise {
        let itemList = web.get_lists().getByTitle(listName)
        context.load(itemList)
        let execQuery () = context |> executeQuery
        do! execQuery () 
        //console.log(listName)
        //console.log(itemList)
        //logO listName itemList

        let caml = new CamlQuery()
        //let xml = sprintf """<View><Query><Where><Eq><FieldRef Name='%s' /><Value Type='Boolean'>false</Value></Eq></Where></Query></View>""" columnName
        caml.set_viewXml(camlQuery)

        let listItems = itemList.getItems(caml)
        context.load(listItems, (sprintf "Include(Id,%s)" fieldNames ) )
        do! execQuery () 
        //console.log("listItems")
        //console.log(listItems)
        //logO "listItems" listItems
        //logD (sprintf "listItems.get_count %A" (listItems.get_count()) )
        
        let res = listItems |> convert<ListItem> |> Array.map( mapper )
        console.log("getListItemsByCaml succeeded for " + listName)
        //console.log(res)
        //logO "res" res
        return res
    }