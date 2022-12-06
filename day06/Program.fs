open System.IO

let marker length =
    File.ReadAllText("input.txt")
    |> Seq.windowed length
    |> Seq.indexed
    |> Seq.find (fun (_, chars) -> Seq.distinct chars |> Seq.length = length)
    |> fst
  
printfn $"Part 1: %A{(marker 4) + 4}"
printfn $"Part 2: %A{(marker 14) + 14}"