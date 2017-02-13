defmodule RunLengthEncoder do
  @doc """
  Generates a string where consecutive elements are represented as a data value and count.
  "HORSE" => "1H1O1R1S1E"
  For this example, assume all input are strings, that are all uppercase letters.
  It should also be able to reconstruct the data into its original form.
  "1H1O1R1S1E" => "HORSE"
  """
  @spec encode(String.t) :: String.t
  def encode("" <> string) do
    String.codepoints(string)
    |> Enum.chunk_by(&(&1))
    |> Enum.map_join(&encode_chars/1)
  end

  @spec decode(String.t) :: String.t
  def decode(string) do
    Regex.scan(~r/(\d+)(\w)/, string, capture: :all_but_first)
    |> Enum.map_join(&expand_pair/1)
  end

  defp encode_chars(chars) do
    [Enum.count(chars), List.first(chars)]
    |> Enum.join
  end

  defp expand_pair([count, char]) do
    String.duplicate(char, String.to_integer(count))
  end
end
