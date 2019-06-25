using System;

public enum Direction
{
    North,
    East,
    South,
    West
}

public class RobotSimulator
{
    public RobotSimulator(Direction direction, int x, int y)
    {
        Direction = direction;
        X = x;
        Y = y;
    }

    public Direction Direction { get; private set; }

    public int X { get; private set; }

    public int Y { get; private set; }

    public void Move(string instructions)
    {
        foreach (var instruction in instructions)
        {
            switch (instruction)
            {
                case 'L':
                    Left();
                    break;
                case 'R':
                    Right();
                    break;
                case 'A':
                    Advance();
                    break;
            }
        }
    }

    private void Left()
    {
        Direction = Direction == Direction.North ? Direction.West : (Direction - 1);
    }

    private void Right() 
    {
        Direction = Direction == Direction.West ? Direction.North : (Direction + 1);
    }

    private void Advance()
    {
        switch (Direction) 
        {
            case Direction.North:
                Y++;
                break;
            case Direction.East:
                X++;
                break;
            case Direction.South:
                Y--;
                break;
            case Direction.West:
                X--;
                break;
        }
    }
}