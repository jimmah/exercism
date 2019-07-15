using System;
using System.Collections.Generic;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = new HashSet<char>();

        foreach (var c in word.ToLowerInvariant().Where(Char.IsLetter)) 
        {
            if (!letters.Add(c))
                return false;
        }

        return true;
    }
}
