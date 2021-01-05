using System.Threading.Tasks;
using book.Domain.Entities;

namespace book.Domain.Interfaces.services
{
    public interface ITokenGenerator
    {
         Task<Token> GenerateTokenAsync(User user) ; 
    }
}