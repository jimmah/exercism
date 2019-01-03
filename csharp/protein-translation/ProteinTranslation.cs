using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class ProteinTranslation
{
    private const string Stop = "STOP";

    private static readonly IDictionary<string, string> _proteins = new Dictionary<string, string>
    {
        {"AUG", "Methionine"},
        {"UUU", "Phenylalanine"},
        {"UUC", "Phenylalanine"},
        {"UUA", "Leucine"},
        {"UUG", "Leucine"},
        {"UCU", "Serine"},
        {"UCC", "Serine"},
        {"UCA", "Serine"},
        {"UCG", "Serine"},
        {"UAU", "Tyrosine"},
        {"UAC", "Tyrosine"},
        {"UGU", "Cysteine"},
        {"UGC", "Cysteine"},
        {"UGG", "Tryptophan"},
        {"UAA", Stop},
        {"UAG", Stop},
        {"UGA", Stop}
    };

    public static string[] Proteins(string strand)
    {
        var result = new List<string>();

        foreach (var codon in Regex.Split(strand, @"(?<=\G.{3})"))
        {
            if (string.IsNullOrWhiteSpace(codon))
                continue;

            if (!_proteins.ContainsKey(codon))
                throw new KeyNotFoundException("Invalid RNA");

            var protein = _proteins[codon];
            if (protein == Stop) 
                break;

            result.Add(protein);
        }

        return result.ToArray();
    }
}