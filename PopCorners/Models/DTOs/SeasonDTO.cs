namespace PopCorners.Models.DTOs
{
    public class SeasonDTO
    {
        public int SeasonId { get; set; }
        public Series Series { get; set; } = null!;
        public int SeasonNumber { get; set; }
        public string? Description { get; set; }
        public List<ProductionDTO>? Episodes { get; set; }
        public int EpisodesCount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
