using System.ComponentModel.DataAnnotations;

namespace APCMS.API.DTOs.Professions
{
    public class UpdateProfessionDTO
    {
        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 250 characters.")]
        public required string Name { get; set; }
    }
}
