using System;
using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
        => "abcdefghijklmnopqrstuvwxyz".Count(c => input.IndexOf(c) == -1) == 0;
}
