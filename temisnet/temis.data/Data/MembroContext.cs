
using Microsoft.EntityFrameworkCore;
using temis.Core.Models;

namespace temis.data.Data
{
    public class MembroContext : DbContext
    {
        public DbSet<User> membros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=.\;Database=EFCoreWebDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
