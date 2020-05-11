using System;
using api.Infrastructure.Security;
using Xunit;

namespace api.tests.Security
{
    public class TokenManagerTests
    {
        private JWTokenService _tokenService;

        public TokenManagerTests(JWTokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [Fact]
        public void Create_should_throw_exception_when_claims_null()
        {
            Assert.Throws<ArgumentNullException>(() => _tokenService.CreateToken(null));
        }
    }
}
