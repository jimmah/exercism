using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
        => "abcdefghijklmnopqrstuvwxyz".Count(c => input.ToLowerInvariant().IndexOf(c) == -1) == 0;
}
