using book.Application.CQRS.Command;
using book.Application.Validations.CustomValidators;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace book.Application.Validations.Commands
{
    public class RemoveBookCommandValidator : AbstractValidator<RemoveBookCommand>
    {
        public RemoveBookCommandValidator(IBookRepository bookRepo , UserManager<User> userManager)
        {
            RuleFor(rb => rb.Userid).Must(userId => !string.IsNullOrEmpty(userId)).WithMessage("آیدی کاربر الزامی میباشد") ; 
        }
    }
}