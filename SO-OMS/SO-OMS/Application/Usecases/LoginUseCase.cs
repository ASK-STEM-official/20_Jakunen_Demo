using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Security;
using System;

namespace Application.UseCases
{
    public class LoginUseCase
    {
        private readonly IAdminRepository _adminRepository;

        public LoginUseCase(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public Admin Execute(string username, string password)
        {
            Admin admin = _adminRepository.FindByUsername(username);
            if (admin == null)
                throw new UnauthorizedAccessException("ユーザーが見つかりません。");

            if (!PasswordHasher.Verify(password, admin.PasswordHash))
                throw new UnauthorizedAccessException("パスワードが一致しません。");

            return admin;
        }
    }
}
