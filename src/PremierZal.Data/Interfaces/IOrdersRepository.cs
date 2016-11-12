using PremierZal.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremierZal.Data.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetAllWithSessionAsync();
    }
}