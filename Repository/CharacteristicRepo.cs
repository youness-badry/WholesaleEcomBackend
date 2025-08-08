using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WholesaleEcomBackend.Repository
{
    public class CharacteristicRepo : ICharacteristicRepo
    {
        private readonly StoreContext _storeContext;

        public CharacteristicRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public Characteristic CreateCharacteristic(Characteristic characteristic)
        {
            _storeContext.Characteristics.Add(characteristic);
            _storeContext.SaveChanges();
            return characteristic;
        }

        public List<Characteristic> GetAllCharacteristics()
        {
            var allCharacteristics = _storeContext.Characteristics
                                     .OrderBy(c => c.Id)
                                     .Include(c => c.SubSubCategory)
                                     .ToList();

            return allCharacteristics;
        }

        public Characteristic GetCharacteristic(int id)
        {
            return _storeContext.Characteristics.Find(id);

        }

        public List<Characteristic> GetCharacteristicsOfSubSubCategory(int subSubCategoryId)
        {
            var characteristicsOfSubSubCategory = _storeContext.Characteristics
                                                    .Where(c => c.SubSubCategoryId == subSubCategoryId)
                                                    .OrderBy(c => c.Id)
                                                    .Include(c => c.SubSubCategory)
                                                    .ToList();

            return characteristicsOfSubSubCategory;

        }
    }
}
