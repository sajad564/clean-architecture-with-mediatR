using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, Response<Token>>
    {
        private readonly IUserRepository userRepo;
        private readonly ITokenGenerator tokenGenerator;
        public LoginUserCommandHandler(IUserRepository userRepo, ITokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
            this.userRepo = userRepo;

        }

        public async Task<Response<Token>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await userRepo.GetUserByUsernameAsync(request.Username);
            var isPasswordCorrect = await userRepo.CheckUserPassword(userExist, request.password);
            if(isPasswordCorrect) {
                if(!userExist.EmailConfirmed)
                {
                    return Response.Fail<Token>("شما هنوز حساب خود را فعال نکرده اید" , StatusCodeEnum.NOTAUTHORIZE) ; 
                }
                Token token = await tokenGenerator.GenerateTokenAsync(userExist) ;
                return Response.Ok<Token>(token) ;  
            }
            else {
                return Response.Fail<Token>("لطفا اطلاعات حساب خود را بررسی کنید " , StatusCodeEnum.BADREQUEST) ; 
            }
        }
        
    }
}