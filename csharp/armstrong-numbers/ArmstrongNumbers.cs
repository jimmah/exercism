using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var digits = number.ToString().Length;

        var sum = 0;
        for (var i = number; i > 0; i = i / 10) 
        {
            sum = sum + (int) Math.Pow(i % 10, digits);
        }

        return number == sum;
    }
}