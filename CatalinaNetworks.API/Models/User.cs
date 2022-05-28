using System.ComponentModel.DataAnnotations;

namespace CatalinaNetworks.API.Models
{
    public class User
    {
        public int Id { get; }

        [Required]
        public string Name { get; set; } = "";

        public string? UniqueUrlName { get; set; }

        public Photos? Photos { get; set; }
    }
}
