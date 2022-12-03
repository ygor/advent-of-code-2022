module Extensions

module String =
    let sliceHalf (input: string) =
        let length = input.Length / 2
        [input[0..length - 1]; input[length..]]
