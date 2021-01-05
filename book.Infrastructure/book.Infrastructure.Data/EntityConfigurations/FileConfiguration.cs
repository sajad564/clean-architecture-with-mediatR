using book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.Infrastructure.Data.EntityConfigurations
{
    public class FileConfiguration : IEntityTypeConfiguration<File>
    {
        public void Configure(EntityTypeBuilder<File> builder)
        {
            builder.Property(f => f.Url).IsRequired() ;
            builder.Property(f => f.Path).IsRequired() ;
        }
    }
}