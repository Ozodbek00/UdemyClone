using Microsoft.EntityFrameworkCore;
using Udemy.Domain.Entities;

namespace Udemy.Data.DbContexts
{
    public class UdemyDbContext : DbContext
    {
        public UdemyDbContext(DbContextOptions<UdemyDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
