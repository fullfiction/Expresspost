using System;

namespace api.Core.Services
{
    public class UsernameUpperNormalizer : IUsernameNormalizerService
    {
        public string Normalize(string username)
        {
            return username.ToUpper();
        }
    }
}
