using AutoMapper;
using WholesaleEcomBackend.Dtos.CreateDtos;
using WholesaleEcomBackend.Dtos.ReadDtos;
using WholesaleEcomBackend.Entities;
using WholesaleEcomBackend.Repository;
using WholesaleEcomBackend.Repository.Interfaces;
using WholesaleEcomBackend.Services.Interfaces;
using System.Reflection.PortableExecutable;

namespace WholesaleEcomBackend.Services
{
    public class CharacteristicService : ICharacteristicService
    {
        private readonly ICharacteristicRepo _characteristicRepo;
        private readonly IMapper _mapper;

        public CharacteristicService(ICharacteristicRepo characteristicRepo, IMapper mapper)
        {
            _characteristicRepo = characteristicRepo;
            _mapper = mapper;
        }
        public CharacteristicReadDto CreateCharacteristic(CharacteristicCreateDto characteristicCreateDto)
        {
            var characteristic = _mapper.Map<Characteristic>(characteristicCreateDto);
            _characteristicRepo.CreateCharacteristic(characteristic);
            return _mapper.Map<CharacteristicReadDto>(characteristic);
        }

        public List<CharacteristicReadDto> GetAllCharacteristics()
        {
            var allCharacteristics = _characteristicRepo.GetAllCharacteristics();
            return _mapper.Map<List<Characteristic>, List<CharacteristicReadDto>>(allCharacteristics);
        }

        public CharacteristicReadDto GetCharacteristic(int id)
        {
            var characteristic = _characteristicRepo.GetCharacteristic(id);
            return _mapper.Map<CharacteristicReadDto>(characteristic);
        }

        public List<CharacteristicReadDto> GetCharacteristicsOfSubSubCategory(int subSubCategoryId)
        {
            var characteristicsOfSubSubCategory = _characteristicRepo.GetCharacteristicsOfSubSubCategory(subSubCategoryId);
            return _mapper.Map<List<Characteristic>, List<CharacteristicReadDto>>(characteristicsOfSubSubCategory);
        }
    }
}
