using System.Threading.Tasks;
using Aksel.Models.Entities;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Aksel.Repository
{
    public class AkselRepository : IAkselRepository
    {
        private readonly AkselDbContext _context;

        public AkselRepository(AkselDbContext context)
        {
            _context = context;
        }

        public async Task<AkselEntity> AddAsync(AkselEntity entity)
        {
            EntityEntry<AkselEntity> entityEntry = await _context.Aksel.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task<AkselEntity> GetAsync(long id)
        {
            AkselEntity entity = await _context.Aksel.FirstOrDefaultAsync(m=> m.Id.Equals(id));
            
            return entity;
        }

        public async Task UpdateAsync(AkselEntity entity)
        {
            _context.Aksel.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}