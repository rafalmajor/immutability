using System;
using Xunit;

namespace examples
{
    public class UnitTest
    {
[Fact]
public void Test()
{
    var now = Clock.Instance.Now;
}
    }

public class Clock
{
    public TimeOfDay Now { get; set; }
    public static Clock Instance 
    { 
        get
        {
            if (instance == null)
                instance = new Clock();
            return instance;
        }
    }
    private static Clock instance;
}

    public class TimeOfDay
    {
    }
}
