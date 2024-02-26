using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleTollApi.Infrastructure.Persistence.Models;

public class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string LicensePlateNumber { get; set; } = default!;
    public VehicleOwner? VehicleOwner { get; set; }
}