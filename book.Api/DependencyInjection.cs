using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens ;

namespace book.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services ,IConfiguration config) {
            // enable cors if u want access pagination informations
            //because pagination information come from header
            services.AddCors(options => {
                options.AddPolicy(name : "mycorsPolicy" , builder => {
                    builder.WithOrigins("http://localhost:8080")
                    .AllowAnyMethod() ; 
                });
            });
            services.ConfigureApplicationCookie(options => {
                    options.Events.OnRedirectToLogin = context => {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                }) ; 
            services.AddAuthentication(options => { 
                options.DefaultAuthenticateScheme = "sajad" ;
            })
                .AddJwtBearer("sajad", options =>{
                    options.RequireHttpsMetadata = false ;
                    options.TokenValidationParameters = new TokenValidationParameters
                            {
                                ValidateIssuer = true  ,
                                ValidateAudience = false  , 
                                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("AuthenticationConf:Key").Value)) ,
                                ValidIssuer = config.GetSection("AuthenticationConf:Issuer").Value , 
                            } ; 
                }) ; 
                
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1" , new Microsoft.OpenApi.Models.OpenApiInfo{ Version = "v1" , Title = "end points consuming" }) ; 
            }) ;
            services.Configure<FormOptions>(options =>
                {
                    options.ValueCountLimit = 10; //default 1024
                    options.ValueLengthLimit = int.MaxValue; //not recommended value
                    options.MultipartBodyLengthLimit = long.MaxValue; //not recommended value
                });
            return services ;  
        }
    }
}