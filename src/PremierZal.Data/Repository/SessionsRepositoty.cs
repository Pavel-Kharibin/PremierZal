using PremierZal.Common.Models;
using PremierZal.Data.Bases;
using PremierZal.Data.Interfaces;

namespace PremierZal.Data.Repository
{
    public class SessionsRepositoty : RepositoryBase<Session>, ISessionsRepository
    {
        public SessionsRepositoty(PremierZalDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}