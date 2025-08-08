using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Entities
{
    public class Characteristic : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool DisplayInFilters { get; set; }

        public int SubSubCategoryId { get; set; } 
        public SubSubCategory SubSubCategory { get; set; }

        public List<Product> Products { get; set; }
        public List<ProductCharacteristic> ProductCharacteristics { get; set; }
    }
}
