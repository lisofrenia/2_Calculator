using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class CalculatorContext : DbContext
    {
        public DbSet<DataInputVarian> DataInputVarians { get; set; }

        public CalculatorContext(DbContextOptions<CalculatorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
        }
    }
}
