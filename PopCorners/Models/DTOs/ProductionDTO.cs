namespace PopCorners.Models.DTOs
{
    public class ProductionDTO
    {
        public int ProductionId { get; set; }
        public string Title { get; set; } = null!;
        public int Year { get; set; }
        public int? Time { get; set; }
        public string? Description { get; set; }
        public Director? Director { get; set; }
        public Platform? Platform { get; set; }
        public Season? Season { get; set; }
        public Series? Series { get; set; }
        public int? EpisodeNumber { get; set; }
        public string? DirectorName { get; set; }
        public string? PlatformName { get; set; }
        public string? SeriesTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
