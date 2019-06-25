using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
            throw new ArgumentOutOfRangeException(nameof(number));

        var sum = number.GetFactors().Sum();

        if (sum < number)
            return Classification.Deficient;
        
        if (sum == number)
            return Classification.Perfect;

        return Classification.Abundant;
    }

    private static IEnumerable<int> GetFactors(this int number)
    {
        var factors = new List<int>();

        for (var factor = 1; factor < number; factor++)
        {
            if (number % factor == 0)
            {
                factors.Add(factor);
            }
        }

        return factors;
    }
}
