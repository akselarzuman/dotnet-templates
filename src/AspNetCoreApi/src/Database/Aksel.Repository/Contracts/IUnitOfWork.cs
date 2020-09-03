using System.Threading.Tasks;

namespace Aksel.Repository.Contracts
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}