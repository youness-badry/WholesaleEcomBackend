using WholesaleEcomBackend.Entities;

namespace WholesaleEcomBackend.Repository.Interfaces
{
    public interface ISubSubCategoryRepo
    {
        List<SubSubCategory> GetAllSubSubCategories();
        List<SubSubCategory> GetSubSubCategoriesOfSubCategory(int subCategoryId);
        SubSubCategory GetSubSubCategory(int id);
        SubSubCategory CreateSubSubCategory(SubSubCategory subSubCategory);
    }
}
