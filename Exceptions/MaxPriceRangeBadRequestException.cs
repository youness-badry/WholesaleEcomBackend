namespace WholesaleEcomBackend.Exceptions
{
    public class MaxPriceRangeBadRequestException : BadRequestException
    {
        public MaxPriceRangeBadRequestException() : base("Max Price can't be less than Min Price")
        {
            
        }
    }
}
