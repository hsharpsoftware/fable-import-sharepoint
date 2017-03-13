namespace Fable.Import.SharePoint
open System
open System.Text.RegularExpressions
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser

module SPNotifications =
    type ContainerID =
        | Basic = 0
        | Status = 1

    and EventID =
        | OnShow = 0
        | OnHide = 1
        | OnDisplayNotification = 2
        | OnRemoveNotification = 3
        | OnNotificationCountChanged = 4