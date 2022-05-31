namespace CatalinaNetworks.DataBase.Entities
{
    public class Photos
    {
        public int UserId { get; set; }

        public string Large { get; set; } = null!;

        public string Small { get; set; } = null!;

        public User User { get; set; } = null!;
    }
}
