using book.Application.common;
using book.Application.common.Resources;
using MediatR;

namespace book.Application.CQRS.Queries
{
    public class GetCurrentUserQuery : BaseInformation , IRequest<Response<UserResource>>
    {
        
    }
}