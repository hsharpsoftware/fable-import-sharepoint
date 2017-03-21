module Fable.Helpers.Sample.MyLib

open System

/// Use example
/// [ ("A", 234.45); ("B", 23458.0214) ]
/// |> printPairsPadded 3 12
let printPairsPadded (leftPad: int) (rightPad: int) (kvs: seq<'a*'b>) =
    kvs |> Seq.map (fun (k, v) ->
        let format = sprintf "{0,-%i}->{1,%i}" leftPad rightPad
        String.Format(format, k, v))
    |> String.concat "\n"
