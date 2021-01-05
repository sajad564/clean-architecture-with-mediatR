using System;
using System.Threading;
using System.Threading.Tasks;
using book.Application.common;
using book.Application.CQRS.Queries;
using book.Domain.Entities;
using book.Domain.Interfaces.Repositories;
using book.Domain.Interfaces.services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace book.Application.CQRS.Handlers
{
    public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, Response<bool>>
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailSender emailSender;
        private readonly IUserRepository userRepo;
        public ConfirmEmailQueryHandler(UserManager<User> userManager, IEmailSender emailSender, IUserRepository userRepo)
        {
            this.userRepo = userRepo;
            this.emailSender = emailSender;
            this.userManager = userManager;

        }
        public async Task<Response<bool>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (ValidationUser(user))
            {
                await UpdateRequestForConfirmationLinkDateAsync(user);
                await emailSender.EmailConfirmationAsync(user);
                return Response.Ok();
            }
            return Response.Fail<bool>("اطلاعات شما معتبر نمیباشد", StatusCodeEnum.NOTAUTHORIZE);
        }
        private bool ValidationUser(User user)
        {
            var lastTimeConfirmLink = Math.Abs(user.LastTimeSendConfirmLink.Subtract(DateTime.Now).TotalMinutes);
            return user != null && !user.EmailConfirmed && lastTimeConfirmLink >= 30;
        }
        private async Task UpdateRequestForConfirmationLinkDateAsync(User user)
        {
            user.LastTimeSendConfirmLink = DateTime.Now;
            await userRepo.UpdateAsync(user) ; 
        }

    }
}