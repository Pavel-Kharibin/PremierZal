using System.Collections.Generic;
using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.Service
{
    public partial class PremierZalService
    {
        public async Task<IEnumerable<Order>> OrdersGetAllAsync()
        {
            return await _ordersRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Order>> OrdersGetAllWithSessionAsync()
        {
            return await _ordersRepository.GetAllWithSessionAsync();
        }

        public async Task<Order> OrderAddAsync(Order order)
        {
            return await _ordersRepository.AddAsync(order);
        }
    }
}