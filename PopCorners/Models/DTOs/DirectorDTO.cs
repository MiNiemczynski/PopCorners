namespace PopCorners.Models.DTOs
{
    public class DirectorDTO
    {
        public int DirectorId { get; set; }
        public string? FullName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
