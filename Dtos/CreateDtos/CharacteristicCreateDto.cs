using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class CharacteristicCreateDto
    {
        [Required]
        public string Name { get; set; }

        public int SubSubCategoryId { get; set; }
    }
}
