using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Production
{
    [Key]
    [Column("ProductionID")]
    public int ProductionId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public int? Duration { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column("DirectorID")]
    public int? DirectorId { get; set; }

    [Column("PlatformID")]
    public int? PlatformId { get; set; }

    public int? EpisodeNumber { get; set; }

    [Column("SeasonID")]
    public int? SeasonId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("DirectorId")]
    [InverseProperty("Productions")]
    public virtual Director? Director { get; set; }

    [InverseProperty("Production")]
    public virtual ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();

    [ForeignKey("PlatformId")]
    [InverseProperty("Productions")]
    public virtual Platform? Platform { get; set; }

    [InverseProperty("Production")]
    public virtual ICollection<ProductionAward> ProductionAwards { get; set; } = new List<ProductionAward>();

    [InverseProperty("Production")]
    public virtual ICollection<ProductionCast> ProductionCasts { get; set; } = new List<ProductionCast>();

    [InverseProperty("Production")]
    public virtual ICollection<ProductionGenre> ProductionGenres { get; set; } = new List<ProductionGenre>();

    [InverseProperty("Production")]
    public virtual ICollection<ProductionTag> ProductionTags { get; set; } = new List<ProductionTag>();

    [InverseProperty("Production")]
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [ForeignKey("SeasonId")]
    [InverseProperty("Productions")]
    public virtual Season? Season { get; set; }
}
