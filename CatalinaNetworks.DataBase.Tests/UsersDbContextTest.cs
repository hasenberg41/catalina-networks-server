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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetUser_ShouldReturnUserById(int id)
        {
            using var context = FixtureDb.CreateContext();
            var exceptedUser = FixtureDb.Mapper.Map<Core.Models.User>(TestDatabaseFixture.Users[id - 1]);

            var user = await context.Get(id);
            AssertExtentions.EqualUsers(exceptedUser, user);
            Assert.Equal(id, user.Id);
        }
    }
}
