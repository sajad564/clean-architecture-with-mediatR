using System;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Command;
using book.Domain.Entities;
using book.Domain.Enums;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace book.Application.CQRS.Handlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<bool>>
    {
        private readonly IUserRepository UserRepo;
        private readonly IFileManager fileManager;
        private readonly IEmailSender emailSender;
        public RegisterUserCommandHandler(IUserRepository UserRepo, IFileManager fileManager, IEmailSender emailSender)
        {
            this.emailSender = emailSender;
            this.fileManager = fileManager;
            this.UserRepo = UserRepo;

        }
        public async Task<Response<bool>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var uploadedFileData = await fileManager.AddFileAsync(request.Photo, FileTypeEnum.UserPhoto);
            var user = new User
            {
                FirstName = request.Username,
                LastName = request.Lastname,
                UserName = request.Username,
                Email = request.Email,
                LastTimeSendConfirmLink = DateTime.Now ,
                Img = new Img
                {
                    Url = uploadedFileData.Url,
                    Path = uploadedFileData.Path
                }
            };


            await UserRepo.AddAsync(user, request.Password);
            //now , confirm email
            await emailSender.EmailConfirmationAsync(user);
            return Response.Ok() ; 

        }
        
    }
}