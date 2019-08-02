using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        bool IsBracket(char c) => "(){}[]".Contains(c);

        var brackets = new string(input.Where(IsBracket).ToArray());
        var length = brackets.Length;

        while (brackets.Length > 0)
        {
            brackets = brackets
                .Replace("()", "")
                .Replace("{}", "")
                .Replace("[]", "");

            if (brackets.Length == length)
                return false;

            length = brackets.Length;
        }

        return true;
    }
}
