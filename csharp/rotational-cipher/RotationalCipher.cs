using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey) => 
        new string(text.Select(c =>
        {
            if (char.IsLetter(c))
            {
                var offset = char.IsUpper(c) ? 'A' : 'a';
                var x = (char)(c + shiftKey % 26);
                return x - offset < 26 ? x : (char) (x - 26);
            }

            return c;
        }).ToArray());
}