


using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common.Exceptions;
using FluentValidation;
using MediatR;

namespace book.Application.CQRS.Pipes
{
    public class ValidatorBehavior<TRequest, TResult> : IPipelineBehavior<TRequest, TResult>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;
        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;

        }


        
        public Task<TResult> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResult> next)
        {
            var context = new ValidationContext<TRequest>(request) ;
            var failure =  validators.Select(v => v.Validate(context)).SelectMany(result => result.Errors).Where(e => e!=null).ToList() ;
            if(failure.Any()) {
                
                
                
                throw new ValidationsException(failure) ; 
                
                // throw new ValidationException(failure) ; 
            }
            
                return next() ;  
            
        }
    }
}