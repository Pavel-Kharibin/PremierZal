using System.Collections.Generic;
using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.Service.Interfaces
{
    public partial interface IPrimierZalService
    {
        Task<IEnumerable<Order>> OrdersGetAllAsync();
        Task<IEnumerable<Order>> OrdersGetAllWithSessionAsync();
        Task<Order> OrderAddAsync(Order order);
    }
}