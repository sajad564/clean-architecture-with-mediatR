using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class GetBookWithIdHandler : IRequestHandler<GetBookWithIdQuery, Response<BookResource>>
    {
        private readonly IBookRepository bookRepo;
        private readonly IMapper mapper;
        public GetBookWithIdHandler(IBookRepository bookRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.bookRepo = bookRepo;

        }
        public async Task<Response<BookResource>> Handle(GetBookWithIdQuery request, CancellationToken cancellationToken)
        {
            var singleBook = await bookRepo.GetByIdAsync(request.BookId);
            if (singleBook != null)
            {
                return Response.Ok<BookResource>(mapper.Map<BookResource>(singleBook) );
            }
            else
            {
                return Response.Fail<BookResource>("اوه ,مثل اینکه این کتاب در دسترس نیست", StatusCodeEnum.NOTFUOUND);
            }
        }

    }
}