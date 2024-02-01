namespace WholesaleEcomBackend.Exceptions
{
    public class SubSubCategoryNotFoundException : NotFoundException
    {
        public SubSubCategoryNotFoundException(int id) : base($"SubSubCategory with id: {id} doesn't exist in the database")
        {
            
        }
    }
}
