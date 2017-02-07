defmodule Words do
  @doc """
  Count the number of words in the sentence.

  Words are compared case-insensitively.
  """
  @spec count(String.t) :: map
  def count(sentence) do
    String.downcase(sentence)
    |> String.replace(~r/[!|&|@|\$|%|\^|&|,]+/, "")
    |> String.split([" ", "_"])
    |> Enum.filter(fn(word) -> String.match?(word, ~r/\w+/) end)
    |> Enum.reduce(Map.new, fn(word, map) -> Map.update(map, word, 1, &(&1 + 1)) end)
  end

end
