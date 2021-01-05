using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.AutoMapper;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, Response<CommentResource>>
    {
        private readonly ICommentRepository commentRepo;
        public GetCommentQueryHandler(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;

        }
        public async Task<Response<CommentResource>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
           var comment =   await commentRepo.GetCommentAsync(request.Id) ;
           var commentResource =  Mapping.Mapper.Map<CommentResource>(comment) ;
             
            return Response.Ok<CommentResource>(commentResource) ; 
        }
        
    }
}