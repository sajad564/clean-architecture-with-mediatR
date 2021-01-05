using System.Threading;
using System.Threading.Tasks;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class UsernameMustNotTaken : AsyncValidatorBase
    {
        private readonly IUserRepository userRepo;
        public UsernameMustNotTaken(IUserRepository userRepo)
        {
            this.userRepo = userRepo;

        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            var username = context.PropertyValue as string ;
            if(username!=null) {
                await UniqueUsernameAsync(username) ; 
            }
            return true ; 
        }
        private async Task<bool> UniqueUsernameAsync(string Username)
        {
            var userExist  = await userRepo.GetUserByUsernameAsync(Username) ; 
            return userExist==null ; 
        }
    }
}