open System.IO
open Extensions

let elves =
    File.ReadAllText("input.txt")
    |> String.split "\n\n"
    |> List.map (String.split "\n" >> List.sumBy int)
    |> List.sortDescending

printfn $"Part 1: %i{List.head elves}"
printfn $"Part 2: %i{List.sum (List.take 3 elves)}"
