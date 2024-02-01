using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Exceptions;
using WholesaleEcomBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleEcomBackend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacteristicsController : ControllerBase
    {
        private readonly ICharacteristicService _characteristicService;
        private readonly ICategoryService _categoryService;

        public CharacteristicsController(ICharacteristicService characteristicService, 
                                         ICategoryService categoryService)
        {
            _characteristicService = characteristicService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<CharacteristicReadDto>> GetAllCharacteristics() 
        { 
            var allCharacteristics = _characteristicService.GetAllCharacteristics();
            return Ok(allCharacteristics);

        }

        [HttpGet("{id}", Name = "GetCharacteristic")]
        public ActionResult<CharacteristicReadDto> GetCharacteristic(int id)
        {
            var characteristic = _characteristicService.GetCharacteristic(id);
            if (characteristic == null)
            {
                throw new CharacteristicNotFoundException(id);
            }
            
            return Ok(characteristic);

        }

        
        [HttpPost]
        public ActionResult<CharacteristicReadDto> CreateCharacteristic(CharacteristicCreateDto characteristicCreateDto)
        {
            if (characteristicCreateDto == null)
            {
                return BadRequest("characteristicCreateDto object is null");
            }

            var characteristicCreated = _characteristicService.CreateCharacteristic(characteristicCreateDto);

            return CreatedAtRoute(nameof(GetCharacteristic), new { id = characteristicCreated.Id }, characteristicCreated);

        }


    }
}
