using System.Threading.Tasks;
using book.Domain.Entities;

namespace book.Domain.Interfaces.services
{
    public interface ITokenGenerator
    {
         Task<string> GenerateTokenAsync(User user) ;
          string GetUsernameFromExpiredToken(string token) ;
          string RefreshTokenGeneretor() ;  
    }
}