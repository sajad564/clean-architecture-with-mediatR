using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Common;
using book.Domain.Entities;
using book.Domain.Enums;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using MediatR;

namespace book.Application.CQRS.Handlers
{
    public class UpdateUserPhotoCommandHandler : IRequestHandler<UpdateUserPhotoCommand, Response<bool>>
    {
        private readonly IFileManager fileManager;
        private readonly IPhotoRepository photoRepo;
        public UpdateUserPhotoCommandHandler(IFileManager fileManager , IPhotoRepository photoRepo)
        {
            this.photoRepo = photoRepo;
            this.fileManager = fileManager;

        }
        public async Task<Response<bool>> Handle(UpdateUserPhotoCommand request, CancellationToken cancellationToken)
        {
            UploadedFileData uploadedData = await fileManager.AddFileAsync(request.Photo , FileTypeEnum.UserPhoto) ;
             Img  userPhoto = await photoRepo.GetImgByUserIdAsync(request.Userid) ;
            // remove from hard
             fileManager.DeleteFile(userPhoto.Path) ; 
            // remove from db
             await photoRepo.Remove(userPhoto) ; 
             Img newImg = new Img {
                 UserId = request.Userid , 
                 Url = uploadedData.Url ,
                 Path = uploadedData.Path 
             } ; 
             await photoRepo.AddAsync(newImg) ; 
             return Response.Ok() ;
        }
    }
}