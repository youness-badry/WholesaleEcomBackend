using WholesaleEcomBackend.Dtos;
using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Repository.Interfaces
{
    public interface ISubCategoryRepo
    {
        List<SubCategory> GetAllSubCategories();
        List<SubCategory> GetSubCategoriesOfCategory(int categoryId);
        SubCategory GetSubCategory(int id);
        SubCategory CreateSubCategory(SubCategory subCategory);
    }
}
