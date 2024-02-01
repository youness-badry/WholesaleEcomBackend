using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class SubSubCategoryCreateDto
    {
        [Required]
        public string Name { get; set; }

        public int SubCategoryId { get; set; }
    }
}
