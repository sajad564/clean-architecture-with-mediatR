using System.Threading.Tasks;
using book.Application.common;
using book.Application.common.Resources;
using book.Application.CQRS.Command;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book.Api.Controllers
{
    // for updating user and book photo
    [ApiController]
    [Route("api/[Controller]")]
    [Authorize]
    public class FileController : ControllerBase
    {
        private readonly IMediator mediator;
        public FileController(IMediator mediator)
        {
            this.mediator = mediator;

        }
        [HttpPut("[Action]")]

        public async Task<Response<bool>> UserPhoto([FromForm] UpdateUserPhotoCommand userPhotoCommand)
        {
            return await mediator.Send(userPhotoCommand) ; 
        }
        [HttpDelete]
        public async Task<Response<bool>> BookPhoto([FromBody] RemoveBookPhotoCommand command) {
            return await mediator.Send(command) ; 
        }
        
        [HttpGet("{bookId}")]
        public async Task<Response<FileResource>> BookFile(string BookId) {
            return await mediator.Send(new GetBookFileQuery(BookId)) ; 
        }
    }
}