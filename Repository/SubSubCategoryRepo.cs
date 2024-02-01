using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository.Interfaces;

namespace WholesaleEcomBackend.Repository
{
    public class SubSubCategoryRepo : ISubSubCategoryRepo
    {
        private readonly StoreContext _storeContext;

        public SubSubCategoryRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public SubSubCategory CreateSubSubCategory(SubSubCategory subSubCategory)
        {
            _storeContext.SubSubCategories.Add(subSubCategory);
            _storeContext.SaveChanges();
            return subSubCategory;
        }

        public List<SubSubCategory> GetAllSubSubCategories()
        {
            var subSubCategories = _storeContext.SubSubCategories
                                   .OrderBy(s => s.Name)
                                   .ToList();

            return subSubCategories;
        }

        public List<SubSubCategory> GetSubSubCategoriesOfSubCategory(int subCategoryId)
        {
            var subSubCategoriesOfSubCategory = _storeContext.SubSubCategories
                                                .Where(s => s.SubCategoryId == subCategoryId)
                                                .OrderBy(s => s.Name)
                                                .ToList();

            return subSubCategoriesOfSubCategory;
        }

        public SubSubCategory GetSubSubCategory(int id)
        {
            return _storeContext.SubSubCategories
                        .Where(c => c.Id == id)
                        .FirstOrDefault();
        }

    }
}
