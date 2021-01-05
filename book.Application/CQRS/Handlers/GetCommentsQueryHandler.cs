using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities.pagination;
using book.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using book.Application.common.HelperClasses;

namespace book.Application.CQRS.Handlers
{
    public class GetCommentsQueryHandler : IRequestHandler<GetCommentsQuery, Response<PagedList<CommentResource>>>
    {
        private readonly ICommentRepository commentRepo;
        private readonly PagedListConvertor pagedConvertor;
        public GetCommentsQueryHandler(ICommentRepository commentRepo, PagedListConvertor pagedConvertor)
        {
            this.pagedConvertor = pagedConvertor;
            this.commentRepo = commentRepo;

        }
        public async Task<Response<PagedList<CommentResource>>> Handle(GetCommentsQuery request, CancellationToken cancellationToken)
        {
            var pagedComment = await commentRepo.GetCommentPerPage(request);
            if (pagedComment.Any())
            {
                var pagedResource = pagedConvertor.CommentPagedToResource(pagedComment) ; 
                return Response.Ok<PagedList<CommentResource>>(pagedResource) ; 
            }
            else 
            {
                return Response.Fail<PagedList<CommentResource>>("هیچ کامنتی یافت نشد" , StatusCodeEnum.NOTFUOUND ) ; 
            }
        }
    }
}