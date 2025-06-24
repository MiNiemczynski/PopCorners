namespace PopCorners.Models.DTOs
{
    public class PlatformDTO
    {
        public int PlatformId { get; set; }
        public string? PlatformName { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
