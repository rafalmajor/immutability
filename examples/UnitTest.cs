using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace examples
{
    public class UnitTest
    {
        private static LocalClock clockInstance = LocalClock.Instance;

        [Theory]
        [MemberData(nameof(GetClock))]
        public void Test(Func<TimeOfDay> timeOfDay)
        {
            var now = timeOfDay();
        }

        public static IEnumerable<object[]> GetClock()
        {
            yield return new object[] { LocalClock.Instance };
        }
    }

    public class LocalClock : IClock
    {
        public TimeOfDay Now { get; set; }
        public static IClock Instance 
        { 
            get
            {
                if (instance == null)
                    instance = new LocalClock();
                return instance;
            }
        }
        private static IClock instance;
    }

    public class TimeOfDay
    {
    }

public interface IClock
{
    TimeOfDay Now { get; }
}
}
