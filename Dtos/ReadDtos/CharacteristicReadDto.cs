using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Dtos.ReadDtos
{
    public class CharacteristicReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubSubCategoryReadDto SubSubCategory { get; set; }
    }
}
