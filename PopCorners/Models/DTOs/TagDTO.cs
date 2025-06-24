﻿namespace PopCorners.Models.DTOs
{
    public class TagDTO
    {
        public int TagId { get; set; }
        public string TagName { get; set; } = null!;
        public DateTime CreationDate { get; set; }
        public DateTime? EditionDate { get; set; }
    }
}
