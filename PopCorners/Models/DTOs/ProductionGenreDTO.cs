namespace PopCorners.Models.DTOs
{
    public class ProductionGenreDTO
    {
        public int ProductionGenreId { get; set; }
        public ProductionDTO? Production { get; set; }
        public GenreDTO? Genre { get; set; }
    }
}
