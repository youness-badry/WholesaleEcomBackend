namespace WholesaleEcomBackend.Exceptions
{
    public class CharacteristicNotFoundException : NotFoundException
    {
        public CharacteristicNotFoundException(int id) : base($"Characteristic with id: {id} doesn't exist in the database")
        {
            
        }
    }
}
