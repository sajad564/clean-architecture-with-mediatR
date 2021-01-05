using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace book.Infrastructure.Data.Security
{
    public class PasswordRecoveryTokenProvider<TUser> : DataProtectorTokenProvider<TUser> where TUser : class
    {
        public PasswordRecoveryTokenProvider(IDataProtectionProvider dataProtectionProvider, IOptions<PasswordRecoveryTokenProviderOptions> options) : base(dataProtectionProvider, options)
        {
        }
    }
}