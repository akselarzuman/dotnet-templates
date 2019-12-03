using System.Threading.Tasks;
using Aksel.Models.Entities;

namespace Aksel.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<UserEntity> GetAsync(string email);
    }
}