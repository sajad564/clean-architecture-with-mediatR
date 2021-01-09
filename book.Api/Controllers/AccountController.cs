using System;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;


namespace book.Api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;
        public AccountController(IMediator mediator )
        {
            this.mediator = mediator;

        }
        [HttpPost]
        public  async Task<Response<bool>> Register( [FromForm] RegisterUserCommand addUserCommand)
        {
            return await mediator.Send(addUserCommand) ;  
        }
        [Authorize]
        [HttpGet("[Action]")]
        public async Task<Response<UserResource>> CurrentUser() {
            return await mediator.Send(new GetCurrentUserQuery()) ; 
        }
        [HttpPost("[Action]")]
        public async Task<Response<Token>> Login([FromBody] LoginUserCommand loginInfo) {
            return await mediator.Send(loginInfo) ; 
        }
        [Authorize]
        [HttpPut]
        
        public async Task<Response<bool>> Update( [FromBody] UpdateUserCommand updateUser) {
             
            return await mediator.Send(updateUser) ; 
        }
        [HttpGet("[Action]/{email}")]
        public async Task<Response<bool>> ConfirmEmail(string email)
        {
            return await mediator.Send(new ConfirmEmailQuery(email)) ; 
        }
        [HttpPost("[Action]")]
        public async Task<Response<bool>> confirmEmail( [FromBody] ConfirmEmailCommand command )
        {
            return await mediator.Send(command) ; 
        }
        [HttpGet("[Action]/{email}")]
        public async Task<Response<bool>> PasswordRecovery( string email)
        {
            return await mediator.Send(new PasswordRecoveryQuery(email)) ; 
        }
        [HttpPost("[Action]")]
        public async Task<Response<bool>> PasswordRecovery([FromBody] PasswordRecoveryCommand command)
        {
            return await mediator.Send(command) ; 
        }
        [HttpPost("[Action]")]
        public async Task<Response<Token>> RefreshToken([FromBody] RefreshCommand command)
        {
            return await mediator.Send(command) ; 
        } 
        
    }
}