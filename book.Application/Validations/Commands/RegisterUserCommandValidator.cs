using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository userRepo;
        public RegisterUserCommandValidator(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
            RuleFor(register => register.Firstname).Must(fname => fname!=null && fname.Length>=5).WithMessage("لطفا نام خود را وارد نمایید");
            RuleFor(register => register.Username).Must(uname => uname!=null && uname.Length>=5).WithMessage("طول نام کاربری شما باید بیشتر از 6 کارکاتر داشته باشد");
            RuleFor(register => register.Username).SetValidator(new UserNameIsValidPropertyValidator(userRepo)) ; 
            RuleFor(register => register.Lastname).Must(lname => lname!=null && lname.Length>=5).WithMessage("لطفا نام خانوادگی خود را وارد نمایید");
            RuleFor(register => register.Email).EmailAddress().WithMessage("لطفا یک ایمیل معتبر وارد نمایید");
            RuleFor(register => register.Email).SetValidator(new EmailIsValidProperyValidator(userRepo)) ; 
            RuleFor(register => register.Password).Must(password => password!=null && password.Length>=6).WithMessage("طول پسوورد شما کمتر از حد مجاز است (حداقل 10 کاراکتر مجاز میباشد)");
            RuleFor(register => register.Password).SetValidator(new PasswordPropertyValidator());
            RuleFor(register => register.ConfirmPassword).Equal(register => register.Password).WithMessage("عدم تطابق رمز عبور");
            RuleFor(register => register.Photo).SetValidator(new UserPhotoPropertyValidator()).WithMessage("لطفا یک عکس معتبر انتخاب کنید");
        }
    }
}