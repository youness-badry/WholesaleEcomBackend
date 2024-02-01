using WholesaleEcomBackend.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Dtos.CreateDtos
{
    public class ProductCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Reference { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string StockStatus { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        public int BrandId { get; set; }

        public int SubSubCategoryId { get; set; }
        public List<ProductCharacteristicCreateDto> ProductCharacteristics { get; set; }
    }
}
