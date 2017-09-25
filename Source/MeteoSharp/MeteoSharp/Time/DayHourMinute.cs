using System;

namespace MeteoSharp.Time
{
    /// <summary>
    /// Represents day of the month, hour and minute.
    /// </summary>
#if NETSTANDARD2_0
    [Serializable]
#endif
    public struct DayHourMinute : IEquatable<DayHourMinute>
    {
        private readonly int _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="DayHourMinute"/> structure.
        /// </summary>
        /// <param name="day">The day. The value must be in range 1...31.</param>
        /// <param name="hour">The hour. The value must be in range 0...23.</param>
        /// <param name="minute">The minute. The value must be in range 0...59.</param>
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="day"/> is out of range 1...31</exception>.
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="hour"/> is out of range 0...23</exception>.
        /// <exception cref="ArgumentOutOfRangeException">The <paramref name="minute"/> is out of range 0...59</exception>.
        public DayHourMinute(int day, int hour, int minute)
        {
            if (day < 1 || day > 31)
                throw new ArgumentOutOfRangeException(nameof(day), "The value of the day argument must be between 1 and 31.");
            if (hour < 0 || hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), "The value of the hour argument must be between 0 and 23.");
            if (minute < 0 || minute > 59)
                throw new ArgumentOutOfRangeException(nameof(minute), "The value of the minute argument must be between 0 and 59.");

            _value = ((day - 1) << 16) | (hour << 8) | (minute);
        }

        /// <summary>
        /// Gets the day. The value is between 1 and 31.
        /// </summary>
        public int Day => ((_value & 0x00FF0000) >> 16) + 1;

        /// <summary>
        /// Gets the hour. The value is between 0 and 23.
        /// </summary>
        public int Hour => (_value & 0x0000FF00) >> 8;

        /// <summary>
        /// Gets the minute. The value is between 0 and 59.
        /// </summary>
        public int Minute => _value & 0x000000FF;

        public bool Equals(DayHourMinute other)
        {
            return _value == other._value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return (obj is DayHourMinute dayHourMinute) && Equals(dayHourMinute);
        }

        public override int GetHashCode()
        {
            return _value;
        }

        public static bool operator ==(DayHourMinute left, DayHourMinute right) => left.Equals(right);

        public static bool operator !=(DayHourMinute left, DayHourMinute right) => !left.Equals(right);

        public static implicit operator DayHourMinute((int day, int hour, int minute) tuple)
        {
            return new DayHourMinute(tuple.day, tuple.hour, tuple.minute);
        }

        public void Deconstruct(out int day, out int hour, out int minute)
        {
            day = Day;
            hour = Hour;
            minute = Minute;
        }
    }
}
