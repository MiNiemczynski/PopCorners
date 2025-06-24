using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Index("ProductionId", "UserId", Name = "UQ__Reviews__04A12E3EBFE94041", IsUnique = true)]
public partial class Review
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    [Column("ProductionID")]
    public int ProductionId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    public int Rating { get; set; }

    [Column(TypeName = "text")]
    public string? Comment { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("ProductionId")]
    [InverseProperty("Reviews")]
    public virtual Production Production { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Reviews")]
    public virtual User User { get; set; } = null!;
}
