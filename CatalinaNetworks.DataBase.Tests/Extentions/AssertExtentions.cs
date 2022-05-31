using CatalinaNetworks.Core.Models;

namespace CatalinaNetworks.DataBase.Tests.Extentions
{
    internal static class AssertExtentions // т.к. класс Assert - статический, полноценный метод расширения построить невозможно
    {
        public static void EqualUsers(IEnumerable<User> exceptedUsers, IEnumerable<User> users)
        {
            var users1 = users.ToList();
            var users2 = exceptedUsers.ToList();
            for (int i = 0; i < users2.Count; i++)
            {
                EqualUsers(users1[i], users2[i]);
            }
        }

        public static void EqualUsers(User users1, User users2)
        {
            Assert.Equal(users1.Name, users2.Name);
            Assert.Equal(users1.UniqueUrlName, users2.UniqueUrlName);
            Assert.Equal(users1.Photos?.Small, users2.Photos?.Small);
            Assert.Equal(users1.Photos?.Large, users2.Photos?.Large);
        }
    }
}
