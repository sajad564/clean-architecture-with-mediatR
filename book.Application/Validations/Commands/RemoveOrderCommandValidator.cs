using book.Application.CQRS.Command;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class RemoveOrderCommandValidator : AbstractValidator<RemoveOrderCommand>
    {
        public RemoveOrderCommandValidator()
        {
            RuleFor(ro => ro.OrderId).Must(orderId => !string.IsNullOrEmpty(orderId)).WithMessage("درخواست نا معتبر") ; 
        }
    }
}