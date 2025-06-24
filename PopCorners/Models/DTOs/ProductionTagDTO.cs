namespace PopCorners.Models.DTOs
{
    public class ProductionTagDTO
    {
        public int ProductionTagId { get; set; }
        public ProductionDTO? Production { get; set; }
        public TagDTO? Tag { get; set; }
    }
}
