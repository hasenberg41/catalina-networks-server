namespace CatalinaNetworks.Core.Exceptions
{
    public class InvalidUpdateException : Exception
    {
        public InvalidUpdateException(string name, object key)
            : base($"Entity \"{name}\" ({key}) cannot be updated. ")
        {

        }
    }
}
