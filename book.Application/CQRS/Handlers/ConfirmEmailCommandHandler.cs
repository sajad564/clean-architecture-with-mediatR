using System.Threading;
using System.Threading.Tasks;
using System.Web;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace book.Application.CQRS.Handlers
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, Response<bool>>
    {
        private readonly UserManager<User> userManager;
        public ConfirmEmailCommandHandler(UserManager<User> userManager)
        {
            this.userManager = userManager;

        }
        public async Task<Response<bool>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await  userManager.FindByIdAsync(request.UserId) ; 
            if(user!=null && user.EmailConfirmed==false)
            {
                return await ConfirmEmailAsync(user , request.Token) ; 
            }
            return Response.Fail<bool>("کاربری با چنین مشخصاتی یافت نشد" , StatusCodeEnum.NOTAUTHORIZE ) ; 
        }
        private async Task<Response<bool>> ConfirmEmailAsync(User user , string token)
        {
            var decodeToken = HttpUtility.UrlDecode(token) ; 
            var result = await userManager.ConfirmEmailAsync(user , decodeToken) ;
            
            if(result.Succeeded)
                return Response.Ok() ;
            return Response.Fail<bool>("عملیات با شکست مواجه شد"  , StatusCodeEnum.BADREQUEST) ;  
        }
    }
}