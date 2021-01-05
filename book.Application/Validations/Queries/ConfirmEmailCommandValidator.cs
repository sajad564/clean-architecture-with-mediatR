using book.Application.CQRS.Command;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class ConfirmEmailCommandValidator : AbstractValidator<ConfirmEmailCommand>
    {
        public ConfirmEmailCommandValidator()
        {
            RuleFor(ce => ce.UserId).Must(userid => !string.IsNullOrEmpty(userid)).WithMessage("درخواست نامعتبر") ;
            RuleFor(ce => ce.Token).Must(token => !string.IsNullOrEmpty(token)).WithMessage("درخواست نامعتبر") ; 
        }
    }
}