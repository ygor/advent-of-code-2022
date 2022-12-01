open Extensions

let elves =
    System.IO.File.ReadAllText("input.txt")
    |> String.split "\n\n"
    |> List.map (String.split "\n" >> List.map int >> List.sum)

let top3 = List.sortDescending >> List.take 3

printfn $"Part 1: %i{List.max elves}"
printfn $"Part 2: %i{List.sum (top3 elves)}"
