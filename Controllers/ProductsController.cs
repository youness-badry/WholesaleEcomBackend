using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WholesaleEcomBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController : ControllerBase
    {
        
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<ProductReadDto>> GetProducts([FromQuery] ProductParameters productParameters)
        {
            var pagedProducts = _productService.GetProductsWithPaging(productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedProducts.metaData));
            return Ok(pagedProducts.products);
        }

        [HttpGet("filter")]
        public ActionResult<List<ProductReadDto>> GetProductsWithFilter([FromQuery] ProductParameters productParameters) 
        {
            var productsFiltered = _productService.GetProductsWithFilterAndPaging(productParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(productsFiltered.metaData));
            return Ok(productsFiltered.products);
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
    }
}
