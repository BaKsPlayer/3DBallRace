using System;

public static class FloatExtensions
{
    public static TimeSpan ToTimeSpan(this float timeInSeconds)
    {
        return TimeSpan.FromSeconds(timeInSeconds);
    }
}
