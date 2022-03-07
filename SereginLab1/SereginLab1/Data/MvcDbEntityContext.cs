using Microsoft.EntityFrameworkCore;
using SereginLab1.Models;

namespace SereginLab1.Data
{
    public class MvcDbEntityContext : DbContext
    {
        public MvcDbEntityContext(DbContextOptions<MvcDbEntityContext> options)
            : base(options)
        {
        }

        public DbSet<DbEntity> DbEntity { get; set; }
    }
}