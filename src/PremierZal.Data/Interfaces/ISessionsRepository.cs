using System.Collections.Generic;
using System.Threading.Tasks;
using PremierZal.Data.Models;

namespace PremierZal.Data.Interfaces
{
    public interface ISessionsRepository : IRepository<Session>
    {
        Task<IEnumerable<Session>> GetAllAsync();
        Task<Session> AddAsync(Session session);
    }
}