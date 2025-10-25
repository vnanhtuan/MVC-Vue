using Core.Application.DTOs;

namespace Core.Application.Interfaces
{
    public interface IShopService
    {
        Task<ShopDto> GetShopAsync();
    }
}
