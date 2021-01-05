using book.Application.CQRS.Queries;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class PasswordRecoveryQueryValidator : AbstractValidator<PasswordRecoveryQuery>
    {
        public PasswordRecoveryQueryValidator()
        {
            RuleFor(passrec => passrec.Email).Must(email => !string.IsNullOrEmpty(email)).WithMessage("لطفا ایمیل خود را وارد کنید") ;
            RuleFor(passrec => passrec.Email).EmailAddress().WithMessage("ایمیل وارد شده معتبر نمیباشد") ; 
        }
    }
}