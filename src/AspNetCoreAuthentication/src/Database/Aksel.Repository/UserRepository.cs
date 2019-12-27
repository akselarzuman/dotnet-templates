using System.Threading.Tasks;
using Aksel.Repository.Entities;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Aksel.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AkselDbContext _context;

        public UserRepository(AkselDbContext context)
        {
            _context = context;
        }

        public Task<UserEntity> GetAsync(string email)
        {
            Task<UserEntity> user = _context.UserEntity.FirstOrDefaultAsync(m => m.Email.Equals(email) && m.IsActive);

            return user;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}