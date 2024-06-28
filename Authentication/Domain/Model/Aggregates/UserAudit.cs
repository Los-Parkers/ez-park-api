using System.ComponentModel.DataAnnotations.Schema;

namespace ez_park_platform.Authentication.Domain.Model.Aggregates
{
    public partial class UserAudit
    {
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
        [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
    }
}
