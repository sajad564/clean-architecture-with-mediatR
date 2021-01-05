using System.Collections.Generic;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Entities;

namespace book.Domain.Interfaces.Repositories
{
    public interface IPhotoRepository : IBaseRepository<Img>
    {
        
         Task<IEnumerable<Img>> GetImgsByBookIdAsync(string BookId) ; 
         Task<Img> GetImgByUserIdAsync(string UserId) ; 
         Task<Img> GetPhotoByIdAsync(string PhotoId) ; 
    }
}