module Extensions

open System.Text.RegularExpressions

module String =
    let trim (input: string) = input.Trim()

let (|Regex|_|) pattern input =
    let m = Regex.Match(input, pattern)
    if m.Success
    then Some(List.tail [ for g in m.Groups -> g.Value ])
    else None

let (|Matches|_|) pattern input =
    let collection = Regex.Matches(input, pattern)
    if collection.Count = 0 then None
    else  Some([ for g in collection -> List.tail [for i in g.Groups -> i.Value] ] |> List.concat)
