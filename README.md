# fable-import-sharepoint
[Fable](http://fable.io/) bindings for [SharePoint](https://products.office.com/en-us/sharepoint/collaboration). 
Simple library that can be used to create client-only SharePoint application in [F#](http://fsharp.org/).

## Complete application
One of the easiest way to crate SharePoint application is to create the lists and then [create custom forms](https://social.technet.microsoft.com/wiki/contents/articles/23955.sharepoint-2013-building-custom-forms.aspx).
You can then modify the form HTML to comply with your requirements.

These days users are used to web applications that contain client functionality like validations, autocomplete etc. written in JavaScript.

There are already some helper JavaScript libraries like [SharePoint Cascaded Lookups - JavaScript based](https://spcd.codeplex.com/) or
[The Patterns and Practices JavaScript Core Library](https://github.com/SharePoint/PnP-JS-Core).

If you want to build an application in SharePoint and modify the form functionality in F#, you implement `IApplicationV2` interface.

## JavaScript API reference for SharePoint 2013 (JSOM)
Most of the functions from [JavaScript API reference for SharePoint 2013 (JSOM)](https://msdn.microsoft.com/en-us/library/office/jj193034.aspx) are available as Fable interfaces and F# functions.

    async {
        let! currentUser = clientContext |> getCurrentUserAsync
        let selectedIds = getSelectedIds()
        let list = web.get_lists().getByTitle(listName)        
        logO "List" list
    } |> Async.StartImmediate
