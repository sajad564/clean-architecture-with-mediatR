using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class PasswordRecoveryQuery : IRequest<Response<bool>>
    {
        public string Email {get;set;}
        public PasswordRecoveryQuery(string email)
        {
            Email = email ; 
        }
    }
}