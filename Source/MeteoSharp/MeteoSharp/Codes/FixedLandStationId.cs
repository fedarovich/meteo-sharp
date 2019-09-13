using System;
using System.Runtime.CompilerServices;

namespace MeteoSharp.Codes
{
    public readonly struct FixedLandStationId : IEquatable<FixedLandStationId>
    {
        public int Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        public int BlockNumber => Id / 1000;

        public int StationNumber => Id % 1000;

        public FixedLandStationId(string id) : this(int.Parse(id))
        {
        }

        public FixedLandStationId(int id)
        {
            if (id < 0 || id > 99999)
                throw new ArgumentOutOfRangeException(nameof(id));
            Id = id;
        }

        public static bool TryParse(string id, out FixedLandStationId result)
        {
            if (int.TryParse(id, out int intId) && intId >= 0 && intId <= 99999)
            {
                result = new FixedLandStationId(id);
                return true;
            }

            result = default;
            return false;
        }

        public void Deconstruct(out int blockNumber, out int stationNumber) => blockNumber = Math.DivRem(Id, 1000, out stationNumber);

        public bool Equals(FixedLandStationId other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            return obj is FixedLandStationId other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(FixedLandStationId left, FixedLandStationId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FixedLandStationId left, FixedLandStationId right)
        {
            return !left.Equals(right);
        }
    }
}
