namespace WholesaleEcomBackend.Exceptions
{
    public class BrandNotFoundException : NotFoundException
    {
        public BrandNotFoundException(int id) : base($"Brand with id : {id} doesn't exist in the database")
        {
            
        }
    }
}
