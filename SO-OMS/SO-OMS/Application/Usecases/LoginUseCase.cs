using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using SO_OMS.Infrastructure.Security;
using System;

namespace SO_OMS.Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IPasswordHasher _passwordHasher;

        public LoginUseCase(IAdminRepository adminRepository, IPasswordHasher passwordHasher)
        {
            _adminRepository = adminRepository;
            _passwordHasher = passwordHasher;
        }

        public Admin Execute(string username, string password)
        {
            Admin admin = _adminRepository.FindByUsername(username);
            if (admin == null)
                throw new UnauthorizedAccessException("ユーザーが見つかりません。");

            if (!_passwordHasher.Verify(password, admin.PasswordHash))
                throw new UnauthorizedAccessException("パスワードが一致しません。");

            return admin;
        }
    }
}
