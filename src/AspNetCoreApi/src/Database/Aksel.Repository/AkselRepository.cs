using System.Threading.Tasks;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;
using Aksel.Repository.Entities;
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

        public ValueTask<EntityEntry<AkselEntity>> AddAsync(AkselEntity entity)
        {
            ValueTask<EntityEntry<AkselEntity>> entityEntry = _context.Aksel.AddAsync(entity);
            
            return entityEntry;
        }

        public Task<AkselEntity> GetAsync(long id)
        {
            Task<AkselEntity> entity = _context.Aksel.FirstOrDefaultAsync(m=> m.Id.Equals(id));
            
            return entity;
        }

        public EntityEntry<AkselEntity> Update(AkselEntity entity)
        {
            return _context.Aksel.Update(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}