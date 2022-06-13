namespace CatalinaNetworks.Core.Models.Paggination
{
    public class UsersPage : List<User>
    {
        public UsersPage(IEnumerable<User> users, int totalCount, string? error = null)
        {
            AddRange(users);
            Error = error;
            TotalCount = totalCount;
        }

        public int TotalCount { get; }

        public string? Error { get; }
    }
}
