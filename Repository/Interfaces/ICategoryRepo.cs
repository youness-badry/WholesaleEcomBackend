using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;

namespace WholesaleEcomBackend.Repository.Interfaces
{
    public interface ICategoryRepo
    {
        Category CreateCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetCategories();
    }
}
