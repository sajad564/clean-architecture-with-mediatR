using book.Application.CQRS.Command;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class RefreshCommandValidator : AbstractValidator<RefreshCommand>
    {
        public RefreshCommandValidator()
        {
            RuleFor(rt => rt.AccessToken).Must(atoken => !string.IsNullOrEmpty(atoken)).WithMessage("درخواست نامعتبر");
            RuleFor(rt => rt.RefreshToken).Must(rtoken => !string.IsNullOrEmpty(rtoken)).WithMessage("درخواست نامعبتر") ;
        }
    }
}