namespace WholesaleEcomBackend.Dtos.ReadDtos
{
    public class FilterCharacteristicStatisticsReadDto
    {
        public int CharacteristicId { get; set; }
        public string CharacteristicName { get; set; }
        public string Value { get; set; }
        public int Count { get; set; }
    }

}
