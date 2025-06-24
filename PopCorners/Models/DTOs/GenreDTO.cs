namespace PopCorners.Models.DTOs
{
    public class GenreDTO
    {
        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
