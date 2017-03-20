module SumOfMultiples

let sumOfMultiples numbers max =
    let isMultiple x = numbers |> List.exists (fun y -> x % y = 0)

    [1..max-1]
    |> List.filter isMultiple
    |> List.sum