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
            username = NormalizeUsername(username);
            var admin = await _unitOfWork.GetStore<Admin>().GetByExpression(x => x.Username.ToUpper() == username).FirstOrDefaultAsync();
            return admin;
        }

        public string NormalizeUsername(string rawUsername)
        {
            return _usernameNormalizerService.Normalize(rawUsername);
        }

        public string HashPassword(string rawPassword)
        {
            return _passwordHashService.Hash(rawPassword);
        }

        public async Task<Admin> GetActiveBySubAsync(long sub)
        {
            var admin = await _unitOfWork.GetStore<Admin>().GetByExpression(x => x.Id == sub && x.IsActive).FirstOrDefaultAsync();
            return admin;
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

        public async Task<Result<Admin>> UpdateAsync(long id, Admin admin)
        {
            var stored = await _unitOfWork.GetStore<Admin>().GetByIdAsync(id, true);
            stored.IsActive = admin.IsActive;
            stored.Username = NormalizeUsername(admin.Username);
            var updated = _unitOfWork.GetStore<Admin>().Update(stored);
            await _unitOfWork.SaveAsync();
            return updated.ToResult<Admin>();
        }

        public async Task<Result<Admin>> CreateAsync(Admin admin)
        {
            var newAdmin = new Admin
            {
                IsActive = admin.IsActive,
                Password = HashPassword(admin.Password),
                Username = NormalizeUsername(admin.Username)
            };
            var created = _unitOfWork.GetStore<Admin>().Create(newAdmin);
            await _unitOfWork.SaveAsync();
            return created.ToResult<Admin>();
        }
    }
}
