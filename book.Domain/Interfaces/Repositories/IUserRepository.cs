using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using book.Domain.Common;
using book.Domain.Entities;

namespace book.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetUserByUsernameAsync(string Username) ; 
         Task<User> GetAuthorWIthBooksByIdAsync(string Id) ;
         Task<User> GetUserByEmailAsync(string Email) ; 
          Task<User> GetUserByIdAsync(string Id) ; 
          Task AddAsync(User user , string password) ; 
         Task<IEnumerable<User>> GetAllAuthorsWithBooksAsync() ;
         Task<bool> CheckUserPassword(User user , string Password) ;   
    }
}