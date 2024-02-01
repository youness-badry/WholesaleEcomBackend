namespace WholesaleEcomBackend.Exceptions
{
    public class SubcategoriesOfCategoryNotFoundException : NotFoundException
    {
        public SubcategoriesOfCategoryNotFoundException(int categoryId) : base($"Category with id: {categoryId} doesn't have subcategories")
        {
        }
    }
}
