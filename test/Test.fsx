#r "../node_modules/fable-core/Fable.Core.dll"
#r "../npm/Fable.Import.SharePoint.dll"

open Fable.Core.Testing
open HSharp

let test() =
    let actual = 1
    let expected = 1
    Assert.AreEqual(expected, actual)

test()
printfn "Test finished correctly"