module SpaceAge

open System

type Planet =
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Uranus
    | Neptune

let factor planet =
    match planet with
    | Planet.Mercury -> 0.2408467m
    | Planet.Venus -> 0.61519726m
    | Planet.Earth -> 1m
    | Planet.Mars -> 1.8808158m
    | Planet.Jupiter -> 11.862615m
    | Planet.Saturn -> 29.447498m
    | Planet.Uranus -> 84.016846m
    | Planet.Neptune -> 164.79132m

let secondsPerYear =
    factor >> (*) 31557600m

let round (n: decimal) =
    Math.Round(n, 2)

let spaceAge planet (seconds: decimal) =
    seconds / secondsPerYear planet |> round