using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Enums;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Response<bool>>
    {
        private readonly IUserRepository authorRepo;
        private readonly IBookRepository bookRepo;
        private readonly IFileManager fileManager;
        public AddBookCommandHandler(IUserRepository authorRepo, IBookRepository bookRepo, IFileManager fileManager)
        {
            this.fileManager = fileManager;
            this.bookRepo = bookRepo;
            this.authorRepo = authorRepo;

        }
        public async Task<Response<bool>> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            
                var uploadedBookPhotosData = await fileManager.AddMultipleFileAsync(request.BookPhotos , FileTypeEnum.BookPhoto) ; 
                var uploadedBookFileData = await fileManager.AddFileAsync(request.BookFile , FileTypeEnum.BookFile) ; 
                var book = new Book
                {
                    publishDate = request.PublishedDate ,
                    BookName = request.BookName,

                    AuthorId = request.Userid ,
                    Price = request.Price , 
                    Category =(BookCategoryEnum) request.Category ,
                    Description = request.Description , 
                    File  = new File {
                        Url = uploadedBookFileData.Url , 
                        Path = uploadedBookFileData.Path
                    } , 
                    Imgs =  uploadedBookPhotosData.Select(u => new Img {
                        Url = u.Url , 
                        Path = u.Path
                    }).ToList() 
                };
                await bookRepo.AddAsync(book) ; 

                return Response.Ok() ;
        }
    }
}