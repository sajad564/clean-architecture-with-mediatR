using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        private readonly IUserRepository userRepo;
        public UpdateUserCommandValidator(IUserRepository userRepo)
        {
            this.userRepo = userRepo;
            RuleFor(up => up.Userid).Must(id => id!=null ).WithMessage("آیدی کاربر الزامی میباشد");
            RuleFor(up => up.Firstname).Must(firstname =>  firstname?.Length>=6 ).WithMessage("نام شما باید حداقل شامل 6 کاراکتر باشد");
            RuleFor(up => up.Lastname).Must(lastname => lastname?.Length>=6).WithMessage("نام خانوادگی شما باید حداقل شامل 6 کاراکتر باشد");
            RuleFor(up => up.Username).Must(username =>  username?.Length>=6).WithMessage("نام کاربری شما باید حداقل شامل شش کاراکتر باشد");
            RuleFor(up => up.Username).SetValidator(new UsernameMustNotTaken(userRepo));
        }

    }
}