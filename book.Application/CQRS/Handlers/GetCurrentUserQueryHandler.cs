using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.AutoMapper;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, Response<UserResource>>
    {
        private readonly IUserRepository userRepo;
        public GetCurrentUserQueryHandler(IUserRepository userRepo)
        {
            this.userRepo = userRepo;

        }
        public async Task<Response<UserResource>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepo.GetUserByIdAsync(request.Userid) ;
            var resource =  Mapping.Mapper.Map<UserResource>(user) ; 
            return Response.Ok<UserResource>(resource) ; 
        }
    }
}