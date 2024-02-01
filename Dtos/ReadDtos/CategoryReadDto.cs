using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Dtos.ReadDtos
{
    public class CategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubCategoryReadDto> SubCategories { get; set; }
        public string ImageUrl { get; set; }
    }
}
