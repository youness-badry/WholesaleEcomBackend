using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Collections;

namespace WholesaleEcomBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet("search")]
        public ActionResult<List<ProductReadDto>> SearchProducts([FromQuery] ProductParameters productParameters)
        {
            var productsAfterSearch = _productService.SearchProducts(productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(productsAfterSearch.metaData));
            return Ok(productsAfterSearch.products);

        }


        [HttpGet("{id}", Name = "GetProduct")]
        public ActionResult<ProductReadDto> GetProduct(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                throw new ProductNotFoundException(id);
            }
            return Ok(product);
        }

        [HttpPost]
        public ActionResult<ProductReadDto> CreateProduct(ProductCreateDto productCreateDto)
        {
            if (productCreateDto == null)
            {
                return BadRequest("productCreateDto object is null");
            }

            var createdProduct = _productService.CreateProduct(productCreateDto);

            return CreatedAtRoute(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);

        }

        [HttpGet("subsubcategory/{subsubcategoryId}")]
        public ActionResult<List<ProductReadDto>> GetProductsBySubsubcategoryIdWithPagingAndFilters(int subsubcategoryId, [FromQuery] ProductParameters productParameters)
        {
            var subsubcategory = _categoryService.GetSubSubCategory(subsubcategoryId);
            if (subsubcategory == null)
            {
                throw new SubSubCategoryNotFoundException(subsubcategoryId);
            }

            var productsWithMetaData = _productService.GetProductsBySubsubcategoryIdWithPagingAndFilters(subsubcategoryId, productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(productsWithMetaData.metaData));
            return Ok(productsWithMetaData.products);
        }

        [HttpGet("subsubcategory/{subsubcategoryId}/characteristics/statistics")]
        public ActionResult<IList> GetCharacteristicsStatisticsOfProductsInSubsubcategory(int subsubcategoryId, [FromQuery] ProductParameters productParameters)
        {
            var subsubcategory = _categoryService.GetSubSubCategory(subsubcategoryId);
            if (subsubcategory == null)
            {
                throw new SubSubCategoryNotFoundException(subsubcategoryId);
            }
            var listCharacteristicStatistics = _productService.GetCharacteristicStatisticsOfProductsInSubsubcategory(subsubcategoryId, productParameters);

            return Ok(listCharacteristicStatistics);

            
        }

        [HttpGet("subsubcategory/{subsubcategoryId}/brands/statistics")]
        public ActionResult<IList> GetBrandsStatisticsOfProductsInSubsubcategory(int subsubcategoryId, [FromQuery] ProductParameters productParameters)
        {
            var subsubcategory = _categoryService.GetSubSubCategory(subsubcategoryId);
            if (subsubcategory == null)
            {
                throw new SubSubCategoryNotFoundException(subsubcategoryId);
            }
            var listBrandsStatistics = _productService.GetBrandsStatisticsOfProductsInSubsubcategory(subsubcategoryId, productParameters);

            return Ok(listBrandsStatistics);


        }

    }
}
