namespace CatalinaNetworks.DataBase.Tests
{
    public class UsersDbContextTest : IClassFixture<TestDatabaseFixture>
    {
        public TestDatabaseFixture FixtureDb { get; private set; }

        public UsersDbContextTest(TestDatabaseFixture fixtureDb) => FixtureDb = fixtureDb;

        [Fact]
        public void GetUsers_ShouldReturnUsersList()
        {
            using var context = FixtureDb.CreateContext();

        }
    }
}
