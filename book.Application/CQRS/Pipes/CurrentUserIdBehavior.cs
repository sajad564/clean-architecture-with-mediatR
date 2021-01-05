using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace book.Application.CQRS.Pipes
{
    public class CurrentUserIdBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        HttpContext context {get;set;}
        public CurrentUserIdBehavior(IHttpContextAccessor accessor)
        {
            this.context  = accessor.HttpContext ; 
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(request is BaseInformation baseInfo) {
                 baseInfo.Userid =  context.User.FindFirst(ClaimTypes.NameIdentifier).Value ;
                 baseInfo.Roles = context.User.FindAll(ClaimsIdentity.DefaultRoleClaimType).Select(roleClaim => roleClaim.Value).ToList() ;  
            }
            if(request is GetCurrentUserCommentsQuery currentUserC) {
                currentUserC.UserId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value ; 
            }
            if(request is GetCurrentUserOrdersQuery currentUserO) {
                currentUserO.UserId = context.User.FindFirst(ClaimTypes.NameIdentifier).Value ; 
            }
            return await next() ; 
        }
    }
}