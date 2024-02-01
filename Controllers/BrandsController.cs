using AutoMapper;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.RequestFeatures;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WholesaleEcomBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public ActionResult<List<BrandReadDto>> GetBrands([FromQuery] BrandParameters brandParameters)
        {
            var pagedBrands = _brandService.GetBrandsWithPaging(brandParameters);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedBrands.metaData));
            return Ok(pagedBrands.brands);
        }

        [HttpGet("{id}", Name = "GetBrand")]
        public ActionResult<BrandReadDto> GetBrand(int id)
        {
            var brand = _brandService.GetBrandById(id);
            if(brand == null)
            {
                throw new BrandNotFoundException(id);
            }
            return Ok(brand);
        }


        [HttpPost]
        public ActionResult<BrandReadDto> CreateBrand(BrandCreateDto brandCreateDto)
        {
            if(brandCreateDto is null)
            {
                return BadRequest("BrandCreateDto object is null");
            }

            var createdBrand = _brandService.CreateBrand(brandCreateDto);

            return CreatedAtRoute(nameof(GetBrand), new { id = createdBrand.Id }, createdBrand);

        }



    }
}
