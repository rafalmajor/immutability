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

    public class TestDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                Clock.Instance
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield return new object[]
            {
                Clock.Instance
            };
        }
    }
}
