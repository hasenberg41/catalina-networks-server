using CatalinaNetworks.Core.Models.Paggination;

namespace CatalinaNetworks.API.Models
{
    internal class UsersPageContract
    {
        public UsersPageContract(UsersPage users)
        {
            Users = users;
            TotalCount = users.TotalCount;
            Error = users.Error;
        }

        public List<Core.Models.User> Users { get; set; }

        public int TotalCount { get; set; }

        public string? Error { get; set; }
    }
}
