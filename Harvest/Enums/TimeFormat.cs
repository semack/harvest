using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Harvest.Enums
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum TimeFormat
	{
		[EnumMember(Value = "decimal")]
		Decimal,

		[EnumMember(Value = "hours_minutes")]
		HoursMinutes
	}
}
