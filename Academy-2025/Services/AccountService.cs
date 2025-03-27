using Academy_2025.Data;
using Academy_2025.DTOs;
using Academy_2025.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Academy_2025.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public AccountService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User?> LoginAsync(LoginDTO loginDTO)
        {
            var user = await _repository.GetByEmailAsync(loginDTO.Email);

            if (user != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDTO.Password);
                return result == PasswordVerificationResult.Success ? user : null;
            }
            else 
            { 
                return null; 
            }
        }
    }
}
