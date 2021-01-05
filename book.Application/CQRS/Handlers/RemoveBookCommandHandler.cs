using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, Response<bool>>
    {
        private readonly IBookRepository bookRepo;
        public RemoveBookCommandHandler(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;

        }
        public async Task<Response<bool>> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
        {
            if(AuthorizeDeleteBook(request))
            {
                var findBook = await bookRepo.GetByIdAsync(request.BookId) ;
                await bookRepo.Remove(findBook) ; 
                return Response.Ok();
            }
            return Response.Fail<bool>("شما اجازه این کار را ندارید" , StatusCodeEnum.NOTAUTHORIZE) ; 
            
        }
        private bool AuthorizeDeleteBook(RemoveBookCommand command)
        {
            var IsAdmin = command.Roles.Where( r => r=="admin").Any() ; 
            var IsAuthorOfBook  = bookRepo.FindByExpression(b => b.Id==command.BookId && b.AuthorId==command.Userid).Any();
            return IsAdmin || IsAuthorOfBook ; 
        }
    }
}