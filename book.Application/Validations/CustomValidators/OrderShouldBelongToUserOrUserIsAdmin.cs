using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Identity;

namespace book.Application.Validations.CustomValidators
{
    public class OrderShouldBelongToUserOrUserIsAdmin : AsyncValidatorBase
    {
        private readonly IOrderRepository orderRepo;
        private readonly UserManager<User> userManager;

        public OrderShouldBelongToUserOrUserIsAdmin(IOrderRepository orderRepo, UserManager<User> userManager) : base("شما مجاز به دریافت اطلاعات این سفارش نیستید")
        {
            this.userManager = userManager;

            this.orderRepo = orderRepo;

        }
        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken token)
        {
            var getOrderData = context.PropertyValue as GetOrderQuery;
            var user = await userManager.FindByIdAsync(getOrderData.Userid) ; 
            var isAdmin = await userManager.IsInRoleAsync(user , "admin") ; 
            var IsValid = orderRepo.FindByExpression(order => order.Id == getOrderData.OrderId && order.UserId == getOrderData.Userid).Any() || isAdmin ; 
            return IsValid;
        }
    }
}