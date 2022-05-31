using AutoMapper;

namespace CatalinaNetworks.DataBase.Tests
{
    public class TestDatabaseFixture
    {
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=CatalinaNetworksDbTests;Trusted_Connection=True";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public IMapper Mapper { get; set; } = null!;


        public List<Entities.User> Users
        {
            get
            {
                return new List<Entities.User>
                {
                    new Entities.User()
                    {
                        Name = "Валера",
                        UniqueUrlName = "awdasdasa",
                    }, 
                    new Entities.User()
                    {
                        Name = "Жорик",
                        UniqueUrlName = "wdwqqwewqe",
                    }, 
                    new Entities.User()
                    {
                        Name = "Саня",
                        UniqueUrlName = "sdawscxcx",
                    }
                };
            }
        }


        public TestDatabaseFixture()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DBUserMappingProfile>();
            });

            Mapper = new Mapper(mapperConfig);

            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    _databaseInitialized = true;

                    context.Users.AddRange(Users);
                    context.SaveChanges();
                }
            }
        }

        public UsersDbContext CreateContext()
            => new(
                new DbContextOptionsBuilder<UsersDbContext>()
                .UseSqlServer(ConnectionString)
                .Options, Mapper);
    }
}