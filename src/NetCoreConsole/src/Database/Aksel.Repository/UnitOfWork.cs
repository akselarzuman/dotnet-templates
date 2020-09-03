using System;
using System.Threading.Tasks;
using Aksel.Repository.Context;
using Aksel.Repository.Contracts;

namespace Aksel.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AkselDbContext _context;

        public UnitOfWork(AkselDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}