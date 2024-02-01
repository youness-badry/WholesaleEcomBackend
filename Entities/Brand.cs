using System.ComponentModel.DataAnnotations;

namespace WholesaleEcomBackend.Entities
{
    public class Brand : BaseEntity<int>, IEntity
    {
        [Required]
        public string Name { get; set; }
    }
}
