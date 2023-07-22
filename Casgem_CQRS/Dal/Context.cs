using Microsoft.EntityFrameworkCore;

namespace Casgem_CQRS.Dal
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BUDOTEKNO\\SQLEXPRESS ; initial Catalog=CasgemCQRSDb; integrated Security=true");

        }

        public DbSet<Product> Products{ get; set; }
    }
}
