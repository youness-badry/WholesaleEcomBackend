using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleEcomBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ICharacteristicService _characteristicService;

        public CategoriesController(ICategoryService categoryService, ICharacteristicService characteristicService)
        {
            _categoryService = categoryService;
            _characteristicService = characteristicService;
        }

        [HttpGet]
        public ActionResult<List<CategoryReadDto>> GetCategories()
        {
            var categories = _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public ActionResult<CategoryReadDto> GetCategory(int id)
        {
            var category = _categoryService.GetCategoryById(id);
            if (category == null)
            {
                throw new CategoryNotFoundException(id);
            }
            return Ok(category);

        }

        [HttpPost]
        public ActionResult<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreateDto)
        {
            if (categoryCreateDto == null)
            {
                return BadRequest("categoryCreateDto object is null");
            }
            var createdCategory = _categoryService.CreateCategory(categoryCreateDto);

            return CreatedAtRoute(nameof(GetCategory), new { id = createdCategory.Id }, createdCategory);

        }

        [HttpGet("subcategories")]
        public ActionResult<List<SubCategoryReadDto>> GetAllSubCategories()
        {
            var allSubCategories = _categoryService.GetAllSubCategories();
            return Ok(allSubCategories);

        }

        [HttpGet("{categoryId}/subcategories")]
        public ActionResult<List<SubCategoryReadDto>> GetSubCategoriesOfCategory(int categoryId)
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null)
            {
                throw new CategoryNotFoundException(categoryId);
            }
            else
            {
                var subCategoriesOfCategory = _categoryService.GetSubCategoriesOfCategory(categoryId);
                if (subCategoriesOfCategory == null)
                {
                    throw new SubcategoriesOfCategoryNotFoundException(categoryId);
                }
                return Ok(subCategoriesOfCategory);
            }

        }

        [HttpGet("subcategories/{id}", Name = "GetSubCategory")]
        public ActionResult<SubCategoryReadDto> GetSubCategory(int id)
        {
            var subCategory = _categoryService.GetSubCategory(id);
            if (subCategory == null)
            {
                throw new SubCategoryNotFoundException(id);
            }
            return Ok(subCategory);

        }

        [HttpPost("subcategories")]
        public ActionResult<SubCategoryReadDto> CreateSubCategory(SubCategoryCreateDto subCategoryCreateDto)
        {
            if (subCategoryCreateDto == null)
            {
                return BadRequest("subCategoryCreateDto object is null");
            }
            var createdSubCategory = _categoryService.CreateSubCategory(subCategoryCreateDto);

            return CreatedAtRoute(nameof(GetSubCategory), new { id = createdSubCategory.Id }, createdSubCategory);
        }

        [HttpGet("subcategories/subsubcategories")]
        public ActionResult<List<SubSubCategoryReadDto>> GetAllSubSubCategories()
        {
            var subSubCategories = _categoryService.GetAllSubSubCategories();
            return Ok(subSubCategories);

        }

        [HttpGet("subcategories/{subCategoryId}/subsubcategories")]
        public ActionResult<List<SubSubCategoryReadDto>> GetSubSubCategoriesOfSubCategory(int subCategoryId)
        {
            var subCategory = _categoryService.GetSubCategory(subCategoryId);
            if (subCategory == null)
            {
                throw new SubCategoryNotFoundException(subCategoryId);
            }
            else
            {
                var subSubCategoriesOfSubCategory = _categoryService.GetSubSubCategoriesOfSubCategory(subCategoryId);
                return Ok(subSubCategoriesOfSubCategory);

            }

        }

        [HttpGet("subcategories/subsubcategories/{subSubCategoryId}/characteristics")]
        public ActionResult<List<CharacteristicReadDto>> GetCharacteristicsOfSubSubCategory(int subSubCategoryId)
        {
            var subSubCategory = _categoryService.GetSubSubCategory(subSubCategoryId);
            if (subSubCategory == null)
            {
                throw new SubSubCategoryNotFoundException(subSubCategoryId);
            }
            else
            {
                var characteristics = _characteristicService.GetCharacteristicsOfSubSubCategory(subSubCategoryId);
                return Ok(characteristics);

            }

        }


        [HttpGet("subcategories/subsubcategories/{id}", Name = "GetSubSubCategory")]
        public ActionResult<SubSubCategoryReadDto> GetSubSubCategory(int id)
        {
            var subSubCategory = _categoryService.GetSubSubCategory(id);
            if (subSubCategory == null)
            {
                throw new SubSubCategoryNotFoundException(id);
            }
            return Ok(subSubCategory);

        }

        [HttpPost("subcategories/subsubcategories")]
        public ActionResult<SubSubCategoryReadDto> CreateSubSubCategory(SubSubCategoryCreateDto subSubCategoryCreateDto)
        {
            if (subSubCategoryCreateDto == null)
            {
                return BadRequest("subSubCategoryCreateDto object is null");
            }
            var createdSubSubCategory = _categoryService.CreateSubSubCategory(subSubCategoryCreateDto);

            return CreatedAtRoute(nameof(GetSubSubCategory), new { id = createdSubSubCategory.Id }, createdSubSubCategory);

        }


    }
}
