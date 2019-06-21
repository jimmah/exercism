using System;
using System.Collections.Generic;

public class Robot
{
    private static readonly Random _random = new Random();
    private static readonly HashSet<string> _names = new HashSet<string>();

    public string Name { get; private set; }

    public Robot() => Reset();

    public void Reset() => Name = GenerateName();

    private static string GenerateName() 
    {
        string name;
        do
        {
            name = $"{RandomChar}{RandomChar}{_random.Next(1000).ToString("000")}";
        } while (_names.Contains(name));

        _names.Add(name);
        return name;
    }

    private static string RandomChar 
    {
        get { return ((char)('A' + _random.Next(26))).ToString(); }
    }
}