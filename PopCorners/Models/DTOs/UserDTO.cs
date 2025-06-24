namespace PopCorners.Models.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public List<ProductionDTO> Favourite { get; set; } = null!;
        public List<ProductionDTO> Reviews { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
