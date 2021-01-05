using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class RemoveBookPhotoCommand : BaseInformation , IRequest<Response<bool>>
    {
        public string BookId {get;set;}
        public string PhotoId {get;set;}
    }
}