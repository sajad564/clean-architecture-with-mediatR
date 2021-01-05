
using book.Application.CQRS.Queries;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class ConfirmEmailQueryValidator : AbstractValidator<ConfirmEmailQuery>
    {
        public ConfirmEmailQueryValidator()
        {
            RuleFor(query  => query.Email).Must(email => !string.IsNullOrEmpty(email)).WithMessage("وارد نمودن ایمیل اجباری میباشد") ; 
            RuleFor(query => query.Email).EmailAddress().WithMessage("ایمیل وارد شده معتبر نمیباشد") ; 
        }
    }
}