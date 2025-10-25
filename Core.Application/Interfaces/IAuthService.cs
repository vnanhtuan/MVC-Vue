using Core.Application.DTOs;

namespace Core.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string?> LoginAsync(LoginDto loginDto);
    }
}
