using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Table("ProductionGenre")]
[Index("ProductionId", "GenreId", Name = "UQ__Producti__25E1F2A1010EBD3D", IsUnique = true)]
public partial class ProductionGenre
{
    [Key]
    [Column("ProductionGenreID")]
    public int ProductionGenreId { get; set; }

    [Column("GenreID")]
    public int GenreId { get; set; }

    [Column("ProductionID")]
    public int ProductionId { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("ProductionGenres")]
    public virtual Genre Genre { get; set; } = null!;

    [ForeignKey("ProductionId")]
    [InverseProperty("ProductionGenres")]
    public virtual Production Production { get; set; } = null!;
}
