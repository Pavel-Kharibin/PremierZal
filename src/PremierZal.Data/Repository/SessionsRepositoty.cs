using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using PremierZal.Data.Bases;
using PremierZal.Data.Interfaces;
using PremierZal.Data.Models;

namespace PremierZal.Data.Repository
{
    public class SessionsRepositoty : RepositoryBase<Session>, ISessionsRepository
    {
        public SessionsRepositoty(PremierZalDbContext dbContext) : base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Session> AddAsync(Session session)
        {
            DbSet.Add(session);
            await DbContext.SaveChangesAsync();

            return session;
        }
    }
}