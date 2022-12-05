open System.IO
open Extensions

let setup stacks crates =
    crates
    |> List.indexed
    |> List.fold (fun stacks' (i, crate) ->
        if String.trim crate = "" then stacks'
        else List.updateAt i (stacks'[i] @ [crate]) stacks') stacks     

let move (stacks: string list list) amount source dest retain =
     let moved = List.take amount stacks[source]
     stacks
     |> List.updateAt source (List.skip amount stacks[source])
     |> List.updateAt dest ((if retain then moved else List.rev moved) @ stacks[dest])            

let rearrange retain =
    File.ReadAllLines("input.txt")
    |> Seq.fold (fun stacks line ->
        match line with
        | Regex.Matches "(?>(\[.\]|\s\s\s)\s?)" crates -> setup stacks crates 
        | Regex.Groups "move (\d*) from (\d*) to (\d*)" [ amount; source; dest ] ->
            move stacks (int amount) (int source - 1) (int dest - 1) retain
        | _ -> stacks) (List.init 9 (fun _ -> []))
    |> List.map List.head

printfn $"Part 1: %A{rearrange false}"
printfn $"Part 2: %A{rearrange true}"
