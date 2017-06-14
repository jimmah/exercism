using System;
using System.Collections.Generic;

public class DNA
{
    public DNA(string sequence)
    {
        NucleotideCounts = new Dictionary<char, int>
        {
            {'C', 0},
            {'G', 0},
            {'T', 0},
            {'A', 0}
        };

        foreach (var nucleotide in sequence)
        {
            NucleotideCounts[nucleotide]++;
        }
    }

    public IDictionary<char, int> NucleotideCounts { get; private set; }

    public int Count(char nucleotide)
    {
        if (!NucleotideCounts.TryGetValue(nucleotide, out int count))
            throw new InvalidNucleotideException();
        return count;
    }
}

public class InvalidNucleotideException : Exception { }
