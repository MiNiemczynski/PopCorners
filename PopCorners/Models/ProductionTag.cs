using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Index("ProductionId", "TagId", Name = "UQ__Producti__038E6D5027F69CBF", IsUnique = true)]
public partial class ProductionTag
{
    [Key]
    [Column("ProductionTagID")]
    public int ProductionTagId { get; set; }

    [Column("ProductionID")]
    public int ProductionId { get; set; }

    [Column("TagID")]
    public int TagId { get; set; }

    [ForeignKey("ProductionId")]
    [InverseProperty("ProductionTags")]
    public virtual Production Production { get; set; } = null!;

    [ForeignKey("TagId")]
    [InverseProperty("ProductionTags")]
    public virtual Tag Tag { get; set; } = null!;
}
