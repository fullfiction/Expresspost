using System;
using System.Threading.Tasks;
using api.Core.Extensions;
using api.Core.Models;
using api.Core.Store;
using api.Core.Store.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Core.Services
{
    public class AdminService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IUsernameNormalizerService _usernameNormalizerService;
        private readonly IPasswordHashService _passwordHashService;

        public AdminService(UnitOfWork unitOfWork, IUsernameNormalizerService usernameNormalizerService, IPasswordHashService passwordHashService)
        {
            _unitOfWork = unitOfWork;
            _usernameNormalizerService = usernameNormalizerService;
            _passwordHashService = passwordHashService;
        }

        public async Task<Admin> GetByUsernameAsync(string username)
        {
            username = _usernameNormalizerService.Normalize(username);
            var admin = await _unitOfWork.AdminStore.GetByExpression(x => x.Username == username).FirstOrDefaultAsync();
            return admin;
        }

        public string HashPassword(string rawPassword)
        {
            return _passwordHashService.Hash(rawPassword);
        }

        public async Task<Result<Admin>> ValidateCredentials(string username, string password)
        {
            var admin = await GetByUsernameAsync(username);
            if (admin == null)
                return ErrorDescriber.InvalidUsername().ToResult<Admin>();
            password = HashPassword(password);
            if (admin.Password != password)
                return ErrorDescriber.InvalidPassword().ToResult<Admin>();
            return admin.ToResult();
        }
    }
}
