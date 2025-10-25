using Core.Application.DTOs;

namespace Core.Application.Interfaces
{
    public interface IHomeService
    {
        Task<HomeDto> GetHomePage();
    }
}
