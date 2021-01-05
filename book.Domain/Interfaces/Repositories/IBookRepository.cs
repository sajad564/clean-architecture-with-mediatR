using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Entities;
using book.Domain.Entities.pagination;

namespace book.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Book>
    {
        Task<Book> GetByIdAsync(string Id) ; 
         Task<IEnumerable<Book>> GetBooksWithAuthorIdAsync(string AuthorId) ;
        Task<PagedList<Book>> GetBooksPerPage(BookPaginationParams bookParams) ; 
    }
}