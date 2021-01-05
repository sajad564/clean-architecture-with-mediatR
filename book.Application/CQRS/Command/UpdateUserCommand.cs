using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class UpdateUserCommand :BaseInformation  ,  IRequest<Response<bool>>
    {
        public string Username {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
    }
}