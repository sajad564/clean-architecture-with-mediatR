using book.Application.CQRS.Queries;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class GetBookCommentsQueryValidator : AbstractValidator<GetBookCommentsQuery>
    {
       public GetBookCommentsQueryValidator()
       {
           RuleFor(gbook => gbook.BookId).NotNull().WithMessage(" آیدی اجباری میباشد")
           .NotEmpty().WithMessage(" آیدی اجباری میباشد")  ;
       }     
    }
}