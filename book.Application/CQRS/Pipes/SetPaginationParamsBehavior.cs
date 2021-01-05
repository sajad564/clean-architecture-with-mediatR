using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common.HeaderConvertors;
using book.Domain.Entities.pagination;
using book.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace book.Application.CQRS.Pipes
{
    public class SetPaginationParamsBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private HttpContext context {get;set;}
        public SetPaginationParamsBehavior(IHttpContextAccessor aceessor)
        {
            context = aceessor.HttpContext ; 
        }
        public  Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            request.Convert<TRequest>(context) ; 
            return next() ; 
        }
        
    }
}