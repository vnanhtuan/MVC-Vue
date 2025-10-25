using Core.Application.Common;
using Core.Application.DTOs;
using Core.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IAppDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(IAppDbContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            // 1. Find user
            var user = await _context.User.FirstOrDefaultAsync(m => m.UserName == loginDto.Username);
            if (user == null)
                return null;

            // 2. Check password
            if (!Utility.VerifyPasswordHash(loginDto.Password, user.PasswordHash, user.PasswordKey))
                return null;

            // 3. Generate token
            var token = _tokenService.GenerateJwtToken(user);

            return token;
        }
    }
}
