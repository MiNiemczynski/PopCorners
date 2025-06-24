namespace PopCorners.Models.DTOs
{
    public class AwardDTO
    {
        public int AwardId { get; set; }
        public string? AwardName { get; set; }
        public int Year { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
