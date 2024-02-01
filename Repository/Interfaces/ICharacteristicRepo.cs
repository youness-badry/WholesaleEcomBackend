using WholesaleEcomBackend.Dtos;
using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Repository.Interfaces
{
    public interface ICharacteristicRepo
    {
        List<Characteristic> GetAllCharacteristics();
        Characteristic GetCharacteristic(int id);

        List<Characteristic> GetCharacteristicsOfSubSubCategory(int subSubCategoryId);

        Characteristic CreateCharacteristic(Characteristic characteristic);
    }
}
