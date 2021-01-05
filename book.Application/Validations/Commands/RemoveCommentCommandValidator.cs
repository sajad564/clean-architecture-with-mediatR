using book.Application.CQRS.Command;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class RemoveCommentCommandValidator : AbstractValidator<RemoveCommentCommand>
    {
        public RemoveCommentCommandValidator()
        {
            RuleFor(rc => rc.CommentId).Must(commentId => !string.IsNullOrEmpty(commentId)).WithMessage("لطفا کامنت مد نظر خود را انتخاب کنید");
        }
    }
}