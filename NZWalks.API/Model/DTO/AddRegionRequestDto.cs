using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.Model.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Minimum of 3 Characters")]
        [MaxLength(3, ErrorMessage = "Maximum of 3 Characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum of 100 Characters")]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
