using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class AddCommentCommandValidator : AbstractValidator<AddCommentCommand>
    {
        
        public AddCommentCommandValidator(IBookRepository bookRepo)
        {
            
            RuleFor(addcomm => addcomm.bookId).SetValidator(new BookShouldExistPropertyValidator(bookRepo)).WithMessage("در خواست غیر معتبر");
            RuleFor(addcomm => addcomm.Description).NotEmpty().WithMessage("طول کامنت شما از حد مجاز کوتاه تر است").NotNull().WithMessage("طول کامنت شما از حد مجاز کوتاه تر است");
            
        }
    }
}