using System;

namespace api.Core.Services
{
    public interface IUsernameNormalizerService
    {
        string Normalize(string username);
    }
}
