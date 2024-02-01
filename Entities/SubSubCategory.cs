using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Entities
{
    public class SubSubCategory : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<Characteristic> Characteristics { get; set; }

        public List<Product> Products { get; set; }

    }
}
