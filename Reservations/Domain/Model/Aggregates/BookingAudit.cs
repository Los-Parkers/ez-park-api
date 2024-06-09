using System.ComponentModel.DataAnnotations.Schema;

namespace ez_park_platform.Reservations.Domain.Model.Aggregates
{
    public partial class BookingAudit
    {
        [Column("CreatedAt")] public DateTimeOffset CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset UpdatedDate { get; set; }
    }
}
