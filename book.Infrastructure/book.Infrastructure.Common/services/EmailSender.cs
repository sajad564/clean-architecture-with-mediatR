
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using book.Domain.Entities;
using book.Domain.Interfaces.services;
using book.Infrastructure.Common.Common;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using MimeKit;

namespace book.Infrastructure.Common.services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration emailConf;
        private readonly UserManager<User> userManager;
        private readonly ConfirmAndRecovery confirmAndRecoveryConfigue;
        public EmailSender(EmailConfiguration emailConf, ConfirmAndRecovery confirmAndRecoveryConfigue, UserManager<User> userManager)
        {
            this.confirmAndRecoveryConfigue = confirmAndRecoveryConfigue;
            this.userManager = userManager;
            this.emailConf = emailConf;

        }
        public async Task SendEmailAsync(EmailMessage message)
        {
            var mime = MimeCreator(message);
            await sendAsync(mime);
        }
        private async Task sendAsync(MimeMessage mime)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(emailConf.SmtpServer, emailConf.Port);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(emailConf.Username, emailConf.Password);
                    await client.SendAsync(mime);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
        private MimeMessage MimeCreator(EmailMessage message)
        {
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(emailConf.Name, emailConf.From));
            mimeMessage.To.AddRange(message.EmailAddresses.Select(email => new MailboxAddress(email)).ToList());
            mimeMessage.Subject = message.Subject;
            mimeMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return mimeMessage;
        }

        public async Task EmailConfirmationAsync(User user)
        {
            var link = await ConfirmLinkGeneratorAsync(user) ; 
            var message = new EmailMessage(new string[] {user.Email} , confirmAndRecoveryConfigue.ClientConfirmRoute , link) ;
            await SendEmailAsync(message) ; 
        }
        private async Task<string> ConfirmLinkGeneratorAsync(User user)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            var queryString = $"?token={HttpUtility.UrlEncode(token)}&&userId={user.Id}" ; 
            var emailConfirmationLink = confirmAndRecoveryConfigue.ClientConfirmRoute + queryString ; 
            return emailConfirmationLink ; 
        }

        public async Task PasswordRecoveryAsync(User user)
        {
            var passwordRecoveryLink = await PasswordRecoveryLinkAsync(user) ;
            await SendEmailAsync(new EmailMessage(new string[] {user.Email}  , confirmAndRecoveryConfigue.RecoverySubject ,passwordRecoveryLink )) ; 
        }
        private async Task<string> PasswordRecoveryLinkAsync(User user)
        {
            var token = await userManager.GeneratePasswordResetTokenAsync(user) ; 
            
            var queryString = $"?userid={user.Id}&&token={HttpUtility.UrlEncode(token)}" ; 
            var recoveryLink = confirmAndRecoveryConfigue.ClientRecoveryRoute + queryString; 
            return recoveryLink ; 
        }
    }
}