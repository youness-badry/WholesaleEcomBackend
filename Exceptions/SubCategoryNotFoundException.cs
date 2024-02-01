namespace WholesaleEcomBackend.Exceptions
{
    public class SubCategoryNotFoundException : NotFoundException
    {
        public SubCategoryNotFoundException(int id) : base($"SubCategory with id: {id} doesn't exist in the database")
        {
            
        }

    }
}
