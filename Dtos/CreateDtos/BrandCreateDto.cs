using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class BrandCreateDto
    {
        [Required]
        public string Name { get; set; }
    }
}
