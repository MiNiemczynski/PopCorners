using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Index("AwardId", "ProductionId", Name = "UQ__Producti__FDD4AFF01E8C5957", IsUnique = true)]
public partial class ProductionAward
{
    [Key]
    [Column("ProductionAwardID")]
    public int ProductionAwardId { get; set; }

    [Column("AwardID")]
    public int AwardId { get; set; }

    [Column("ProductionID")]
    public int ProductionId { get; set; }

    public DateOnly? AwardDate { get; set; }

    [ForeignKey("AwardId")]
    [InverseProperty("ProductionAwards")]
    public virtual Award Award { get; set; } = null!;

    [ForeignKey("ProductionId")]
    [InverseProperty("ProductionAwards")]
    public virtual Production Production { get; set; } = null!;
}
