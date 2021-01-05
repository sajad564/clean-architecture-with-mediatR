using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;
using book.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;

namespace book.Application.Validations.CustomValidators
{
    public class DownloadFilePermissionPropertyValidator : PropertyValidator
    {
        private HttpContext httpContext { get; set; }
        private readonly IOrderRepository orderRepo;
        private readonly IBookRepository bookRepo;
        public DownloadFilePermissionPropertyValidator(IOrderRepository orderRepo, IBookRepository bookRepo, IHttpContextAccessor accessor)
        {
            this.bookRepo = bookRepo;
            this.orderRepo = orderRepo;
            this.httpContext = accessor.HttpContext;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var _context = context.PropertyValue as GetBookFileQuery;
            var HavePermission = BuyerOrAuthr(_context);
            if (HavePermission)
                return HavePermission;
            var isInAdminRole = IsAdmin();
            return isInAdminRole;
        }
        private bool BuyerOrAuthr(GetBookFileQuery _context)
        {

            Expression<Func<Order, bool>> boughtExpression = order => order.UserId == _context.Userid && order.status == OrderStatusEnum.ADDED && order.ProductId == _context.Bookid;
            // user is author of this book
            Expression<Func<Book, bool>> IsAuthorOfBookExpression = book => book.Id==_context.Bookid&& book.AuthorId==_context.Userid;
            return orderRepo.FindByExpression(boughtExpression).Any() || bookRepo.FindByExpression(IsAuthorOfBookExpression).Any();
        }
        private bool IsAdmin()
        {
            return httpContext.User.FindAll(ClaimTypes.Role).Where(c => c.Value == "admin").Any();
        }


    }
}