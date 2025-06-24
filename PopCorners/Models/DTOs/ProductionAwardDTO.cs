namespace PopCorners.Models.DTOs
{
    public class ProductionAwardDTO
    {
        public int ProductionAwardId { get; set; }
        public ProductionDTO? Production { get; set; }
        public AwardDTO? Award { get; set; }
        public DateOnly? AwardDate { get; set; }
    }
}
