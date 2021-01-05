using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.CQRS.Queries;
using book.Domain.Enums;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;

namespace book.Application.Validations.CustomValidators
{
    public class UserBoughtBook : PropertyValidator
    {
        private readonly IOrderRepository orderRepo;
        public UserBoughtBook(IOrderRepository orderRepo) : base("شما مجاز به دریافت این فایل نیستید")
        {
            this.orderRepo = orderRepo;

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var getbookFileQuery = context.PropertyValue as GetBookFileQuery ;
            var IsOrderPaid  = orderRepo.FindByExpression(o => o.ProductId==getbookFileQuery.Bookid && o.UserId==getbookFileQuery.Userid && o.status==OrderStatusEnum.PAID).Any() ;
            return IsOrderPaid ;  
        }
    }
}