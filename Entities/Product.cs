using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WholesaleEcomBackend.Entities
{
    public class Product : BaseEntity<int>, IEntity
    {
        
        public string? Name { get; set; }
        
        [Required]
        public string Reference { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string StockStatus { get; set; }

        [Required]
        public string PictureUrl { get; set; }
        public int SubSubCategoryId { get; set; }
        public SubSubCategory SubSubCategory { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Characteristic> Characteristics { get; set; }
        public List<ProductCharacteristic> ProductCharacteristics { get; set; }


    }
}
