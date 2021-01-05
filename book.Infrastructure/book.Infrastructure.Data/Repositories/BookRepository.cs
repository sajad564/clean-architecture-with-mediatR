using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using book.Domain.Enums;
using book.Domain.Interfaces.Repositories;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Data.common;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Repositories
{
    public class BookRepository : BaseRepository<Book>, IBookRepository
    {
        public BookRepository(MyDbContext db) : base(db)
        {
            
        }
         public  async Task<Book> GetByIdAsync(string Id) {
            return await FindByExpression(b => b.Id==Id ).Include(b => b.Imgs).Include(b =>b.Author).ThenInclude(author => author.Img).FirstOrDefaultAsync() ; 
        }
        public async Task<PagedList<Book>> GetBooksPerPage(BookPaginationParams pageParams)
        {
            var filteredSource = Filter(pageParams).Include(b => b.Imgs).Include(b => b.Author) ;
            return await PagedList<Book>.ToPagedList(filteredSource , pageParams.Pagenumber ,pageParams.Pagesize) ;  
        }

        public async Task<IEnumerable<Book>> GetBooksWithAuthorIdAsync( string AuthorId)
        {
            return await FindByExpression(b => b.AuthorId==AuthorId ).Include(b => b.Author).ToListAsync() ; 
        }
        private IQueryable<Book> Filter(BookPaginationParams bookParams) {
            return FindByExpression(book => 
            ( book.publishDate>=bookParams.MinDateTime) 
            && (book.publishDate<=bookParams.MaxDateTime) 
            && ((bookParams.minPrice==null || book.Price>=bookParams.minPrice)) 
            && ((bookParams.maxPrice==null ||  book.Price<=bookParams.maxPrice))
            && (bookParams.BookCategories==null ||  bookParams.BookCategories.Where(b => b.Equals(book.Category)).Any()) 
            && (string.IsNullOrEmpty(bookParams.AuthorId) || book.AuthorId==bookParams.AuthorId)); 
        }
    }
}