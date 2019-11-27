using System;
using System.Collections.Generic;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        for (var b = sum / 2; b > 1; b--)
        {
            for (var a = b; a > 1; a--)
            {
                var c = sum - (a + b);
                if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
                    yield return (a, b, c);
            }
        }
    }
}