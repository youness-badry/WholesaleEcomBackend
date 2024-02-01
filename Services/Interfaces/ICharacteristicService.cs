using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Services.Interfaces
{
    public interface ICharacteristicService
    {
        List<CharacteristicReadDto> GetAllCharacteristics();
        CharacteristicReadDto GetCharacteristic(int id);

        List<CharacteristicReadDto> GetCharacteristicsOfSubSubCategory(int subSubCategoryId);

        CharacteristicReadDto CreateCharacteristic(CharacteristicCreateDto characteristicCreateDto);

    }
}
