using System;
using book.Application.common;
using book.Domain.Common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class AddCommentCommand : BaseInformation , IRequest<Response<bool>>
    {
        public string Description {get;set;}
        public string bookId {get;set;}
        
    }
}