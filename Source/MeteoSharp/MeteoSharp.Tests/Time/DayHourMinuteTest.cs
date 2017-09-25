using System;
using MeteoSharp.Time;
using NUnit.Framework;

namespace MeteoSharp.Tests.Time
{
    [TestFixture(TestOf = typeof(DayHourMinute))]
    public class DayHourMinuteTest
    {
        [Test, Sequential]
        public void Constructor(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            var dhm = new DayHourMinute(day, hour, minute);
            Assert.That(dhm.Day, Is.EqualTo(day));
            Assert.That(dhm.Hour, Is.EqualTo(hour));
            Assert.That(dhm.Minute, Is.EqualTo(minute));
        }

        [Test, Sequential]
        public void FromTuple(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            DayHourMinute dhm = (day, hour, minute);
            Assert.That(dhm.Day, Is.EqualTo(day));
            Assert.That(dhm.Hour, Is.EqualTo(hour));
            Assert.That(dhm.Minute, Is.EqualTo(minute));
        }

        [Test, Sequential]
        public void Deconstruction(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            DayHourMinute dhm = (day, hour, minute);
            var (d, h, m) = dhm;
            Assert.That(d, Is.EqualTo(day));
            Assert.That(h, Is.EqualTo(hour));
            Assert.That(m, Is.EqualTo(minute));
        }

        [Test]
        public void DayValidRange([Range(1, 31)] int day)
        {
            var dhm = new DayHourMinute(day, 0, 0);
            Assert.That(dhm.Day, Is.EqualTo(day));
        }

        [Test]
        public void HourValidRange([Range(0, 23)] int hour)
        {
            var dhm = new DayHourMinute(1, hour, 0);
            Assert.That(dhm.Hour, Is.EqualTo(hour));
        }

        [Test]
        public void MinuteValidRange([Range(0, 59)] int minute)
        {
            var dhm = new DayHourMinute(1, 0, minute);
            Assert.That(dhm.Minute, Is.EqualTo(minute));
        }

        [Test]
        public void DayInvalidRange([Values(-5, 0, 32, 100)] int day)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DayHourMinute(day, 0, 0));
        }

        [Test]
        public void HourInvalidRange([Values(-5, -1, 24, 100)] int hour)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DayHourMinute(1, hour, 0));
        }

        [Test]
        public void MinuteInvalidRange([Values(-5, -1, 60, 100)] int minute)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DayHourMinute(1, 0, minute));
        }

        [Test, Sequential]
        public void Equals(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            object dhm1 = new DayHourMinute(day, hour, minute);
            object dhm2 = new DayHourMinute(day, hour, minute);
            Assert.That(dhm1.Equals(dhm2), "dhm1.Equals(dhm2)");
            Assert.That(dhm2.Equals(dhm1), "dhm2.Equals(dhm1)");
        }

        [Test, Sequential]
        public void EquatableEquals(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            var dhm1 = new DayHourMinute(day, hour, minute);
            var dhm2 = new DayHourMinute(day, hour, minute);
            Assert.That(dhm1.Equals(dhm2), "dhm1.Equals(dhm2)");
            Assert.That(dhm2.Equals(dhm1), "dhm2.Equals(dhm1)");
        }

        [Test, Sequential]
        public void EqualsOperator(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            var dhm1 = new DayHourMinute(day, hour, minute);
            var dhm2 = new DayHourMinute(day, hour, minute);
            Assert.That(dhm1 == dhm2, "dhm1 == dhm2");
            Assert.That(dhm2 == dhm1, "dhm2 == dhm1");
        }

        [Test, Sequential]
        public void NotEqualsOperator(
            [Random(1, 31, 5)] int day,
            [Random(0, 23, 5)] int hour,
            [Random(0, 59, 5)] int minute)
        {
            var dhm1 = new DayHourMinute(day, hour, minute);
            var dhm2 = new DayHourMinute(31 - day, 23 - hour, 59 - minute);
            Assert.That(dhm1 != dhm2, "dhm1 != dhm2");
            Assert.That(dhm2 != dhm1, "dhm2 != dhm1");
        }
    }
}
