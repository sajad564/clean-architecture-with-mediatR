using book.Domain.Interfaces.services;
using book.Infrastructure.Common.Common;
using book.Infrastructure.Common.services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace book.Infrastructure.Common
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureCommon(this IServiceCollection services , IConfiguration config) {
            services.AddTransient<IFileManager,FileManager>() ; 
            services.AddTransient<ITokenGenerator,TokenGenerator>() ;
            services.AddTransient<IEmailSender, EmailSender>() ; 
            var emailConfirm = config.GetSection("ConfirmAndRecovery").Get<ConfirmAndRecovery>();
            services.AddSingleton(emailConfirm) ; 
            var emailConfig = config.GetSection("EmailConfiguration").Get<EmailConfiguration>() ; 
            services.AddSingleton(emailConfig) ;  
            return services ;  
        }
    }
}