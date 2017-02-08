using System;

public static class Gigasecond
{
    public static DateTime Date(DateTime date) 
    {
        return date.AddSeconds(1e9);
    }
}