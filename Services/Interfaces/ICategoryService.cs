using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.RequestFeatures;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleEcomBackend.Services.Interfaces
{
    public interface ICategoryService
    {
        /*Category*/
        CategoryReadDto GetCategoryById(int id);
        CategoryReadDto CreateCategory(CategoryCreateDto categoryCreateDto);
        List<CategoryReadDto> GetCategories();

        /*SubCategory*/
        List<SubCategoryReadDto> GetAllSubCategories();
        List<SubCategoryReadDto> GetSubCategoriesOfCategory(int categoryId);
        SubCategoryReadDto GetSubCategory(int id);
        SubCategoryReadDto CreateSubCategory(SubCategoryCreateDto subCategoryCreateDto);

        /*SubSubCategory*/
        List<SubSubCategoryReadDto> GetAllSubSubCategories();
        List<SubSubCategoryReadDto> GetSubSubCategoriesOfSubCategory(int subCategoryId);
        SubSubCategoryReadDto GetSubSubCategory(int id);
        SubSubCategoryReadDto CreateSubSubCategory(SubSubCategoryCreateDto subsubCategoryCreateDto);

    }
}
