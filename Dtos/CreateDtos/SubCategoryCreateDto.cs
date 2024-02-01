using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class SubCategoryCreateDto
    {
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
    }
}
