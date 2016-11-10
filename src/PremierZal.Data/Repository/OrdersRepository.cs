using PremierZal.Data.Bases;
using PremierZal.Data.Interfaces;
using PremierZal.Data.Models;

namespace PremierZal.Data.Repository
{
    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public OrdersRepository(PremierZalDbContext dbContext) : base(dbContext)
        {
        }
    }
}