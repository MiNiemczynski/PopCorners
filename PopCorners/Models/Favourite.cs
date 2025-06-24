using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PopCorners.Models;

[Index("UserId", "ProductionId", Name = "UQ__Favourit__5AD55682A6294CA1", IsUnique = true)]
public partial class Favourite
{
    [Key]
    [Column("FavouritesID")]
    public int FavouritesId { get; set; }

    [Column("UserID")]
    public int UserId { get; set; }

    [Column("ProductionID")]
    public int ProductionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreationDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? EditionDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DeletionDate { get; set; }

    public bool? IsActive { get; set; }

    [ForeignKey("ProductionId")]
    [InverseProperty("Favourites")]
    public virtual Production Production { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Favourites")]
    public virtual User User { get; set; } = null!;
}
