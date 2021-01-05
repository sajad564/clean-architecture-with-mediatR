using book.Application.common;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace book.Application.CQRS.Command
{
    public class RegisterUserCommand : IRequest<Response<bool>>
    {
        public string Username {get;set;}
        public string Firstname {get;set;}
        public string Lastname {get;set;}
        public string Email {get;set;}
        public string Password {get;set;}
        public string ConfirmPassword {get;set;}
        public IFormFile Photo {get;set;}

    }
}