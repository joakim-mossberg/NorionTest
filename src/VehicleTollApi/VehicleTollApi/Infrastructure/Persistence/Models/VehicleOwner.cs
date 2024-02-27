using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleTollApi.Infrastructure.Persistence.Models;

public class VehicleOwner
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public ICollection<Vehicle>? Vehicles { get; }
    public ICollection<VehiclePassageInvoice>? VehiclePassageInvoices { get; }
}
