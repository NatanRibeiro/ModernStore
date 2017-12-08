using ModernStore.Api.Security;
using ModernStore.Infra.Transactions;
using System;

namespace ModernStore.Api.Controllers
{
    public class AccountController:BaseController
    {
        public AccountController(IUow uow) : base(uow)
        {

        }

        private static void ThrowIfInvalidOptions(TokenOptions options)
        {
            if (options == null)
                throw new ArgumentException(nameof(options));

            if (options.ValidFor <= TimeSpan.Zero)
                throw new ArgumentException("This time should be bigger than zero", nameof(TokenOptions.ValidFor));

            if (options.SigningCredentials == null)
                throw new ArgumentException(nameof(TokenOptions.SigningCredentials));

            if (options.JtiGenerator == null)
                throw new ArgumentException(nameof(TokenOptions.JtiGenerator));
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
