open System.IO
open Extensions

type Node = File of string * int | Dir of string

let tree =
    File.ReadAllLines("input.txt")
    |> Seq.fold (fun (path, map) line ->
        match line with
        | "$ cd .." -> List.tail path, map 
        | "$ ls" -> path, map
        | Regex.Groups "\$ cd (.*)" [dir] -> dir::path, map
        | Regex.Groups "dir (.*)" [name] ->
            let value = [Dir name]
            path, Map.add path (if Map.containsKey path map then map.[path] @ value else value) map 
        | Regex.Groups "(\d+) (.*)" [size; name] ->
            let value = [File (name, int size)]
            path, Map.add path (if Map.containsKey path map then map.[path] @ value else value) map
        | _ -> failwithf $"Invalid line {line}"
        ) ([], Map.empty<string list, Node list>)
    |> snd

// let paths = Map.keys tree |> Seq.sortByDescending List.length

printfn $"Part 1: %A{tree}"