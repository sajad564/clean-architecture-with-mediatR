using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.AutoMapper;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetBookFileQueryHandler : IRequestHandler<GetBookFileQuery, Response<FileResource>>
    {
        private readonly IFileRepository fileRepo;
        public GetBookFileQueryHandler(IFileRepository fileRepo)
        {
            this.fileRepo = fileRepo;

        }
        public async Task<Response<FileResource>> Handle(GetBookFileQuery request, CancellationToken cancellationToken)
        {
            File bookFile = await fileRepo.GetFileByBookIdAsync(request.Bookid) ; 
           return Response.Ok<FileResource>(Mapping.Mapper.Map<FileResource>(bookFile)) ; 
        }
    }
}