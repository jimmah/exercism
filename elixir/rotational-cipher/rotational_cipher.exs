defmodule RotationalCipher do
  @doc """
  Given a plaintext and amount to shift by, return a rotated string.

  Example:
  iex> RotationalCipher.rotate("Attack at dawn", 13)
  "Nggnpx ng qnja"
  """
  @spec rotate(text :: String.t(), shift :: integer) :: String.t()
  def rotate(text, shift) do
    text
    |> to_charlist
    |> Enum.map(&(shift_char(&1, shift)))
    |> to_string
  end

  defp shift_char(char, shift) when char in ?a..?z,
    do: shift_char(char, shift, ?a)

  defp shift_char(char, shift) when char in ?A..?Z,
    do: shift_char(char, shift, ?A)

  defp shift_char(char, _), do: char

  defp shift_char(char, shift, base),
    do: base + rem(char + shift - base, 26)
end
