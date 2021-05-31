using System;

namespace examples
{
    public class TimeOfDay
    {
        private readonly int minute;
        const int minutesInHour = 60;
        const int hoursInDay = 24;
        const int minutesInDay = hoursInDay * minutesInHour;
        public TimeOfDay(int minute)
        { this.minute = minute % minutesInDay; }
        public TimeOfDay(int hour, int minute)
        { 
            if (hour < 0 || hour >= hoursInDay || minute < 0 || minute >= minutesInHour)
                throw new ArgumentException();
            this.minute = minute; 
        }
        public int Hour => this.minute / minutesInHour;
        public int Minute => this.minute;
        public TimeOfDay WithHour(int newHour){ return new TimeOfDay(newHour); }
        public TimeOfDay WithMinute(int newMinute){ return new TimeOfDay(this.Hour, newMinute); }
        public TimeOfDay NextHour(){ return new TimeOfDay(minute+minutesInHour); }
        public TimeOfDay NextMinute(){ return new TimeOfDay(minute+1); }
    }
}
