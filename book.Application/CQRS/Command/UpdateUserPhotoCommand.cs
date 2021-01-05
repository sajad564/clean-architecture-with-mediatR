using book.Application.common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace book.Application.CQRS.Command
{
    public class UpdateUserPhotoCommand :BaseInformation ,  IRequest<Response<bool>>
    {
        public IFormFile Photo {get;set;}
    }
}