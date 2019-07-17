using System.Linq;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string Line(int index) => index == subjects.Length
            ? $"And all for the want of a {subjects[0]}."
            : $"For want of a {subjects[index - 1]} the {subjects[index]} was lost.";

        return Enumerable.Range(1, subjects.Length).Select(Line).ToArray();
    }
}