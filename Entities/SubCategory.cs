using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Entities
{
    public class SubCategory : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<SubSubCategory> SubSubCategories { get; set; }

    }
}
