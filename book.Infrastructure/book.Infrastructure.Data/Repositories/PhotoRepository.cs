using System.Collections.Generic;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Data.common;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Repositories
{
    public class PhotoRepository : BaseRepository<Img>, IPhotoRepository
    {
        public PhotoRepository(MyDbContext db) : base(db)
        {
            
        }
        public async Task<Img> GetImgByUserIdAsync(string UserId)
        {
            return await FindByExpression(p => p.UserId==UserId).FirstOrDefaultAsync() ; 
        }

        public async Task<IEnumerable<Img>> GetImgsByBookIdAsync(string BookId)
        {
            return await FindByExpression(p => p.BookId==BookId).ToListAsync() ;
        }

        public async Task<Img> GetPhotoByIdAsync(string PhotoId)
        {
            return await FindByExpression(p => p.Id==PhotoId).FirstOrDefaultAsync() ; 
        }
        
    }
}