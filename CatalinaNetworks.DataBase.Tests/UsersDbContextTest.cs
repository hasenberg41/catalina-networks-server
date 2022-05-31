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
            var exceptedUsers = FixtureDb.Users.Select(u => FixtureDb.Mapper.Map<Core.Models.User>(u));

            var users = await context.Get();

            Assert.Equal(exceptedUsers, users);
            // TODO : разобраться
        }
    }
}
