using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Data
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole {Name = "admin" , Id = Guid.NewGuid().ToString()} ,
                    new IdentityRole {Name = "author" , Id = Guid.NewGuid().ToString()} 
                );
            return builder ; 
        }
    }
}