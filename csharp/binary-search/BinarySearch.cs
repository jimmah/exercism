using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value) => Find(input, value, 0, input.Length);

    private static int Find(int[] input, int value, int start, int end) 
    {
        if (end <= start) return -1;

        var middle = start + ((end - start) / 2);
        switch (value.CompareTo(input[middle])) 
        {
            case int x when x > 0:
                return Find(input, value, middle + 1, end);
            case int x when x < 0:
                return Find(input, value, start, middle);
            default:
                return middle;
        }
    }
}