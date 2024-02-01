using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WholesaleEcomBackend.Repository
{
    public class SubCategoryRepo : ISubCategoryRepo
    {
        private readonly StoreContext _storeContext;

        public SubCategoryRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public SubCategory CreateSubCategory(SubCategory subCategory)
        {
            _storeContext.SubCategories.Add(subCategory);
            _storeContext.SaveChanges();
            return subCategory;
        }

        public List<SubCategory> GetAllSubCategories()
        {
            var allSubCategories = _storeContext.SubCategories
                                   .OrderBy(s => s.Name)
                                   .Include(s => s.SubSubCategories)
                                   .ToList();
            return allSubCategories;
        }

        public List<SubCategory> GetSubCategoriesOfCategory(int categoryId)
        {
            var subCategoriesOfCategory = _storeContext.SubCategories
                                           .Where(s => s.CategoryId == categoryId)
                                           .OrderBy(s => s.Name)
                                           .Include(s => s.SubSubCategories)
                                           .ToList();

            return subCategoriesOfCategory;
        }

        public SubCategory GetSubCategory(int id)
        {
            return _storeContext.SubCategories
                        .Where(c => c.Id == id)
                        .Include(c => c.SubSubCategories)
                        .FirstOrDefault();

        }
    }
}
