using System;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Entities;

namespace book.Domain.Interfaces.Repositories
{
    public interface IFileRepository : IBaseRepository<File>
    {
         Task<File> GetFileByBookIdAsync(string BookId) ;
          
    }
}