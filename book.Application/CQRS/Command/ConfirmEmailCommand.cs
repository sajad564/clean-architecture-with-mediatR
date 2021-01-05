using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class ConfirmEmailCommand : IRequest<Response<bool>>
    {
        public string Token {get;set;}
        public string UserId {get;set;}
    }
}