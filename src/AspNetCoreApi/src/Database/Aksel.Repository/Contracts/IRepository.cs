using System.Threading.Tasks;

namespace Aksel.Repository.Contracts
{
    public interface IRepository
    {
        Task<int> SaveChangesAsync();
    }
}