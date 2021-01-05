using System.Threading;
using book.Application.common;
using MediatR;
using System.Threading.Tasks;
using book.Application.CQRS.Command;
using book.Domain.Interfaces.Repositories;

namespace book.Application.CQRS.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<bool>>
    {
        private readonly IUserRepository userRepo;
        public UpdateUserCommandHandler(IUserRepository userRepo)
        {
            this.userRepo = userRepo;

        }
        public async Task<Response<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetUserByIdAsync(request.Userid) ;
            if(user!=null) {
                user.UserName = request.Username?? request.Username ; 
                user.FirstName = request.Firstname?? request.Firstname ;
                user.FirstName = request.Lastname?? request.Lastname ; 
                await userRepo.UpdateAsync(user) ; 
                return Response.Ok(); 
            } 
            else {
                return Response.Fail<bool>("چنین کاربری یافت نشد" , StatusCodeEnum.NOTFUOUND  , false) ; 
            }
        }
    }
}