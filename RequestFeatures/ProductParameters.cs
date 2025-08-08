namespace WholesaleEcomBackend.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public uint? MinPrice { get; set; }
        public uint MaxPrice { get; set; } = int.MaxValue;
        public string? Brands { get; set; }
        public Dictionary<string, string>? CharacteristicValues { get; set; }
        public bool ValidPriceRange => MaxPrice > MinPrice;

        public string? SearchTerm { get; set; }

    }
}
