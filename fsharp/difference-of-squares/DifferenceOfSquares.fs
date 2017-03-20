module DifferenceOfSquares

let square (x: int) = x * x

let squareOfSums (number: int) = [1..number] |> List.sum |> square

let sumOfSquares (number: int) = List.sumBy square [1..number]

let difference (number: int) = squareOfSums number - sumOfSquares number