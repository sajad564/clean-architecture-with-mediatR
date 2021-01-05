using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;

namespace book.Application.Validations.Commands
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        private readonly IBookRepository bookRepo;
        public AddOrderCommandValidator(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
            RuleFor(ao => ao.Userid).Must(userid => !string.IsNullOrEmpty(userid)).WithMessage("درخواست نامعتبر") ; 
            RuleFor(ao => ao.ProductId).SetValidator(new ProductShouldExistPropertyValidator(bookRepo)) ; 
        }
    }
}