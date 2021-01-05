using book.Application.CQRS.Queries;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace book.Application.Validations.Queries
{
    public class GetCommentQueryValidator : AbstractValidator<GetCommentQuery>
    {
        public GetCommentQueryValidator(IHttpContextAccessor accessor , ICommentRepository commentRepo)
        {
            //this is commentId
            RuleFor(query => query.Id).Must(commentid => !string.IsNullOrEmpty(commentid)).WithMessage("ارسال آیدی کامنت اجباری میباشد") ;
            RuleFor(query => query).SetValidator(new PermissionForGetComment(accessor.HttpContext ,commentRepo )).WithMessage("شما اجازه دسترسی به این کامنت را ندارید") ; 
        }
    }
}