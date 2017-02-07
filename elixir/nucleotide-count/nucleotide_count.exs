defmodule NucleotideCount do
  @nucleotides [?A, ?C, ?G, ?T]

  @doc """
  Counts individual nucleotides in a NucleotideCount strand.

  ## Examples

  iex> NucleotideCount.count('AATAA', ?A)
  4

  iex> NucleotideCount.count('AATAA', ?T)
  1
  """
  @spec count([char], char) :: non_neg_integer
  def count(strand, nucleotide) do
    count(strand, nucleotide, 0)
  end

  @doc """
  Returns a summary of counts by nucleotide.

  ## Examples

  iex> NucleotideCount.histogram('AATAA')
  %{?A => 4, ?T => 1, ?C => 0, ?G => 0}
  """
  @spec histogram([char]) :: map
  def histogram(strand) do
    result = %{?A => 0, ?T => 0, ?C => 0, ?G => 0}
    histogram(strand, result)
  end

  defp count([nucleotide|tail], nucleotide, counter) do
    count(tail, nucleotide, counter + 1)
  end

  defp count([_|tail], nucleotide, counter) do
    count(tail, nucleotide, counter)
  end

  defp count([], _, counter) do
    counter
  end

  defp histogram([head|tail], result) do
    histogram(tail, %{result | head => result[head] + 1})
  end

  defp histogram([], result) do
    result
  end
end
