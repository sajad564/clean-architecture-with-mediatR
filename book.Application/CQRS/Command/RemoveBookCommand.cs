using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class RemoveBookCommand : BaseInformation , IRequest<Response<bool>>
    {
        public string BookId {get;set;}
        public RemoveBookCommand(string Id)
        {
            BookId = Id ; 
        }
    }
}