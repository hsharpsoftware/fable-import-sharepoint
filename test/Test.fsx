#r "../node_modules/fable-core/Fable.Core.dll"
#r "../npm/Fable.Import.SharePoint.dll"

open Fable.Core.Testing
open HSharp

let test() =
    let actual = 1
    let expected = 1
    Assert.AreEqual(expected, actual)

type PageWithoutPath() =
    interface IPage with
        member m.path = null
        member m.render () = ()

type PageWithoutPathApp() =        
    interface IApplicationV2 with 
        member this.isDebug = false
        member this.getPages () = 
            [|
                PageWithoutPath()
            |]
        member this.getSites () =
            [|
            |]
        member this.getScheduledTasks() =
            [|
            |]

let testPageWithoutPath() =
    HSharp.startApplication( null, ApplicationV2Wrapper(null, PageWithoutPathApp()) )

test()
testPageWithoutPath()
printfn "Test finished correctly"