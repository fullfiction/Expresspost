using System.Threading.Tasks;
using api.Core.Extensions;
using api.Core.Models;
using api.Core.Store;
using Microsoft.EntityFrameworkCore;

namespace api.Core.Services
{
    public class EmployeeService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IUsernameNormalizerService _usernameNormalizerService;
        private readonly IPasswordHashService _passwordHashService;

        public EmployeeService(UnitOfWork unitOfWork, IUsernameNormalizerService usernameNormalizerService, IPasswordHashService passwordHashService)
        {
            _unitOfWork = unitOfWork;
            _usernameNormalizerService = usernameNormalizerService;
            _passwordHashService = passwordHashService;
        }

        public async Task<Employee> GetByUsernameAsync(string username)
        {
            username = NormalizeUsername(username);
            var admin = await _unitOfWork.GetStore<Employee>().GetByExpression(x => x.Username.ToUpper() == username).FirstOrDefaultAsync();
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

        public async Task<Employee> GetActiveBySubAsync(long sub)
        {
            var admin = await _unitOfWork.GetStore<Employee>().GetByExpression(x => x.Id == sub && x.IsActive).FirstOrDefaultAsync();
            return admin;
        }

        public async Task<Result<Employee>> ValidateCredentials(string username, string password)
        {
            var admin = await GetByUsernameAsync(username);
            if (admin == null)
                return ErrorDescriber.InvalidUsername().ToResult<Employee>();
            password = HashPassword(password);
            if (admin.Password != password)
                return ErrorDescriber.InvalidPassword().ToResult<Employee>();
            return admin.ToResult();
        }

        public async Task<Result<Employee>> UpdateAsync(long id, Employee employee)
        {
            var stored = await _unitOfWork.GetStore<Employee>().GetByIdAsync(id, true);
            stored.IsActive = employee.IsActive;
            stored.Username = NormalizeUsername(employee.Username);
            var updated = _unitOfWork.GetStore<Employee>().Update(stored);
            await _unitOfWork.SaveAsync();
            return updated.ToResult<Employee>();
        }

        public async Task<Result<Employee>> CreateAsync(Employee employee)
        {
            var newEmployee = new Employee
            {
                IsActive = employee.IsActive,
                Password = HashPassword(employee.Password),
                Username = NormalizeUsername(employee.Username)
            };
            var created = _unitOfWork.GetStore<Employee>().Create(newEmployee);
            await _unitOfWork.SaveAsync();
            return created.ToResult<Employee>();
        }
    }
}
