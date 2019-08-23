using System.Threading.Tasks;
using Aksel.Models.Entities;
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

        public async Task<UserEntity> GetAsync(string email, string password)
        {
            var user = await _context.UserEntity.FirstOrDefaultAsync(m => m.Email.Equals(email) && m.Password.Equals(password) && m.IsActive);

            return user;
        }
    }
}