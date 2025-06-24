using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Series
{
    [Key]
    [Column("SeriesID")]
    public int SeriesId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Series")]
    public virtual ICollection<Season> Seasons { get; set; } = new List<Season>();
}
