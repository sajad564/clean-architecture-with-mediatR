using System.Threading;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class UserNameIsValidPropertyValidator : AsyncValidatorBase
    {
        private readonly IUserRepository userRepo;
        public UserNameIsValidPropertyValidator(IUserRepository userRepo) : base("یک کاربر با این نام کاربری قبلا ثبت نام کرده است") 
        {
            this.userRepo = userRepo;

        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            return await userRepo.GetUserByUsernameAsync(context.PropertyValue as string)==null ; 
        }
    }
}