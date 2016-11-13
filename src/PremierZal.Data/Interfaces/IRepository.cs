using System.Collections.Generic;
using System.Threading.Tasks;

namespace PremierZal.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T model);
        Task<T> SaveAsync(T model);
        Task<IEnumerable<T>> GetAllAsync();
    }
}