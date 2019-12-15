using Aksel.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aksel.Repository.Context
{
    public class AkselDbContext : DbContext
    {
        public AkselDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserEntity> UserEntity { get; set; }
    }
}