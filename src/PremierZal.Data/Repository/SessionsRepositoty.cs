using System.Data.Entity;
using System.Threading.Tasks;
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

        public async Task DeleteAsync(int id)
        {
            var model = await DbSet.FirstOrDefaultAsync(m => m.Id.Equals(id));

            DbSet.Remove(model);
            await DbContext.SaveChangesAsync();
        }
    }
}