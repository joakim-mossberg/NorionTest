using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VehicleTollApi.Infrastructure.Persistence.Models;

public class VehiclePassage
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string? LicensePlateNumber { get; set; }
    public DateTimeOffset PassageDateTime { get; set; }
    [ForeignKey(nameof(VehiclePassageInvoice))]
    public Guid VehiclePassageInvoiceId { get; set; }
    public VehiclePassageInvoice? VehiclePassageInvoice { get; set; }
}
