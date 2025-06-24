namespace PopCorners.Models.DTOs
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public UserDTO? User { get; set; }
        public ProductionDTO? Production { get; set; }
        public string? Comment { get; set; }
        public int Rating { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
