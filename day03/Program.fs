open System.IO
open Extensions

let rucksacks = File.ReadAllLines("input.txt")

let priority itemType =
    let value = int itemType
    if value < 92 then value - 38 else value - 96

let part1 =
    rucksacks
    |> Seq.sumBy (String.sliceHalf >> Seq.map Set.ofSeq >> Set.intersectMany >> Set.minElement >> priority)

let part2 =
    rucksacks
    |> Seq.chunkBySize 3
    |> Seq.sumBy (Seq.map Set.ofSeq >> Set.intersectMany >> Set.minElement >> priority)

printfn $"Part 1: %i{part1}"
printfn $"Part 2: %i{part2}"
