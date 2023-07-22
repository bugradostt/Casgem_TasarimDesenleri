using Microsoft.EntityFrameworkCore;

namespace Casgem_ChainOfResponsibility.Dal
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=BUDOTEKNO\\SQLEXPRESS ; initial Catalog=CasgemChainResDb; integrated Security=true");

        }

            public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
    
}
