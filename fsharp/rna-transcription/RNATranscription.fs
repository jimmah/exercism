module RNATranscription

let transform char =
    match char with
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> char

let toRna (dna: string) = dna |> String.map transform