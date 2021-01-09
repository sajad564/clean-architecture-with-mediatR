using book.Application.common;
using book.Domain.Entities;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class RefreshCommand : IRequest<Response<Token>>
    {
        public string AccessToken {get;set;}
        public string RefreshToken {get;set;}
    }
}