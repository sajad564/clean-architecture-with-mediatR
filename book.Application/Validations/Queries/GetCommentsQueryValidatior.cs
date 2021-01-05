using book.Application.CQRS.Queries;
using FluentValidation;

namespace book.Application.Validations.Queries
{
    public class GetCommentsQueryValidatior : AbstractValidator<GetCommentsQuery>
    {
        public GetCommentsQueryValidatior()
        {
            // put validation here ..
        }
    }
}