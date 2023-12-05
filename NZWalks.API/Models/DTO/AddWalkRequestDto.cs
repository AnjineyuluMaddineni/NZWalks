﻿using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Code has to be a Maximum of 100 characters")]
        public string? Name { get; set; }
        [Required]
        [MaxLength(1000)]
        public string? Description { get; set; }
        [Required]
        [Range(0,50)]
        public double LengthInKm { get; set; }
        [Required]

        public string? WalkImageUrl { get; set; }
        [Required]
        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
    }
}
