using book.Application.CQRS.Queries;
using book.Domain.Interfaces.Repositories;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class GetBookWithIdQueryValidator : AbstractValidator<GetBookCommentsQuery>
    {
        public GetBookWithIdQueryValidator(IBookRepository bookRepo)
        {
            RuleFor(b => b.BookId).NotNull().WithMessage("عدم تطابق اطلاعات") ; 
        }
    }
}