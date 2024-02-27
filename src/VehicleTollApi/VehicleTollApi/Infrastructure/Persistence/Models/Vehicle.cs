using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.Infrastructure.Persistence.Models;

public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string LicensePlateNumber { get; set; } = default!;
    public VehicleKind VehicleKind { get; set; }
    [ForeignKey(nameof(VehicleOwner))]
    public Guid VehicleOwnerId { get; set; }
    public VehicleOwner? VehicleOwner { get; set; }
}