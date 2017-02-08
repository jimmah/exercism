using System.Text.RegularExpressions;

public static class Bob 
{
    public static string Hey(string input) 
    {
        if (IsSilence(input))
            return "Fine. Be that way!";
        if (IsShouting(input))
            return "Whoa, chill out!";
        if (IsQuestion(input))
            return "Sure.";
        return "Whatever.";
    }

    private static bool IsSilence(string input)
        => string.IsNullOrWhiteSpace(input);

    private static bool IsQuestion(string input)
        => input.Trim().EndsWith("?");

    private static bool IsShouting(string input)
        => input == input.ToUpper() && Regex.IsMatch(input, @"[a-zA-Z]+");
}