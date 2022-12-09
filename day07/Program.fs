open System.IO
open Extensions

let filesystem =
    File.ReadAllLines("input.txt")
    |> Seq.fold (fun (path, map) line ->
        match line with
        | "$ cd .." -> List.tail path, map 
        | "$ ls" -> path, map
        | Regex.Groups "\$ cd (.*)" [dir] -> dir::path, map
        | Regex.Groups "dir (.*)" [name] ->
            let value = [(name, 0)]
            path, Map.add path (if Map.containsKey path map then map.[path] @ value else value) map 
        | Regex.Groups "(\d+) (.*)" [size; name] ->
            let value = [(name, int size)]
            path, Map.add path (if Map.containsKey path map then map.[path] @ value else value) map
        | _ -> failwithf $"Invalid line {line}"
        ) ([], Map.empty<string list, (string * int) list>)
    |> snd
    |> Map.map (fun _ items -> items |> List.sumBy snd)

let sizes = 
    filesystem.Keys        
    |> Seq.sortByDescending List.length        
    |> Seq.fold (fun map path ->
        if List.length path > 1
        then Map.add path.Tail (map.[path.Tail] + map.[path]) map
        else map) filesystem
    |> Map.toList
    |> List.sortBy snd

let part1 =
    sizes
    |> List.filter (fun (_, size) -> size < 100000)
    |> List.sumBy snd

let part2 =
    let total = List.last sizes |> snd
    let freeUp = 30000000 - 70000000 + total
    List.find (snd >> (<=) freeUp) sizes |> snd
    
printfn $"Part 1: %A{part1}"
printfn $"Part 2: %A{part2}"
