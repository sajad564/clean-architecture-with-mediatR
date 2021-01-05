using book.Application.common;
using book.Domain.Entities;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class LoginUserCommand : IRequest<Response<Token>>
    {
        public string Username {get;set;}
        public string password {get;set;}
    }
}