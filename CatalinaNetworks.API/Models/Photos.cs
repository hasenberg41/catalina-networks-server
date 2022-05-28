using System.ComponentModel.DataAnnotations;

namespace CatalinaNetworks.API.Models
{
    public class Photos
    {
        public Photos(User user)
        {
            UserId = user.Id;
        }

        public int UserId { get; set; }

        public string Large { get; set; } = "";

        public string Small { get; set; } = "";
    }
}
