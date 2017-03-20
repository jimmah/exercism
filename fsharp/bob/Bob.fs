module Bob

open System

let hey(input: string) =
    let isSilence = String.IsNullOrWhiteSpace input
    let isShouting = Seq.exists Char.IsLetter input && input = input.ToUpperInvariant()
    let isQuestion = input.EndsWith "?"

    match input with
    | _ when isSilence -> "Fine. Be that way!"
    | _ when isShouting -> "Whoa, chill out!"
    | _ when isQuestion -> "Sure."
    | _ -> "Whatever."