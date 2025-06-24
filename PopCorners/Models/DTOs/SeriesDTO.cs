namespace PopCorners.Models.DTOs
{
    public class SeriesDTO
    {
        public int SeriesId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public List<SeasonDTO>? Seasons { get; set; }
        public int SeasonsCount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
