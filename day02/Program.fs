open System.IO

let scores =
    [ "B X", (1 + 0, 1 + 0)
      "C Y", (2 + 0, 3 + 3)
      "A Z", (3 + 0, 2 + 6) 
      "A X", (1 + 3, 3 + 0) 
      "B Y", (2 + 3, 2 + 3)
      "C Z", (3 + 3, 1 + 6)
      "C X", (1 + 6, 2 + 0)
      "A Y", (2 + 6, 1 + 3)
      "B Z", (3 + 6, 3 + 6) ]
    |> Map.ofList

let play selector =
    File.ReadAllLines("input.txt")
    |> Seq.sumBy (fun round ->
        Map.find round scores |> selector)

printfn $"Part 1: %i{play fst}"
printfn $"Part 2: %i{play snd}"
