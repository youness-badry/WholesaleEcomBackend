using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class CategoryCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
