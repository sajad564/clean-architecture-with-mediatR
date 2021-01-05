using System.Threading.Tasks;
using book.Domain.Entities;

namespace book.Domain.Interfaces.services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage message) ;
        Task EmailConfirmationAsync(User user) ;
        Task PasswordRecoveryAsync(User user)   ; 
    }
}