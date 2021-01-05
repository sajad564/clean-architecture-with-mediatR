using book.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace book.Infrastructure.Data.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id) ; 

            builder.HasMany(u => u.Orders)
            .WithOne(o => o.User)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.SetNull) ;  

            builder.HasMany(b => b.Comments)
            .WithOne(c => c.Sender)
            .HasForeignKey(c => c.senderId) ;

            builder.HasOne(u => u.Img)
            .WithOne(i => i.User)
            .HasForeignKey<Img>(i => i.UserId) ;   
        }
    }
}