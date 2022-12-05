open System.IO
open Extensions

let parse retain input =
    input
    |> Seq.fold (fun crates line ->
        match line with
        | Regex.Matches "(?>(\[.\]|\s\s\s)\s?)" items ->
            items
            |> List.indexed
            |> List.fold (fun crates' (i, crate) ->
                if String.trim crate = "" then crates'
                else List.updateAt i (crates'[i] @ [crate]) crates') crates 
        | Regex.Groups "move (\d*) from (\d*) to (\d*)" [ amount; source; dest ] ->
             let moved = List.take (int amount) crates[int source - 1] 
             crates
             |> List.updateAt (int source - 1) (List.skip (int amount) crates[int source - 1])
             |> List.updateAt (int dest - 1) ((if retain then moved else List.rev moved) @ crates[int dest - 1])            
        | _ -> crates) (List.init 9 (fun _ -> []))

let rearrange retain = File.ReadAllLines("input.txt") |> parse retain |> List.map List.head

printfn $"Part 1: %A{rearrange false}"
printfn $"Part 2: %A{rearrange true}"
