using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Entities
{
    public class Category : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }

        public List<SubCategory> SubCategories { get; set; }
        public string ImageUrl { get; set; }

    }
}
