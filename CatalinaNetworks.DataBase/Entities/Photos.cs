namespace CatalinaNetworks.DataBase.Entities
{
    public class Photos
    {
        public int UserId { get; set; }

        public string Large { get; set; } = "";

        public string Small { get; set; } = "";

        public User User { get; set; } = null!;
    }
}
