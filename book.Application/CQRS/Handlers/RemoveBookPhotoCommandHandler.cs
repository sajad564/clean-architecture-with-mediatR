using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class RemoveBookPhotoCommandHandler : IRequestHandler<RemoveBookPhotoCommand, Response<bool>>
    {
        private readonly IPhotoRepository photoRepo;
        public RemoveBookPhotoCommandHandler(IPhotoRepository photoRepo)
        {
            this.photoRepo = photoRepo;

        }
        public async Task<Response<bool>> Handle(RemoveBookPhotoCommand request, CancellationToken cancellationToken)
        {
            var photo = await photoRepo.GetPhotoByIdAsync(request.PhotoId) ;
            await photoRepo.Remove(photo) ; 
            return Response.Ok() ; 
        }
    }
}