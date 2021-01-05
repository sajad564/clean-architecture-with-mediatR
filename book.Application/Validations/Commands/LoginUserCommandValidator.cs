using book.Application.CQRS.Command;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u =>u.Username ).Cascade(CascadeMode.Stop).NotNull().WithMessage("لطفا نام کاربری خود را وارد کنید").NotEmpty().WithMessage("لطفا نام کاربری خود را وارد کنید") ; 
            RuleFor(u => u.password).Cascade(CascadeMode.Stop).NotNull().WithMessage("لطفا رمز عبور خود را وارد کنید").NotEmpty().WithMessage("لطفا رمز عبور خود را وارد کنید")  ; 
        }
    }
}