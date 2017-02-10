using System;
using System.Linq;

public class Squares
{
    private readonly int _count;

    public Squares(int count) 
    {
        if (count < 0)
            throw new ArgumentOutOfRangeException("count must be positive", nameof(count));

        _count = count;
    }

    public int SquareOfSums() 
    {
        var sum = Enumerable.Range(1, _count).Sum();
        return sum * sum;
    }

    public int SumOfSquares()
    {
        return Enumerable.Range(1, _count).Select(n => n * n).Sum();
    }

    public int DifferenceOfSquares()
    {
        return SquareOfSums() - SumOfSquares();
    }
}