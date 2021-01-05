using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Entities;
using book.Domain.Entities.pagination;

namespace book.Domain.Interfaces.Repositories
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
         Task<PagedList<Comment>> GetCommentPerPage(CommentPaginationParams pageParams) ; 
         Task<Comment> GetCommentAsync(string Id)  ; 
    }
}