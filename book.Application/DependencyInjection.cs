using System.Reflection;
using AutoMapper;
using book.Application.common.HelperClasses;
using book.Application.CQRS.Pipes;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace book.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) {
            services.AddTransient(typeof(IPipelineBehavior< , >) , typeof(CurrentUserIdBehavior< , >)) ; 
            // below behavior was fro getting pagination data from header
            // services.AddTransient(typeof(IPipelineBehavior< , >) , typeof(SetPaginationParamsBehavior< , >)) ; 
            services.AddTransient(typeof(IPipelineBehavior< , >) , typeof(ValidatorBehavior< , >)) ;
            services.AddTransient(typeof(IPipelineBehavior< ,>) , typeof(UnHandledExpBehavior< , >)) ;
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly()) ;
            services.AddHttpContextAccessor() ;
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())  ; 
            services.AddSingleton<PagedListConvertor>() ; 
            return services  ; 
        }
       
    }
}