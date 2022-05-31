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
            var exceptedUsers = TestDatabaseFixture.Users.Select(u => FixtureDb.Mapper.Map<Core.Models.User>(u));

            var users = await context.Get();
            AssertExtentions.EqualUsers(exceptedUsers, users);
        }

        [Fact]
        public async Task GetUser_ShouldReturnUserById()
        {
            using var context = FixtureDb.CreateContext();
            var exceptedUser = FixtureDb.Mapper.Map<Core.Models.User>(TestDatabaseFixture.Users[0]);

            var user = await context.Get(1);
            AssertExtentions.EqualUsers(exceptedUser, user);
            Assert.Equal(1, user.Id);
        }
    }
}
