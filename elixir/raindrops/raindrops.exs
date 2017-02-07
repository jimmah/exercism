defmodule Raindrops do
  @doc """
  Returns a string based on raindrop factors.

  - If the number contains 3 as a prime factor, output 'Pling'.
  - If the number contains 5 as a prime factor, output 'Plang'.
  - If the number contains 7 as a prime factor, output 'Plong'.
  - If the number does not contain 3, 5, or 7 as a prime factor,
    just pass the number's digits straight through.
  """
  @spec convert(pos_integer) :: String.t
  def convert(number) do
    factors(number)
    |> Enum.reduce("", &converter/2)
    |> output(number)
  end

  defp factors(number) do
    2..number
    |> Enum.filter(fn n -> rem(number, n) == 0 end)
  end

  defp converter(3, result), do: result <> "Pling"
  defp converter(5, result), do: result <> "Plang"
  defp converter(7, result), do: result <> "Plong"
  defp converter(_, result), do: result

  defp output("", number), do: to_string(number)
  defp output(converted, _), do: converted
end
