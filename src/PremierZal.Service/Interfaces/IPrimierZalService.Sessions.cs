using System.Collections.Generic;
using System.Threading.Tasks;
using PremierZal.Data.Models;

namespace PremierZal.Service.Interfaces
{
    public partial interface IPrimierZalService
    {
        Task<IEnumerable<Session>> SessionsGetAllAsync();
        Task<Session> SessionAddAsync(Session session);
        Task SessionSaveAsync(Session session);
    }
}