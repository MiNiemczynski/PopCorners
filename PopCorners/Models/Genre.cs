using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Genre
{
    [Key]
    [Column("GenreID")]
    public int GenreId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string GenreName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Genre")]
    public virtual ICollection<ProductionGenre> ProductionGenres { get; set; } = new List<ProductionGenre>();
}
