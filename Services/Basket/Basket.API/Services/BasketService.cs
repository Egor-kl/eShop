using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Basket.API.Common.Interfaces;
using Basket.API.DTO;
using Basket.API.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Basket.API.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketContext _context;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public BasketService(IMapper mapper, ILogger logger, IBasketContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));;
            _context = context ?? throw new ArgumentNullException(nameof(context));;
        }
        
        public async Task<BasketDTO> GetBasketById(int id)
        {
           var model = await _context.Baskets.FirstOrDefaultAsync(x => x.Id == id);
           
           if (model == null)
           {
               _logger.Error("Basket cannot be null. Get basket by id");
               return null;
           }

           var basketDTO = _mapper.Map<Models.Basket, BasketDTO>(model);

           return basketDTO;
        }

        public async Task<ChrckoutDTO> GetCheckoutById(int id)
        {
            var model = await _context.Checkouts.FirstOrDefaultAsync(x => x.Id == id);
           
            if (model == null)
            {
                _logger.Error("Checkout cannot be null. Get checkout by id");
                return null;
            }

            var checkoutDTO = _mapper.Map<Checkout, ChrckoutDTO>(model);
            
            return checkoutDTO;
        }

        public async Task<bool> UpdateBasket(BasketDTO basketDTO)
        {
            var modelDTO = _mapper.Map<BasketDTO, Models.Basket>(basketDTO);
            var basket = await _context.Baskets.FirstOrDefaultAsync(x => x.Id == basketDTO.Id);
            
            if (basket == null)
            {
                _logger.Error("Basket cannot be null. Update basket");
                return false;
            }

            _context.Update(modelDTO);
            await _context.SaveChangesAsync(new CancellationToken());

            return true;
        }
    }
}