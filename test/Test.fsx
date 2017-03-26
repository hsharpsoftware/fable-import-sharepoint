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
        member m.path = ""
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
    let locationHasPart (s:string) = false
    HSharp.startApplication( "http://localhost", ApplicationV2Wrapper(locationHasPart, PageWithoutPathApp()) )

test()
testPageWithoutPath()
printfn "Test finished correctly"