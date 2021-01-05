using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class UpdateUserPhotoCommandValidator : AbstractValidator<UpdateUserPhotoCommand>
    {
        public UpdateUserPhotoCommandValidator()
        {
            RuleFor(up => up.Userid).Must(u => u!=null && u?.Length>1).WithMessage("آیدی کاربر معتبر نمیباشد") ; 
            RuleFor(up => up.Photo).SetValidator(new UserPhotoPropertyValidator()).WithMessage("فرمت فایل ورودی نا معتبر است") ; 
        }
    }
}