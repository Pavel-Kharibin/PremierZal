using System.Collections.Generic;
using System.Threading.Tasks;
using PremierZal.Common.Models;

namespace PremierZal.Service
{
    public partial class PremierZalService
    {
        public async Task<IEnumerable<Session>> SessionsGetAllAsync()
        {
            return await _sessionsRepositoty.GetAllAsync();
        }

        public async Task<Session> SessionAddAsync(Session session)
        {
            return await _sessionsRepositoty.AddAsync(session);
        }

        public async Task<Session> SessionSaveAsync(Session session)
        {
            return await _sessionsRepositoty.SaveAsync(session);
        }

        public async Task SessionDeleteAsync(int id)
        {
            await _sessionsRepositoty.DeleteAsync(id);
        }
    }
}