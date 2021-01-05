using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace book.Application.CQRS.Handlers
{
    public class RemoveCommentCommanHandler : IRequestHandler<RemoveCommentCommand, Response<bool>>
    {
        private readonly ICommentRepository commentRepo;
        public RemoveCommentCommanHandler(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;

        }
        public async Task<Response<bool>> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await commentRepo.GetCommentAsync(request.CommentId);
            if(comment==null)
                return Response.Fail<bool>("کامنت مورد نظر یافت نشد" , StatusCodeEnum.NOTFUOUND) ;  
            if(comment.senderId==request.Userid)
            {
                await commentRepo.Remove(comment) ;
                return Response.Ok() ; 
            }
            var IsDelete = await RemoveCommenIfUserIsAdmin(request.Roles , comment) ; 
            if(IsDelete)
            {
                return Response.Ok();
            }
            return Response.Fail<bool>("شما مجاز به انجام این کار نیستید" ,StatusCodeEnum.NOTFUOUND) ; 
        }
        private async Task<bool> RemoveCommenIfUserIsAdmin(List<string> Roles , Comment comment)
        {
            var isAdmin =  Roles.Where(r => r=="admin").FirstOrDefault() ; 
            if(isAdmin!=null)
            {
               await commentRepo.Remove(comment);
                return  true ;
            }
            return false ;
        }
    }
}