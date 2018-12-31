using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        var numberAsString = number.ToString();
        var digits = numberAsString.Length;

        var sum = 0d;
        for (var i = 0; i < digits; i++)
        {
            sum += Math.Pow(int.Parse(numberAsString[i].ToString()), digits);
        }

        return number == sum;
    }
}