using book.Application.common;
using book.Application.common.Resources;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class GetCommentsQuery :CommentPaginationParams ,  IRequest<Response<PagedList<CommentResource>>>
    {
        
    }
}