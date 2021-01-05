using book.Application.CQRS.Queries;
using book.Application.Validations.CustomValidators;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

namespace book.Application.Validations.Queries
{
    public class GetOrderQueryValidator : AbstractValidator<GetOrderQuery>
    {
        public GetOrderQueryValidator(IOrderRepository orderRepo , UserManager<User> userManager)
        {
            RuleFor(go => go.OrderId).Must( orderId => !string.IsNullOrEmpty(orderId)).WithMessage("درخواست نامعتبر"); 
        }
    }
}