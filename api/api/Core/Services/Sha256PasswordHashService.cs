using System;
using api.Core.Crypto;

namespace api.Core.Services
{
    public class Sha256PasswordHashService : IPasswordHashService
    {
        public string Hash(string unhashedPasswod)
        {
            return unhashedPasswod.HashSha256();
        }
    }
}
