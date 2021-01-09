using book.Application.CQRS.Command;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u =>u.Username ).Must(username =>!string.IsNullOrEmpty(username)).WithMessage("لطفا نام کاربری خود را وارد کنید") ;  
            RuleFor(u => u.password).Must(password => !string.IsNullOrEmpty(password)).WithMessage("لطفا رمز عبور خود را وارد کنید"); 
        }
    }
}