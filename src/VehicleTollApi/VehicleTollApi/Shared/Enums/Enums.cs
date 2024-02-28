using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace VehicleTollApi.Shared.Enums;

[JsonConverter(typeof(JsonStringEnumConverter<VehicleKind>))]
public enum VehicleKind
{
    [EnumMember(Value = "Car")]
    Car = 0,
    [EnumMember(Value = "Motorbike")]
    Motorbike = 1,
    [EnumMember(Value = "Tractor")]
    Tractor = 2,
    [EnumMember(Value = "Emergency")]
    Emergency = 3,
    [EnumMember(Value = "Diplomat")]
    Diplomat = 4,
    [EnumMember(Value = "Foreign")]
    Foreign = 5,
    [EnumMember(Value = "Military")]
    Military = 6,
}
