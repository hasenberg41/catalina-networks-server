using System.ComponentModel.DataAnnotations;

namespace CatalinaNetworks.DataBase.Entities
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(300)]
        public string? UniqueUrlName { get; set; }

        public Photos? Photos { get; set; }
    }
}
