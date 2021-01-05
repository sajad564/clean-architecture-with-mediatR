using book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.Infrastructure.Data.EntityConfigurations
{
    public class ImgConfiguration : IEntityTypeConfiguration<Img>
    {
        public void Configure(EntityTypeBuilder<Img> builder)
        {
            builder.Property(img => img.Url).IsRequired() ;
            builder.Property(img => img.Path).IsRequired() ;
            builder.ToTable("Photos") ; 
        }
    }
}