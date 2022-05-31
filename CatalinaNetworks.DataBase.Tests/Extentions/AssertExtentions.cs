namespace CatalinaNetworks.DataBase.Tests.Extentions
{
    internal static class AssertExtentions // т.к. класс Assert - статический, полноценный метод расширения построить невозможно
    {
        public static void EqualUsers(IEnumerable<Core.Models.User> exceptedUsers, IEnumerable<Core.Models.User> users)
        {
            var users1 = users.ToList();
            var users2 = exceptedUsers.ToList();
            for (int i = 0; i < users1.Count; i++)
            {
                Assert.Equal(users1[i].Name, users2[i].Name);
                Assert.Equal(users1[i].UniqueUrlName, users2[i].UniqueUrlName);
                Assert.Equal(users1[i].Photos?.Small, users2[i].Photos?.Small);
                Assert.Equal(users1[i].Photos?.Large, users2[i].Photos?.Large);
            }
        }
    }
}
