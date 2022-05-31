using CatalinaNetworks.Core.Exceptions;
using CatalinaNetworks.DataBase.Entities;

namespace CatalinaNetworks.DataBase.Tests
{
    public class UsersDbContextTest : IClassFixture<TestDatabaseFixture>
    {
        private readonly Fixture fixture = new();
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

        [Theory]
        [InlineData(23)]
        [InlineData(34)]
        [InlineData(215)]
        public async Task GetUser_ShouldThrowNotFoundException(int id)
        {
            using var context = FixtureDb.CreateContext();

            await Assert.ThrowsAsync<NotFoundException>(async () => await context.Get(id));
        }

        [Fact]
        public async Task CreateUser_ShouldReturnUserId()
        {
            using var context = FixtureDb.CreateContext();
            var exceptedId = TestDatabaseFixture.Users.Length + 1;
            var newUser = fixture.Create<Core.Models.User>();

            var returnId = await context.Create(newUser);
            var resultId = (await context.Get(returnId)).Id;

            Assert.Equal(returnId, resultId);
            Assert.Equal(exceptedId, resultId);
            Assert.Equal(exceptedId, returnId);
        }
    }
}
