using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class RemoveBookPhotoCommandValidator : AbstractValidator<RemoveBookPhotoCommand>
    {
        public RemoveBookPhotoCommandValidator(IPhotoRepository photoRepo)
        {
            RuleFor(rbp => rbp.BookId).Must(userid =>!string.IsNullOrEmpty(userid)).WithMessage(" کتاب مورد نظر یافت نشد") ; 
            RuleFor(rbp => rbp.PhotoId).Must(photoid => !string.IsNullOrEmpty(photoid)).WithMessage("تصویر مورد نظر یافت نشد") ; 
            RuleFor(rbp => rbp).SetValidator(new PhotoBelongToBookPropertyValidator(photoRepo)) ; 
        }
    }
}