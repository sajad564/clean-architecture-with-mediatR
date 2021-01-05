using System.Threading;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class EmailIsValidProperyValidator : AsyncValidatorBase
    {
        private readonly IUserRepository userRepo;
        public EmailIsValidProperyValidator(IUserRepository userRepo) : base("یک حساب کاربری با این ایمیل ثبت شده است")
        {
            this.userRepo = userRepo;

        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            return await userRepo.GetUserByEmailAsync(context.PropertyValue as string)==null ; 
        }
    }
}