using ELSA.Demo.Workflow.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELSA.Demo.Workflow.DataAccess
{
    public class ElsaDemoDbContext : DbContext
    {
        public ElsaDemoDbContext(DbContextOptions<ElsaDemoDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
