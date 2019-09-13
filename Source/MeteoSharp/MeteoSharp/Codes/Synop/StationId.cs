using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace MeteoSharp.Codes.Synop
{
    public readonly struct StationId
    {
        private static readonly Regex AreaRegex = new Regex(@"^(?<area>\d{2})(?<buoy>\w{3})$", RegexOptions.CultureInvariant);
        private static readonly Regex CodeSignRegex = new Regex(@"^\w{3,}$", RegexOptions.CultureInvariant);

        public StationId(string id)
        {
            Id = id ?? throw new ArgumentNullException(nameof(id));
        }

        public string Id { [MethodImpl(MethodImplOptions.AggressiveInlining)] get; }

        public static implicit operator string(StationId id) => id.Id;

        public (string area, string buoy) GetAreaAndBuoy()
        {
            var match = AreaRegex.Match(Id);
            return match.Success ? (match.Groups["area"].Value, match.Groups["buoy"].Value) : (null, null);
        }

        public string CodeSign
        {
            get
            {
                var match = CodeSignRegex.Match(Id);
                return match.Success ? match.Value : null;
            }
        }
    }
}
