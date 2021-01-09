using System;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace book.Application.CQRS.Handlers
{
    public class RefreshCommandHandler : IRequestHandler<RefreshCommand, Response<Token>>
    {
        private readonly IUserRepository userRepo;
        private readonly ITokenGenerator tokenGenerator;
        public RefreshCommandHandler(IUserRepository userRepo, ITokenGenerator tokenGenerator)
        {
            this.tokenGenerator = tokenGenerator;
            this.userRepo = userRepo;

        }
        public async Task<Response<Token>> Handle(RefreshCommand request, CancellationToken cancellationToken)
        {
          return  Response.Ok<Token>(await GetTokensAsync(request)) ; 
        }
        private async Task<Token> GetTokensAsync(RefreshCommand context) // tokens : access and refresh token
        {
            var user = await GetUserFromExpiredTokenAsync(context.AccessToken) ; 
            if(user==null || user.RefreshToken!=context.RefreshToken ||  user.ExpiredRefreshTokenDate<=DateTime.UtcNow)
            {
                throw new SecurityException() ; 
            }
            var newAccessToken = await tokenGenerator.GenerateTokenAsync(user) ; 
            var newRefreshToken = tokenGenerator.RefreshTokenGeneretor() ; 
            //update user
            user.RefreshToken= newRefreshToken ; 
            await userRepo.UpdateAsync(user) ;
            return new Token {RefreshToken = newRefreshToken , Accesstoken = newAccessToken} ;  

        }
        private async Task<User> GetUserFromExpiredTokenAsync(string expiredToken)
        {
            var username = tokenGenerator.GetUsernameFromExpiredToken(expiredToken) ; 
            return  await userRepo.FindByExpression(u => u.UserName==username).FirstOrDefaultAsync() ;

        }
    }
}