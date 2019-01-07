defmodule ProteinTranslation do
  @doc """
  Given an RNA string, return a list of proteins specified by codons, in order.
  """
  @spec of_rna(String.t()) :: {atom, list(String.t())}
  def of_rna(rna) do
    { ok, peptides } = do_of_rna(rna, [])
    cond do
      ok == :error -> { :error, "invalid RNA" }
      true -> { :ok, peptides |> Enum.reverse }
    end
  end

  @proteins %{
    "UGU" => "Cysteine",
    "UGC" => "Cysteine",
    "UUA" => "Leucine",
    "UUG" => "Leucine",
    "AUG" => "Methionine",
    "UUU" => "Phenylalanine",
    "UUC" => "Phenylalanine",
    "UCU" => "Serine",
    "UCC" => "Serine",
    "UCA" => "Serine",
    "UCG" => "Serine",
    "UGG" => "Tryptophan",
    "UAU" => "Tyrosine",
    "UAC" => "Tyrosine",
    "UAA" => "STOP",
    "UAG" => "STOP",
    "UGA" => "STOP"
  }

  @codons @proteins |> Map.keys

  @doc """
  Given a codon, return the corresponding protein

  UGU -> Cysteine
  UGC -> Cysteine
  UUA -> Leucine
  UUG -> Leucine
  AUG -> Methionine
  UUU -> Phenylalanine
  UUC -> Phenylalanine
  UCU -> Serine
  UCC -> Serine
  UCA -> Serine
  UCG -> Serine
  UGG -> Tryptophan
  UAU -> Tyrosine
  UAC -> Tyrosine
  UAA -> STOP
  UAG -> STOP
  UGA -> STOP
  """
  @spec of_codon(String.t()) :: {atom, String.t()}
  def of_codon(codon) when codon in @codons, do: { :ok, @proteins[codon] }
  def of_codon(_), do: { :error, "invalid codon" }

  defp translate_rna("", acc), do: { :ok, acc }
  defp translate_rna(strand, acc) do
    { codon, rest } = strand |> String.split_at(3)
    { ok, peptide } = of_codon(codon)
    cond do
      ok == :error -> { :error, "invalid codon" }
      peptide == "STOP" -> { :ok, acc }
      true -> translate_rna(rest, [peptide|acc])
    end
  end
end
