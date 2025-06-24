using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

public partial class Director
{
    [Key]
    [Column("DirectorID")]
    public int DirectorId { get; set; }

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

    [InverseProperty("Director")]
    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
}
