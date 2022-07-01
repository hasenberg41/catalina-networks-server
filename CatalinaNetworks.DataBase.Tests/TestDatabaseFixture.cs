using AutoMapper;
using CatalinaNetworks.DataBase.Entities;

namespace CatalinaNetworks.DataBase.Tests
{
    public class TestDatabaseFixture : IDisposable
    {
        private const string ConnectionString = @"Server=DESKTOP-Q6U07MR;Database=CatalinaNetworksDbTests;Trusted_Connection=True";

        private static readonly object _lock = new();
        private static bool _databaseInitialized = false;

        public IMapper Mapper { get; set; } = null!;


        public static User[] Users
        {
            get
            {
                return new User[]
                {
                    new User()
                    {
                        Name = "Валера",
                        UniqueUrlName = "awdasdasa",
                        Photos = new Photos
                        {
                            Small = "test-small.jpg",
                            Large = "test-large.jpg"
                        }
                    }, 
                    new User()
                    {
                        Name = "Жорик",
                        UniqueUrlName = "wdwqqwewqe"
                    }, 
                    new User()
                    {
                        Name = "Саня",
                        UniqueUrlName = "sdawscxcx"
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
            Reset();
        }

        public void Reset()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    _databaseInitialized = true;
                    context.AddRange(Users);
                    context.SaveChanges();
                }
            }
        }

        public UsersDbContext CreateContext()
            => new(
                new DbContextOptionsBuilder<UsersDbContext>()
                .UseSqlServer(ConnectionString)
                .Options, Mapper);

        public void Dispose()
        {
            if (_databaseInitialized)
            {
                using var context = CreateContext();
                context.Database.EnsureDeleted();
            }
        }
    }
}