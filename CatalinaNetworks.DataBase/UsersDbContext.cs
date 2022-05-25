using CatalinaNetworks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalinaNetworks.DataBase
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<Photos>().HasKey(p => p.UserId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photos> Photos { get; set; }
    }
}
