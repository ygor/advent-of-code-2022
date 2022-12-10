open System.IO
open Extensions

let grid =
    File.ReadAllLines("input.txt")
    |> Seq.map (Seq.map (string >> int) >> List.ofSeq)
    |> List.ofSeq

let width, height = List.length (List.head grid), List.length grid

let score x y h =
    ([0 .. (x - 1)] |> List.rev |> List.takeWhileAndNext (fun x' -> grid[y][x'] < h) |> List.length)
    * ([(x + 1) .. (width - 1)] |> List.takeWhileAndNext (fun x' -> grid[y][x'] < h) |> List.length)
    * ([0 .. (y - 1)] |> List.rev |> List.takeWhileAndNext (fun y' -> grid[y'][x] < h) |> List.length)
    * ([(y + 1) .. (height - 1)] |> List.takeWhileAndNext (fun y' -> grid[y'][x] < h) |> List.length)    

let isVisible x y h =
    [0 .. (x - 1)] |> List.forall (fun x' -> grid[y][x'] < h)
    || [(x + 1) .. (width - 1)] |> List.forall (fun x' -> grid[y][x'] < h)
    || [0 .. (y - 1)] |> List.forall (fun y' -> grid[y'][x] < h)
    || [(y + 1) .. (height - 1)] |> List.forall (fun y' -> grid[y'][x] < h)

let part1 =
    grid
    |> Matrix.map (fun x y h ->
        if x > 0 && x < (width - 1) && y > 0 && y < (height - 1) then isVisible x y h else true)
    |> List.concat
    |> List.lengthBy ((=) true)

let part2 =
    grid
    |> Matrix.map (fun x y h ->
        if x > 0 && x < (width - 1) && y > 0 && y < (height - 1) then score x y h else 0)
    |> List.concat
    |> List.max
    
printfn $"Part 1: %A{part1}"
printfn $"Part 2: %A{part2}"
