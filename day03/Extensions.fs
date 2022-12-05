module Extensions

module String =
    let chunkInHalf (input: string) =
        Seq.chunkBySize (input.Length / 2) input
