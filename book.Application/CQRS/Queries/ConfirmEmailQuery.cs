using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class ConfirmEmailQuery : IRequest<Response<bool>>
    {
        public string Email {get;set;}
        public ConfirmEmailQuery(string email)
        {
            Email = email ;
        }
    }
}