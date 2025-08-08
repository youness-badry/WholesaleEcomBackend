using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class CharacteristicCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool DisplayInFilters { get; set; }

        public int SubSubCategoryId { get; set; }
    }
}
