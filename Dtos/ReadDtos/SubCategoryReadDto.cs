using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Dtos.ReadDtos
{
    public class SubCategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SubSubCategoryReadDto> SubSubCategories { get; set; }
    }
}
