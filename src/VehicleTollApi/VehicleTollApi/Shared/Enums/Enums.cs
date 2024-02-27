using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace VehicleTollApi.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<VehicleKind>))]
public enum VehicleKind
{
    [EnumMember(Value = "Motorbike")]
    Motorbike = 0,
    [EnumMember(Value = "Tractor")]
    Tractor = 1,
    [EnumMember(Value = "Emergency")]
    Emergency = 2,
    [EnumMember(Value = "Diplomat")]
    Diplomat = 3,
    [EnumMember(Value = "Foreign")]
    Foreign = 4,
    [EnumMember(Value = "Military")]
    Military = 5,
    [EnumMember(Value = "Car")]
    Car = 6,
}
