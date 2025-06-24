using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Index("TagName", Name = "UQ__Tags__BDE0FD1D49B988FD", IsUnique = true)]
public partial class Tag
{
    [Key]
    [Column("TagID")]
    public int TagId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TagName { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Tag")]
    public virtual ICollection<ProductionTag> ProductionTags { get; set; } = new List<ProductionTag>();
}
