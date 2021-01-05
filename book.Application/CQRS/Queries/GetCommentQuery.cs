using System;
using book.Application.common;
using book.Application.common.Resources;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class GetCommentQuery : BaseInformation ,  IRequest<Response<CommentResource>>
    {
        public string Id {get;set;}
        public GetCommentQuery(string id )
        {
            this.Id = id  ; 
        }
    }
}