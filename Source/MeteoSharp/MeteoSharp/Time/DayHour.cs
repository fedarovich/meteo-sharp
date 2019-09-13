using System;

namespace MeteoSharp.Time
{
    public readonly struct DayHour : IEquatable<DayHour>
    {
        private readonly short _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="DayHourMinute"/> structure.
        /// </summary>
        /// <param name="day">The day. The value must be in range 1...31.</param>
        /// <param name="hour">The hour. The value must be in range 0...23.</param>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="day"/> is out of range 1...31</exception>.
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="hour"/> is out of range 0...23</exception>.
        public DayHour(int day, int hour)
        {
            if (day < 1 || day > 31)
                throw new ArgumentOutOfRangeException(nameof(day), "The value of the day argument must be between 1 and 31.");
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), "The value of the hour argument must be between 0 and 23.");

            _value = (short)(((day - 1) << 8) | hour);
        }

        /// <summary>
        /// Gets the day. The value is between 1 and 31.
        /// </summary>
        public int Day => ((_value & 0xFF00) >> 8) + 1;

        /// <summary>
        /// Gets the hour. The value is between 0 and 23.
        /// </summary>
        public int Hour => (_value & 0x00FF);

        public bool Equals(DayHour other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return (obj is DayHour dayHourMinute) && Equals(dayHourMinute);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public static bool operator ==(DayHour left, DayHour right) => left.Equals(right);

        public static bool operator !=(DayHour left, DayHour right) => !left.Equals(right);

        public static implicit operator DayHour((int day, int hour) tuple)
        {
            return new DayHour(tuple.day, tuple.hour);
        }

        public static implicit operator DayHourMinute(DayHour dayHour)
        {
            return new DayHourMinute(dayHour.Day, dayHour.Hour, 0);
        }

        public void Deconstruct(out int day, out int hour)
        {
            day = Day;
            hour = Hour;
        }
    }
}
