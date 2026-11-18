using System.ComponentModel.DataAnnotations;

namespace APCMS.API.DTOs.Countries
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 250 characters.")]
        public required string Name { get; set; }
    }
}
