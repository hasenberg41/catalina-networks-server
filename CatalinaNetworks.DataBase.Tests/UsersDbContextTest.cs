using CatalinaNetworks.DataBase.Entities;

namespace CatalinaNetworks.DataBase.Tests
{
    public class UsersDbContextTest : IClassFixture<TestDatabaseFixture>
    {
        public TestDatabaseFixture FixtureDb { get; private set; }

        public UsersDbContextTest(TestDatabaseFixture fixtureDb) => FixtureDb = fixtureDb;

        [Fact]
        public async Task GetUsers_ShouldReturnUsersList()
        {
            using var context = FixtureDb.CreateContext();
            var exceptedUsers = FixtureDb.Users.Select(u => FixtureDb.Mapper.Map<Core.Models.User>(u)).ToList();

            var users = (await context.Get()).ToList();

            for (int i = 0; i < users.Count; i++)
            {
                Assert.Equal(users[i].Name, exceptedUsers[i].Name);
                Assert.Equal(users[i].UniqueUrlName, exceptedUsers[i].UniqueUrlName);
                Assert.Equal(users[i].Photos?.Small, exceptedUsers[i].Photos?.Small);
                Assert.Equal(users[i].Photos?.Large, exceptedUsers[i].Photos?.Large);
            }
            // TODO : разобраться
        }
    }
}
