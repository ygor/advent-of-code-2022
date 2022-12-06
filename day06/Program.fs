open System.IO

let marker length =
    File.ReadAllText("input.txt")
    |> Seq.windowed length
    |> Seq.findIndex (fun chars -> Seq.distinct chars |> Seq.length = length)
  
printfn $"Part 1: %A{(marker 4) + 4}"
printfn $"Part 2: %A{(marker 14) + 14}"