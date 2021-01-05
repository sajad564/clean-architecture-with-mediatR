using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using book.Domain.Interfaces.Repositories;
using MediatR;
using System.Linq;
using book.Application.common.Resources;
using book.Application.common.HelperClasses;

namespace book.Application.CQRS.Handlers
{
    public class GetBooksPerPageQueryHandler : IRequestHandler<GetBooksPerPageQuery, Response<PagedList<BookResource>>>
    {
        private readonly IBookRepository bookRepo;
        private readonly PagedListConvertor pagedConvertor;
        public GetBooksPerPageQueryHandler(IBookRepository bookRepo, PagedListConvertor pagedConvertor)
        {
            this.pagedConvertor = pagedConvertor;
            this.bookRepo = bookRepo;

        }
        public async Task<Response<PagedList<BookResource>>> Handle(GetBooksPerPageQuery request, CancellationToken cancellationToken)
        {
            PagedList<Book> pagedBook = await bookRepo.GetBooksPerPage(request as BookPaginationParams);
            if (pagedBook.Any())
            {
                PagedList<BookResource> pagedBookResource = pagedConvertor.bookPagedToResource(pagedBook) ;
                return Response.Ok<PagedList<BookResource>>(pagedBookResource);
            }
            else
            {
                return Response.Fail<PagedList<BookResource>>("هیچ کتابی با این مشخصات وجود ندارد", StatusCodeEnum.NOTFUOUND);
            }
        }
    }
}