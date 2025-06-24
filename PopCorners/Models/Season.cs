using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Index("SeriesId", "SeasonNumber", Name = "UQ__Seasons__F2241043806B5149", IsUnique = true)]
public partial class Season
{
    [Key]
    [Column("SeasonID")]
    public int SeasonId { get; set; }

    [Column("SeriesID")]
    public int SeriesId { get; set; }

    public int SeasonNumber { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Season")]
    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();

    [ForeignKey("SeriesId")]
    [InverseProperty("Seasons")]
    public virtual Series Series { get; set; } = null!;
}
