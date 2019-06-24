using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length == 0)
            throw new ArgumentException($"{nameof(numbers)} is empty", nameof(numbers));

        if (sliceLength <= 0)
            throw new ArgumentException($"{nameof(sliceLength)} must be greater than or equal to 0.", nameof(sliceLength));

        if (sliceLength > numbers.Length)
            throw new ArgumentException($"{nameof(sliceLength)} must be less than the length of ${nameof(numbers)}.", nameof(sliceLength));

        var slices = new List<string>();

        for (var i = 0; i < numbers.Length - sliceLength + 1; i++)
            slices.Add(numbers.Substring(i, sliceLength));
        

        return slices.ToArray();
    }
}