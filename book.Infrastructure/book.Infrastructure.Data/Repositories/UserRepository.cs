using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Infrastructure.Data.Data;
using book.Infrastructure.Data.Data.common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace book.Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly UserManager<User> userManager;

        public UserRepository(MyDbContext db, UserManager<User> userManager) : base(db)
        {
            this.userManager = userManager;

        }
          public async Task AddAsync(User user , string password) 
        {
            await userManager.CreateAsync(user ,password ) ; 
        }
        public async Task<bool> CheckUserPassword(User user, string Password)
        {
            return await userManager.CheckPasswordAsync(user,Password) ; 
        }

        public async Task<IEnumerable<User>> GetAllAuthorsWithBooksAsync()
        {
            return await FindByExpression(u => u.Books.Any()).Include(u => u.Img).Include(u => u.Books).ToListAsync() ;
        }

        public async Task<User> GetAuthorWIthBooksByIdAsync(string Id)
        {
            return await FindByExpression(u => u.Books.Any() && u.Id==Id ).Include(u => u.Books).FirstOrDefaultAsync() ;
        }

        

        public async Task<User> GetUserByEmailAsync(string Email)
        {
            return await FindByExpression(u => u.Email==Email).Include(u => u.Img).FirstOrDefaultAsync() ;
        }

        public async Task<User> GetUserByIdAsync(string Id)
        {
            return await FindByExpression(u => u.Id ==Id).FirstOrDefaultAsync() ;
        }

        public async Task<User> GetUserByUsernameAsync(string Username)
        {
            return await FindByExpression(u => u.UserName==Username).FirstOrDefaultAsync() ; 
        }
    }
}