using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace examples
{
    public class UnitTest
    {
        private static Clock clockInstance = Clock.Instance;

        [Theory]
        [MemberData(nameof(GetClock))]
        public void Test(Clock clock)
        {
            var now = clock.Now;
        }

        public static IEnumerable<object[]> GetClock()
        {
            yield return new object[] { Clock.Instance };
        }
    }

    public class Clock : IClock
    {
        public TimeOfDay Now { get; set; }
        public static IClock Instance 
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

public interface IClock
{
    TimeOfDay Now { get; }
}
}
