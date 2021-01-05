using System;
using System.Linq;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Data.common;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Repositories
{
    public class FileRepository : BaseRepository<File>, IFileRepository
    {
        public FileRepository(MyDbContext db) : base(db)
        {
            
        }
        public async Task<File> GetFileByBookIdAsync(string BookId)
        {
            return await db.Files.Where( f => f.BookId==BookId ).FirstOrDefaultAsync() ;
        }
    }
}