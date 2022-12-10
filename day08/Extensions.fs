module Extensions

let (><) f a b = f b a

module Matrix =
    let map f (matrix: 'a list list) =
        matrix
        |> List.indexed
        |> List.map (fun (y, row) ->
            row
            |> List.indexed
            |> List.map (fun (x, value) -> f x y value))

module List =    
    let takeWhileAndNext pred list =
        let ret = list |> List.takeWhile pred
        let l = List.length ret
        if l < List.length list then ret @ [list[l]] else ret

    let lengthBy pred list =
        list |> List.filter pred |> List.length