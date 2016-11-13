using System.Collections.Generic;
using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.Service.Interfaces
{
    public partial interface IPrimierZalService
    {
        Task<IEnumerable<Session>> SessionsGetAllAsync();
        Task<Session> SessionAddAsync(Session session);
        Task<Session> SessionSaveAsync(Session session);
        Task SessionDeleteAsync(int id);
    }
}