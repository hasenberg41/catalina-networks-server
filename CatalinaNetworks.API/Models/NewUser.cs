namespace CatalinaNetworks.API.Models
{
    public class NewUser
    {
        public string Name { get; set; } = null!;

        public string? UniqueUrlName { get; set; }

        public Photos? Photos { get; set; }
    }
}
