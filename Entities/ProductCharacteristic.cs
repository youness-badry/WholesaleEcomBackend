namespace WholesaleEcomBackend.Entities
{
    public class ProductCharacteristic
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CharacteristicId { get; set; }
        public Characteristic Characteristic { get; set; }
        public string CharacteristicValue { get; set;}
    }
}
