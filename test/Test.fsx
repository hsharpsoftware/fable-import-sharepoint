#r "../node_modules/fable-core/Fable.Core.dll"
#r "../npm/Fable.Import.SharePoint.dll"

open Fable.Core.Testing

let doNothingTimer (callback:unit->unit) (miliseconds) = ()

let test() =
    let actual = 1
    let expected = 1
    Assert.AreEqual(expected, actual)

(* 
let testLogTrace () =
    Browser.Support.log_trace( [| "Hello" |] )
*)

test()
testLogTrace()
printfn "Test finished correctly"