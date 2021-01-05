using System.Threading;
using System.Threading.Tasks;
using System.Web;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace book.Application.CQRS.Handlers
{
    public class PasswordRecoveryCommandHandler : IRequestHandler<PasswordRecoveryCommand, Response<bool>>
    {
        private readonly UserManager<User> userManager;
        public PasswordRecoveryCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;

        }
        public async Task<Response<bool>> Handle(PasswordRecoveryCommand request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByIdAsync(request.Userid) ; 
            if(user!=null)
            {
                var result = await userManager.ResetPasswordAsync(user , HttpUtility.UrlDecode(request.Token) , request.NewPassword) ; 
                if(result.Succeeded)
                {
                    return Response.Ok() ; 
                }
            }
                return Response.Fail<bool>("لینک وارد شده معتبر نمیباشد" , StatusCodeEnum.BADREQUEST ) ; 
        }
    }
}