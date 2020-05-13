using System;

namespace api.Core.Services
{
    public interface IPasswordHashService
    {
        string Hash(string unhashedPasswod);
    }
}
