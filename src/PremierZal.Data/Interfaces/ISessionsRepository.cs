using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.Data.Interfaces
{
    public interface ISessionsRepository : IRepository<Session>
    {
        Task DeleteAsync(int id);
    }
}