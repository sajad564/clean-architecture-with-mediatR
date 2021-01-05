using System;
using book.Application.common;

using book.Application.common.Resources;
using book.Domain.Entities;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class GetBookWithIdQuery :  IRequest<Response<BookResource>>
    {
        public string BookId {get;set;}
        public GetBookWithIdQuery(string Id)
        {
            this.BookId = Id  ; 
        }
    }
}