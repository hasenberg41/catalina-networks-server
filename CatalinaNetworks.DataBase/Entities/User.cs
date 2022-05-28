using System.ComponentModel.DataAnnotations;

namespace CatalinaNetworks.DataBase.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string? UniqueUrlName { get; set; }

        public Photos? Photos { get; set; }
    }
}
