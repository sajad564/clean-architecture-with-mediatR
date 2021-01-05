using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.HelperClasses;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetBookCommentsQueryHandler : IRequestHandler<GetBookCommentsQuery, Response<PagedList<CommentResource>>>
    {
        private readonly ICommentRepository commentRepo;
        private readonly PagedListConvertor pagedConvertor;
        public GetBookCommentsQueryHandler(ICommentRepository commentRepo, PagedListConvertor pagedConvertor)
        {
            this.pagedConvertor = pagedConvertor;
            this.commentRepo = commentRepo;

        }
        public async Task<Response<PagedList<CommentResource>>> Handle(GetBookCommentsQuery request, CancellationToken cancellationToken)
        {
            var pagedComment = await commentRepo.GetCommentPerPage(request as CommentPaginationParams);
            if (pagedComment.Any())
            {
                var pagedcommentResource = pagedConvertor.CommentPagedToResource(pagedComment) ;
                return Response.Ok<PagedList<CommentResource>>(pagedcommentResource);
            }
            return Response.Fail<PagedList<CommentResource>>("هیچ کامنتی یافت نشد", StatusCodeEnum.NOTFUOUND);
        }
    }
}