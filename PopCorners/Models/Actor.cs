using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Actor
{
    [Key]
    [Column("ActorID")]
    public int ActorId { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string FullName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [InverseProperty("Actor")]
    public virtual ICollection<ProductionCast> ProductionCasts { get; set; } = new List<ProductionCast>();
}
