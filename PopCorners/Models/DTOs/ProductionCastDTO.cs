namespace PopCorners.Models.DTOs
{
    public class ProductionCastDTO
    {
        public int ProductionCastId { get; set; }
        public ProductionDTO? Production { get; set; }
        public ActorDTO? Actor { get; set; }
        public string? Role { get; set; }
    }
}
