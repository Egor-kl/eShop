using System.Threading.Tasks;
using Basket.API.DTO;
using Basket.API.Models;

namespace Basket.API.Common.Interfaces
{
    public interface IBasketService
    {
        Task<BasketDTO> GetBasketById(int id);
        Task<ChrckoutDTO> GetCheckoutById(int id);
        Task<bool> UpdateBasket(BasketDTO basket);
        Task<bool> AddCheckoutForBasket(ChrckoutDTO checkout);
    }
}