using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class PasswordRecoveryCommandValidator : AbstractValidator<PasswordRecoveryCommand>
    {
        public PasswordRecoveryCommandValidator()
        {
            RuleFor(command => command.Userid).Must(userid => !string.IsNullOrEmpty(userid)).WithMessage("لینک وارد شده معتبر نمیباشد") ; 
            RuleFor(common =>common.Token).Must(token => !string.IsNullOrEmpty(token)).WithMessage("لینک وارد شده معتبری نمیباشد") ; 
            RuleFor(common => common.NewPassword).Must(password => !string.IsNullOrEmpty(password)).WithMessage("وارد کردن پسوورد اجباری میباشد").SetValidator(new PasswordPropertyValidator()) ; 
        }
    }
}