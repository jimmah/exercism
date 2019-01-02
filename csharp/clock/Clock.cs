using System;

public struct Clock
{
    private const int HoursPerDay = 24;

    private const int MinutesPerHour = 60;

    private const int MinutesPerDay = MinutesPerHour * HoursPerDay;

    private int _totalMinutes;

    public Clock(int hours, int minutes)
    {
        _totalMinutes = hours * MinutesPerHour;
        _totalMinutes += minutes;

        Normalize();
    }

    public int Hours => _totalMinutes / MinutesPerHour;

    public int Minutes => _totalMinutes % MinutesPerHour;

    public Clock Add(int minutesToAdd) => new Clock(Hours, Minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract) => new Clock(Hours, Minutes - minutesToSubtract);

    public override string ToString() => $"{Hours:00}:{Minutes:00}";

    private void Normalize() 
    {
        _totalMinutes %= MinutesPerDay;

        if (_totalMinutes < 0) 
            _totalMinutes = _totalMinutes + MinutesPerDay;
    }
}