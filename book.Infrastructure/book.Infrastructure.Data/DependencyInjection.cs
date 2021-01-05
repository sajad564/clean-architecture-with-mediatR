using System;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using book.Infrastructure.Common.services;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Repositories;
using book.Infrastructure.Data.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace book.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services , IConfiguration config) {
            services.AddTransient<IBookRepository , BookRepository>() ; 
            services.AddTransient<ICommentRepository , CommentRepository>() ;
            services.AddTransient<IOrderRepository,OrderRepository>() ; 
            services.AddTransient<IUserRepository , UserRepository>() ;
            services.AddTransient<IFileRepository , FileRepository>() ;
            services.AddTransient<IPhotoRepository , PhotoRepository>() ;
            services.AddTransient<IFileManager ,FileManager>()  ; 

            services.AddIdentity<User,IdentityRole>(options => {
                options.Password.RequireDigit = false ;
                options.Password.RequiredLength = 5 ;
                options.Password.RequireDigit =false ; 
                options.Password.RequireLowercase = false ;
                options.Password.RequireUppercase  =false ;
                options.Password.RequireNonAlphanumeric = false ; 
                options.Tokens.PasswordResetTokenProvider = "PasswordRecoveryProvider" ; 
            })
            .AddEntityFrameworkStores<MyDbContext>() 
            .AddDefaultTokenProviders()
            .AddTokenProvider<PasswordRecoveryTokenProvider<User>>("PasswordRecoveryProvider");
            services.Configure<PasswordRecoveryTokenProviderOptions>(options => {
                options.TokenLifespan = TimeSpan.FromMinutes(30) ; 
            }) ; 
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer(config.GetConnectionString("bookDb"))) ; 
            return services ; 
        }
    }
}