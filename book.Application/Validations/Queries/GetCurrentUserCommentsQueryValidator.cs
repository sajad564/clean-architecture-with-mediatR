using book.Application.CQRS.Queries;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class GetCurrentUserCommentsQueryValidator : AbstractValidator<GetCurrentUserCommentsQuery>
    {
        public GetCurrentUserCommentsQueryValidator()
        {
            RuleFor(currentUser => currentUser.UserId).NotNull() ; 
        }
        
    }
}