using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Platform
{
    [Key]
    [Column("PlatformID")]
    public int PlatformId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string PlatformName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Platform")]
    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
}
