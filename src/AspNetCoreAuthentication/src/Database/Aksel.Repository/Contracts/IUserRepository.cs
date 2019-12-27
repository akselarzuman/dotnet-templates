using System.Threading.Tasks;
using Aksel.Repository.Entities;

namespace Aksel.Repository.Contracts
{
    public interface IUserRepository : IRepository
    {
        Task<UserEntity> GetAsync(string email);
    }
}