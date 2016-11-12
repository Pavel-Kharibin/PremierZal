using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using PremierZal.Common.Models;
using PremierZal.Data.Bases;
using PremierZal.Data.Interfaces;

namespace PremierZal.Data.Repository
{
    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public OrdersRepository(PremierZalDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Order>> GetAllWithSessionAsync()
        {
            var orders = await DbSet.OrderByDescending(o => o.Sold).Include(o => o.Session).ToListAsync();

            return orders;
        }
    }
}