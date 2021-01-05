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
    public class PasswordRecoveryQueryHandler : IRequestHandler<PasswordRecoveryQuery, Response<bool>>
    {
        private readonly UserManager<User> userManager;
        private readonly IEmailSender emailSender;
        private readonly IUserRepository userRepository;
        public PasswordRecoveryQueryHandler(UserManager<User> userManager, IUserRepository userRepository, IEmailSender emailSender)
        {
            this.userRepository = userRepository;
            this.emailSender = emailSender;
            this.userManager = userManager;

        }
        public async Task<Response<bool>> Handle(PasswordRecoveryQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                if (ValidatePasswordRecoveryDate(user))
                {
                    await UpdatePasswordRecoveryRequestDate(user);
                    await emailSender.PasswordRecoveryAsync(user);
                    return Response.Ok();
                }
                return Response.Fail<bool>("در کمتر از 30 دقیقه گذشته یک ایمیل بازایبی برای شما ارسال شده است,لطفا ایمیل خود را بررسی کنید", StatusCodeEnum.BADREQUEST);
            }
            return Response.Fail<bool>("لطفا اطلاعات خود را بررسی کنید", StatusCodeEnum.NOTAUTHORIZE);
        }
        private bool ValidatePasswordRecoveryDate(User user)
        {
            DateTime lastDate = user.LastTimeSendRecovryLink!=null ? (DateTime)user.LastTimeSendRecovryLink : DateTime.UtcNow.AddMinutes(-31);
            
            var differenceMinutes = Math.Abs(lastDate.Subtract(DateTime.Now).TotalMinutes);
            return differenceMinutes >= 30;
        }
        private async Task UpdatePasswordRecoveryRequestDate(User user)
        {
            user.LastTimeSendRecovryLink = DateTime.Now ;
            await userRepository.UpdateAsync(user) ;
        }
    }
}