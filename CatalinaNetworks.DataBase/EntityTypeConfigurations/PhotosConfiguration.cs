using CatalinaNetworks.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalinaNetworks.DataBase.EntityTypeConfigurations
{
    internal class PhotosConfiguration : IEntityTypeConfiguration<Photos>
    {
        public void Configure(EntityTypeBuilder<Photos> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Large).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Small).HasMaxLength(50).IsRequired();
            builder.HasOne(p => p.User).WithOne(u => u.Photos).HasForeignKey<Photos>(p => p.UserId);
        }
    }
}
