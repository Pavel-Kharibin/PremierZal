using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PremierZal.Data.Bases
{
    public abstract class RepositoryBase<T> where T : class 
    {
        protected RepositoryBase(PremierZalDbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        public async Task<T> AddAsync(T model)
        {
            DbSet.Add(model);
            await DbContext.SaveChangesAsync();

            return model;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public async Task SaveAsync(T model)
        {
            DbSet.Attach(model);
            DbContext.Entry(model).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        protected DbSet<T> DbSet { get; }
        protected PremierZalDbContext DbContext { get; }
    }
}