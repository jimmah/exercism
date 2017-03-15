module Gigasecond

open System

let gigasecond (date: DateTime) =
    date.AddSeconds(1e9).Date