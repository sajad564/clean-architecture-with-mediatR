using System;
using System.Linq;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Entities.pagination;
using book.Domain.Interfaces.Repositories;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Data.common;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Repositories
{
    public class CommentRepository : BaseRepository<Comment> ,  ICommentRepository 
    {
        public CommentRepository(MyDbContext db) : base(db) 
        {
            
        }

        public async Task<Comment> GetCommentAsync(string Id)
        {
            return await FindByExpression(c => c.Id==Id ).Include(c => c.Book).Include(c => c.Sender).ThenInclude(sender => sender.Img).Include(c => c.Book).FirstOrDefaultAsync() ; 
        }

        public async Task<PagedList<Comment>> GetCommentPerPage(CommentPaginationParams pageParams)
        {
            IQueryable<Comment> filteredSource = Filter(pageParams).Include(c => c.Sender) ;
            return await PagedList<Comment>.ToPagedList(filteredSource , pageParams.Pagenumber , pageParams.Pagesize);
        }
        private IQueryable<Comment> Filter(CommentPaginationParams pageParams) {
            return FindByExpression(comment => 
            comment.CreatedDate > pageParams.MinDateTime 
            && comment.CreatedDate< pageParams.MaxDateTime
            && (string.IsNullOrEmpty(pageParams.BookId ) || comment.BookId==pageParams.BookId )
            && (string.IsNullOrEmpty(pageParams.UserId ) || comment.senderId==pageParams.UserId )) ;
        }
    }
}