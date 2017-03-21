#r "../node_modules/fable-core/Fable.Core.dll"
#r "../npm/Fable.Helpers.Sample.dll"

open Fable.Core.Testing
open Fable.Helpers.Sample

let test() =
    let actual =
        [ ("A", 235.65); ("XXX", 12304294.) ]
        |> MyLib.printPairsPadded 4 10
    let expected =
        "A   ->    235.65\nXXX ->  12304294"
    Assert.AreEqual(expected, actual)

test()
printfn "Test finished correctly"