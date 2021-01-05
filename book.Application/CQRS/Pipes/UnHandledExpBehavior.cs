using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace book.Application.CQRS.Pipes
{
    
    public class UnHandledExpBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> logger;
        public UnHandledExpBehavior(ILogger<TRequest> logger)
        {
            this.logger = logger ;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch(Exception exp)
            {
                var requestName = typeof(TRequest).Name ; 
                logger.LogError(exp ,"Unhandled Exception for Request {requestname} , {request}" , requestName , request  ) ; 
                throw ; 
            }
        }
    }
}