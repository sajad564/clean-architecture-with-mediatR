using book.Application.CQRS.Queries;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class GetCurrentUserOrdersQueryValidator : AbstractValidator<GetCurrentUserOrdersQuery>
    {
        public GetCurrentUserOrdersQueryValidator()
        {
            RuleFor(currentUser => currentUser.UserId).Must(userid => !string.IsNullOrEmpty(userid)).WithMessage("این در خواست ممکن نیست") ;
        }
    }
}