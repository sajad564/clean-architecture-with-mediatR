using book.Application.CQRS.Queries;
using book.Application.Validations.CustomValidators;
using book.Domain.Interfaces.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace book.Application.Validations.Queries
{
    public class GetBookFileQueryValidator : AbstractValidator<GetBookFileQuery>
    {
        public GetBookFileQueryValidator(IOrderRepository orderRepo , IBookRepository bookRepo , IHttpContextAccessor accessor)
        {
            RuleFor(gbf => gbf.Bookid).Must(bId => bId!=null && bId.Length>1).WithMessage("کتاب مورد نظر یافت نشد") ; 
            RuleFor(gbf => gbf).SetValidator(new DownloadFilePermissionPropertyValidator(orderRepo ,bookRepo , accessor)).WithMessage("شما اجازه دسترسی به این فایل را ندارید") ; 
        }
    }
}