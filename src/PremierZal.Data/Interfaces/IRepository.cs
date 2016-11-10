using System.Threading.Tasks;

namespace PremierZal.Data.Interfaces
{
    public interface IRepository<in T> where T : class
    {
        Task SaveAsync(T model);
    }
}