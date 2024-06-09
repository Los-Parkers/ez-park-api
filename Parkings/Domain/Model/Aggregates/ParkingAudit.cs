using System.ComponentModel.DataAnnotations.Schema;

namespace ez_park_platform.Parkings.Domain.Model.Aggregates
{
    public partial class ParkingAudit
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
