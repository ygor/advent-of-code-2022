module Extensions

module Seq =
    let lengthBy predicate source = source |> Seq.filter predicate |> Seq.length
        
module String =
    let split (sep: string) (input: string) = input.Split(sep) |> List.ofArray

module Tuple =
    let ofList list =
        match list with
        | x :: [ y ] -> x, y
        | _ -> failwith "invalid input"
