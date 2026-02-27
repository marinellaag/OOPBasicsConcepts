namespace OOPBasicsConcepts.Backend
{
    public class Time
    {
        private int _hour;
        private int _minutes;
        private int _seconds;
        private int _milliseconds;

        public Time()
        {
            _hour = 0;
            _minutes = 0;
            _seconds = 0;
            _milliseconds = 0;
        }

        public Time(int hour)
        {
            Hour = hour;
            _minutes = 0;
            _seconds = 0;
            _milliseconds = 0;
        }
        public Time(int hour, int minutes)
        {
            Hour = hour;
            Minutes = minutes;
            _seconds = 0;
            _milliseconds = 0;
        }
        public Time(int hour, int minutes, int seconds)
        {
            Hour = hour;
            Minutes = minutes;
            Seconds = seconds;
            _milliseconds = 0;
        }

        public Time(int hour, int minutes, int seconds, int milliseconds)
        {
            Hour = hour;
            Minutes = minutes;
            Seconds = seconds;
            Milliseconds = milliseconds;
        }
        public int Hour
        {
            get => _hour;
            set => _hour = ValidateHour(value);
        }
        public int Minutes
        {
            get => _minutes;
            set => _minutes = ValidateMinutes(value);
        }
        public int Seconds
        {
            get => _seconds;
            set => _seconds = ValidateSeconds(value);
        }
        public int Milliseconds
        {
            get => _milliseconds;
            set => _milliseconds = ValidateMilliseconds(value);
        }

        public override string ToString()
        {
            string period = _hour < 12 ? "AM" : "PM";
            int displayHour = _hour % 12;
            if (displayHour == 0) displayHour = 12;
            return $"{displayHour:00}:{_minutes:00}:{_seconds:00}.{_milliseconds:000} {period}";
        }

        public long ToMilliseconds()
        {
            return ((long)_hour * 3600 + (long)_minutes * 60 + _seconds) * 1000 + _milliseconds;
        }

        public long ToSeconds()
        {
            return (long)_hour * 3600 + (long)_minutes * 60 + _seconds;
        }

        public long ToMinutes()
        {
            return (long)_hour * 60 + _minutes;
        }

        public bool IsOtherDay(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long msInDay = 24L * 3600 * 1000;
            return totalMs >= msInDay;
        }

        public Time Add(Time other)
        {
            long totalMs = this.ToMilliseconds() + other.ToMilliseconds();
            long msInDay = 24L * 3600 * 1000;

            totalMs = totalMs % msInDay;

            int ms = (int)(totalMs % 1000);
            totalMs /= 1000;
            int sec = (int)(totalMs % 60);
            totalMs /= 60;
            int min = (int)(totalMs % 60);
            int hrs = (int)(totalMs / 60);

            return new Time(hrs, min, sec, ms);
        }
        private int ValidateHour(int hour)
        {
            if (hour < 0 || hour > 23)
            {
                throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid.");
            }
            return hour;
        }
        private int ValidateMinutes(int minutes)
        {
            if (minutes < 0 || minutes > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(minutes), $"The minute: {minutes}, is not valid.");
            }
            return minutes;
        }
        private int ValidateSeconds(int seconds)
        {
            if (seconds < 0 || seconds > 59)
            {
                throw new ArgumentOutOfRangeException(nameof(seconds), $"The second: {seconds}, is not valid.");
            }
            return seconds;
        }
        private int ValidateMilliseconds(int milliseconds)
        {
            if (milliseconds < 0 || milliseconds > 999)
            {
                throw new ArgumentOutOfRangeException(nameof(milliseconds), $"The millisecons: {milliseconds}, is not valid.");
            }
            return milliseconds;
        }
    }
}
