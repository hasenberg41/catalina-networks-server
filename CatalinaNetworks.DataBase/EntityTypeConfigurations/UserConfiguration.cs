using CatalinaNetworks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalinaNetworks.DataBase.EntityTypeConfigurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id).IsClustered();
            builder.Property(u => u.Name).HasMaxLength(100).IsRequired();
            builder.Property(u => u.UniqueUrlName).HasMaxLength(300).IsRequired(false);
            builder.HasOne(u => u.Photos).WithOne(s => s.User).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
