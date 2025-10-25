using Core.Domain.Entities;

namespace Core.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
    }
}
