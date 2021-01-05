using book.Application.common;
using MediatR;

namespace book.Application.CQRS.Command
{
    public class RemoveCommentCommand : BaseInformation , IRequest<Response<bool>>
    {
        public string CommentId {get;set;}
        public RemoveCommentCommand(string commentId)
        {
            CommentId = commentId ; 
        }
    }
}