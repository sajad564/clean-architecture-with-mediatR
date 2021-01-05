using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class PasswordRecoveryCommand : IRequest<Response<bool>>
    {
        public string Userid {get;set;}
        public string NewPassword {get; set;}
        public string Token {get; set;}
    }
}