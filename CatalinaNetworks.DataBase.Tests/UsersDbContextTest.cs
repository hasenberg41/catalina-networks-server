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

            FixtureDb.Reset();
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
        [InlineData(-215)]
        [InlineData(0)]
        public async Task GetUser_ShouldThrowNotFoundException(int id)
        {
            using var context = FixtureDb.CreateContext();

            await Assert.ThrowsAsync<NotFoundException>(async () => await context.Get(id));
        }

        [Fact]
        public async Task CreateUser_ShouldReturnUserId()
        {
            using var context = FixtureDb.CreateContext();
            var newUser = fixture.Create<Core.Models.User>();

            var returnId = await context.Create(newUser);
            var resultId = (await context.Get(returnId)).Id;

            Assert.Equal(returnId, resultId);
        }

        [Fact]
        public async Task UpdateUser_ShouldSuccessUpdatedUser()
        {
            var newUser = fixture.Create<Core.Models.User>();
            var updatedUser = fixture.Create<Core.Models.User>();
            Core.Models.User? returnedUser = null;

            using (var context = FixtureDb.CreateContext())
            {
                updatedUser.Id = await context.Create(newUser);
            }

            using (var context = FixtureDb.CreateContext())
            {
                await context.Update(updatedUser);
            }

            using (var context = FixtureDb.CreateContext())
            {
                returnedUser = await context.Get(updatedUser.Id);
            }

            AssertExtentions.EqualUsers(updatedUser, returnedUser);
        }

        [Fact]
        public async Task DeleteUser_CheckUsers_ShouldThrowNotFoundException()
        {
            var newUser = fixture.Create<Core.Models.User>();
            int returnId = default;

            using (var context = FixtureDb.CreateContext())
            {
                returnId = await context.Create(newUser);
            }
            newUser.Id = returnId;

            using (var context = FixtureDb.CreateContext())
            {
                await context.Delete(newUser);
            }

            using (var context = FixtureDb.CreateContext())
            {
                await Assert.ThrowsAsync<NotFoundException>(async () => await context.Get(returnId));
            }
        }

        [Fact]
        public async Task DeleteUser_CheckPhotos_ShouldNotFoundPhotosDto()
        {
            var newUser = fixture.Create<Core.Models.User>();
            int returnId = default;

            using (var context = FixtureDb.CreateContext())
            {
                returnId = await context.Create(newUser);
            }
            newUser.Id = returnId;

            using (var context = FixtureDb.CreateContext())
            {
                await context.Delete(newUser);

                var photosEntity = context.Photos.FirstOrDefault(p => p.UserId == returnId);
                Assert.Null(photosEntity);
            }
        }
    }
}
