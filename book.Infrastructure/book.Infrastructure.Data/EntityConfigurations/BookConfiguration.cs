using book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.Infrastructure.Data.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id) ; 

            builder.HasMany(b => b.Orders)
            .WithOne(o => o.Product)
            .HasForeignKey(o => o.ProductId) ;

            builder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId) ; 

            builder.HasMany(b => b.Comments)
            .WithOne(c => c.Book)
            .HasForeignKey(c => c.BookId) ;

            builder.HasMany(b => b.Imgs)
            .WithOne(i => i.Book)
            .HasForeignKey(i => i.BookId) ;

            builder.HasOne(b => b.File)
            .WithOne(f => f.Book)
            .HasForeignKey<File>(f => f.BookId)
            .OnDelete(DeleteBehavior.Cascade) ;  
        }
    }
}