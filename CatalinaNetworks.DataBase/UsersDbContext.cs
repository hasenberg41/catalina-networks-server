using CatalinaNetworks.Core.Repositories;
using CatalinaNetworks.DataBase.Entities;
using CatalinaNetworks.DataBase.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CatalinaNetworks.DataBase
{
    public class UsersDbContext : DbContext, IRepository<User>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Photos> Photos { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PhotosConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public Task<List<User>> Get()
        {
            return Users.AsNoTracking().ToListAsync();
        }

        public Task<User> Get(int id)
        {
            return Users.AsNoTracking().FirstAsync(u => u.Id == id);
        }

        public Task<int> Create(User item)
        {
            throw new NotImplementedException();
        }

        public Task Update(User item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(User item)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await SaveChangesAsync();
        }
    }
}
