using System.ComponentModel.DataAnnotations;

namespace PropertyAPI.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Name is mandatory")]
        [StringLength (50, MinimumLength = 3)]
        [RegularExpression(".*[a-zA-Z]+.*", ErrorMessage = "Only numerics are not allowed")]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
