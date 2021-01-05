using book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.Infrastructure.Data.EntityConfigurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Description).IsRequired() ;
            builder.Property(c => c.Id).IsRequired() ;
            builder.Property(c => c.CreatedDate).IsRequired() ; 
        }
    }
}