using System.Threading.Tasks;
using Aksel.Models.Entities;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Aksel.Repository
{
    public class AkselRepository : IAkselRepository
    {
        private readonly AkselDbContext _context;

        public AkselRepository(AkselDbContext context)
        {
            _context = context;
        }
        public async Task<AkselEntity> GetAsync()
        {
            AkselEntity entity = await _context.Aksel.FirstOrDefaultAsync();
            return entity;
        }
    }
}