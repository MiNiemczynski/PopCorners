namespace PopCorners.Models.DTOs
{
    public class FavouriteDTO
    {
        public int FavouriteId { get; set; }
        public UserDTO? User { get; set; }
        public ProductionDTO? Production { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
