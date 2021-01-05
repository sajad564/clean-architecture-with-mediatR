using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using book.Application.CQRS.Queries;
using book.Domain.Interfaces.Repositories;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Http;

namespace book.Application.Validations.CustomValidators
{
    public class PermissionForGetComment : PropertyValidator
    {
        private HttpContext _Context { get; set; }
        private readonly ICommentRepository commentRepo;
        public PermissionForGetComment(HttpContext context, ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
            _Context = context;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return IsUserAdminOrCommentSender(context.PropertyValue as GetCommentQuery ) ; 
        }
        private bool IsUserAdminOrCommentSender(GetCommentQuery query)
        {
            if(!string.IsNullOrEmpty(query.Id))
            {
                var IsUserAdmin = _Context.User.FindAll(ClaimTypes.Role).Where(c => c.Value == "admin").Any();
                var IsSender = commentRepo.FindByExpression(c => c.Id==query.Id && c.senderId==query.Userid).Any() ;
                return IsUserAdmin || IsSender ;
            }
            return false ;  
        }
    }
}