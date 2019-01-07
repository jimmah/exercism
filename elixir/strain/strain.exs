defmodule Strain do
  @doc """
  Given a `list` of items and a function `fun`, return the list of items where
  `fun` returns true.

  Do not use `Enum.filter`.
  """
  @spec keep(list :: list(any), fun :: (any -> boolean)) :: list(any)
  def keep(list, fun), do: filter(list, fun, true, [])

  @doc """
  Given a `list` of items and a function `fun`, return the list of items where
  `fun` returns false.

  Do not use `Enum.reject`.
  """
  @spec discard(list :: list(any), fun :: (any -> boolean)) :: list(any)
  def discard(list, fun), do: filter(list, fun, false, [])

  defp filter([head|tail], fun, keep, acc) do
    next = cond do
      fun.(head) == keep -> [head|acc]
      true -> acc
    end
    filter(tail, fun, keep, next)
  end

  defp filter(_, _, _, acc), do: acc |> Enum.reverse
end
