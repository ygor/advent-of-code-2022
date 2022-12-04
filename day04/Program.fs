open System.IO
open Extensions

let parsePair input =
    input
    |> String.split ","
    |> List.map (String.split "-" >> List.map int >> Tuple.ofList)
    |> Tuple.ofList
              
let pairs = File.ReadAllLines("input.txt") |> Seq.map parsePair

let contains ((x, y), (a, b)) = x <= a && y >= b || a <= x && b >= y 

let overlaps ((x, y), (a, b)) = (x <= b && y >= a) || (a <= y && b >= x) 

printfn $"Part 1: %i{pairs |> Seq.lengthBy contains}"
printfn $"Part 2: %i{pairs |> Seq.lengthBy overlaps}"