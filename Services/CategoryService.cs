using AutoMapper;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository;
using WholesaleEcomBackend.Repository.Interfaces;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;

namespace WholesaleEcomBackend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly ISubCategoryRepo _subCategoryRepo;
        private readonly ISubSubCategoryRepo _subSubCategoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo categoryRepo,
                               ISubCategoryRepo subCategoryRepo,
                               ISubSubCategoryRepo subSubCategoryRepo,
                               IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _subCategoryRepo = subCategoryRepo;
            _subSubCategoryRepo = subSubCategoryRepo;
            _mapper = mapper;
        }

        /*Category*/
        public CategoryReadDto CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            _categoryRepo.CreateCategory(category);
            return _mapper.Map<CategoryReadDto>(category);
        }

        public List<CategoryReadDto> GetCategories()
        {
            var categories = _categoryRepo.GetCategories();
            return _mapper.Map<List<Category>, List<CategoryReadDto>>(categories);
        }

        public CategoryReadDto GetCategoryById(int id)
        {
            var category = _categoryRepo.GetCategoryById(id);
            return _mapper.Map<CategoryReadDto>(category); 
        }

        /*SubCategory*/
        public SubCategoryReadDto CreateSubCategory(SubCategoryCreateDto subCategoryCreateDto)
        {
            var subCategory = _mapper.Map<SubCategory>(subCategoryCreateDto);
            _subCategoryRepo.CreateSubCategory(subCategory);
            return _mapper.Map<SubCategoryReadDto>(subCategory);
        }

        public List<SubCategoryReadDto> GetAllSubCategories()
        {
            var allSubCategories = _subCategoryRepo.GetAllSubCategories();
            return _mapper.Map<List<SubCategory>, List<SubCategoryReadDto>>(allSubCategories);
        }

        public List<SubCategoryReadDto> GetSubCategoriesOfCategory(int categoryId)
        {
            var subCategoriesOfCategory = _subCategoryRepo.GetSubCategoriesOfCategory(categoryId);
            return _mapper.Map<List<SubCategory>, List<SubCategoryReadDto>>(subCategoriesOfCategory);
        }
           
        public SubCategoryReadDto GetSubCategory(int id)
        {
            var subCategory = _subCategoryRepo.GetSubCategory(id);
            return _mapper.Map<SubCategoryReadDto>(subCategory);
        }

        /*SubSubCategory*/
        public List<SubSubCategoryReadDto> GetAllSubSubCategories()
        {
            var allSubSubCategories = _subSubCategoryRepo.GetAllSubSubCategories();
            return _mapper.Map<List<SubSubCategory>, List<SubSubCategoryReadDto>>(allSubSubCategories);
        }

        public List<SubSubCategoryReadDto> GetSubSubCategoriesOfSubCategory(int subCategoryId)
        {
            var subSubCategoriesOfSubCategory = _subSubCategoryRepo.GetSubSubCategoriesOfSubCategory(subCategoryId);
            return _mapper.Map<List<SubSubCategory>, List<SubSubCategoryReadDto>>(subSubCategoriesOfSubCategory);

        }

        public SubSubCategoryReadDto GetSubSubCategory(int id)
        {
            var subSubCategory = _subSubCategoryRepo.GetSubSubCategory(id);
            return _mapper.Map<SubSubCategoryReadDto>(subSubCategory);
        }

        public SubSubCategoryReadDto CreateSubSubCategory(SubSubCategoryCreateDto subsubCategoryCreateDto)
        {
            var subSubCategory = _mapper.Map<SubSubCategory>(subsubCategoryCreateDto);
            _subSubCategoryRepo.CreateSubSubCategory(subSubCategory);
            return _mapper.Map<SubSubCategoryReadDto>(subSubCategory);
        }


    }
}
