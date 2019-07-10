using System;
using System.Linq;

public enum TriangleType
{
    Equilateral,
    Isosceles,
    Scalene,
    Invalid
}

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3) => 
        DetermineType(side1, side2, side3) == TriangleType.Scalene;

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        var type = DetermineType(side1, side2, side3);
        return type == TriangleType.Isosceles || type == TriangleType.Equilateral;
    }

    public static bool IsEquilateral(double side1, double side2, double side3) => 
        DetermineType(side1, side2, side3) == TriangleType.Equilateral;

    private static TriangleType DetermineType(double side1, double side2, double side3) 
    {
        var sides = new[] {side1, side2, side3};

        if (IsInvalidTriangle(sides))
            return TriangleType.Invalid;

        var uniqueSides = sides.Distinct().Count();
        
        if (uniqueSides == 1)
            return TriangleType.Equilateral;
        
        if (uniqueSides == 2)
            return TriangleType.Isosceles;

        return TriangleType.Scalene;
    }

    private static bool IsInvalidTriangle(double[] sides)
    {
        if (sides.All(x => x == 0) || sides.Any(x => x < 0))
            return true;

        return sides[0] + sides[1] <= sides[2] ||
               sides[0] + sides[2] <= sides[1] ||
               sides[1] + sides[2] <= sides[0]; 
    }
}