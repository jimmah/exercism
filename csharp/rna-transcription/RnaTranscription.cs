using System.Collections.Generic;
using System.Linq;

public static class Complement
{
    private static readonly Dictionary<char, char> Transforms = new Dictionary<char, char>
    {
        {'G', 'C'},
        {'C', 'G'},
        {'T', 'A'},
        {'A', 'U'}
    };

    public static string OfDna(string nucleotide)
    {
        return string.Concat(nucleotide.Select(x => Transforms[x]));
    }
}