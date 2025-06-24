using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Table("ProductionCast")]
public partial class ProductionCast
{
    [Key]
    [Column("ProductionCastID")]
    public int ProductionCastId { get; set; }

    [Column("ActorID")]
    public int ActorId { get; set; }

    [Column("ProductionID")]
    public int ProductionId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? ActorRole { get; set; }

    [ForeignKey("ActorId")]
    [InverseProperty("ProductionCasts")]
    public virtual Actor Actor { get; set; } = null!;

    [ForeignKey("ProductionId")]
    [InverseProperty("ProductionCasts")]
    public virtual Production Production { get; set; } = null!;
}
