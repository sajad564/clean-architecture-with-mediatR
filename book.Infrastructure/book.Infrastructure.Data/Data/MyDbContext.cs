using book.Domain.Entities;
using book.Infrastructure.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Data
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books {get;set;}
        public DbSet<Order> Orders {get;set;} 
        public DbSet<File> Files {get;set;}
        public DbSet<Img> Imgs {get;set;}
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new BookConfiguration()) ; 
            builder.ApplyConfiguration(new CommentConfiguration()) ; 
            builder.ApplyConfiguration(new FileConfiguration()) ; 
            builder.ApplyConfiguration(new ImgConfiguration()) ; 
            builder.ApplyConfiguration(new UserConfiguration()) ;
            //seed Data
            builder.SeedData() ;  
             
        }
    }
}