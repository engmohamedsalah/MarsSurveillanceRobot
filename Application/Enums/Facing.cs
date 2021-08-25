using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Application.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Facing
    {
        [EnumMember(Value = "North")]
        North,

        [EnumMember(Value = "East")]
        East,

        [EnumMember(Value = "South")]
        South,

        [EnumMember(Value = "West")]
        West
    }
}