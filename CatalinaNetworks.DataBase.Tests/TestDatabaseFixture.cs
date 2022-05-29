namespace CatalinaNetworks.DataBase.Tests
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=CatalinaNetworksDbTests;Trusted_Connection=True";
        
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public TestDatabaseFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.Users.AddRange(new Entities.User()
                        {
                            Name = "Валера",
                            UniqueUrlName = Guid.NewGuid().ToString(),
                            Photos = new Entities.Photos()
                            {
                                Small = Guid.NewGuid().ToString(),
                                Large = Guid.NewGuid().ToString()
                            }
                        }, new Entities.User()
                        {
                            Name = "Жорик",
                            UniqueUrlName = Guid.NewGuid().ToString(),
                            Photos = new Entities.Photos()
                            {
                                Small = Guid.NewGuid().ToString(),
                                Large = Guid.NewGuid().ToString()
                            }
                        }, new Entities.User()
                        {
                            Name = "Саня",
                            UniqueUrlName = Guid.NewGuid().ToString(),
                            Photos = new Entities.Photos()
                            {
                                Small = Guid.NewGuid().ToString(),
                                Large = Guid.NewGuid().ToString()
                            }
                        });
                    }
                }
            }
        }

        public UsersDbContext CreateContext() 
            => new UsersDbContext(
                new DbContextOptionsBuilder<UsersDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);
    }
}