using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        return n == 1
            ? 1
            : 2 * Square(n - 1);
    }

    public static ulong Total()
    {
        ulong result = 0;

        for (var i = 1; i <= 64; i++) {
            result += Square(i);
        }

        return result;
    }
}