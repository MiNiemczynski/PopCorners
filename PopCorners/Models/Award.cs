using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Award
{
    [Key]
    [Column("AwardID")]
    public int AwardId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string AwardName { get; set; } = null!;

    public int Year { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Award")]
    public virtual ICollection<ProductionAward> ProductionAwards { get; set; } = new List<ProductionAward>();
}
