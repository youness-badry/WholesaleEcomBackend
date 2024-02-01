using WholesaleEcomBackend.Data;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository.Interfaces;
using WholesaleEcomBackend.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WholesaleEcomBackend.Repository
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly StoreContext _storeContext;

        public CategoryRepo(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public Category CreateCategory(Category category)
        {
            _storeContext.Categories.Add(category);
            _storeContext.SaveChanges();
            return category;
        }

        public List<Category> GetCategories()
        {
            var categories = _storeContext.Categories
                            .OrderBy(ct => ct.Id)
                            .Include(ct => ct.SubCategories)
                            .ThenInclude(s => s.SubSubCategories)
                            .ToList();

            return categories;
        }

        public Category GetCategoryById(int id)
        {
            return _storeContext.Categories
                        .Include(c => c.SubCategories)
                        .ThenInclude(s => s.SubSubCategories)
                        .Where(c => c.Id == id)
                        .FirstOrDefault();

           // There is an error here, to Test !!! (test with id that doesn't exist)

        }
    }
}
