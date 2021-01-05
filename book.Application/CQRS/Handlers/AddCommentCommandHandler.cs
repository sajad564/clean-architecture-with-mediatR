using System;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Response<bool>>
    {
        private readonly ICommentRepository commentRepo;
        private readonly IBookRepository bookRepo;
        public AddCommentCommandHandler(ICommentRepository commentRepo, IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
            this.commentRepo = commentRepo;

        }
        public async Task<Response<bool>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment
            {
                CreatedDate = DateTime.UtcNow , 
                senderId = request.Userid ,
                Description = request.Description,
                BookId = request.bookId 
            };
            await commentRepo.AddAsync(comment);
            return Response.Ok() ; 
        }
    }
}