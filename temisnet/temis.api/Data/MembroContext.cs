using Microsoft.EntityFrameworkCore;
using temis.api.Models;

namespace temis.api.Data
{
    public class MembroContext : DbContext
    {
        public DbSet<Membro> membros { get; set; }
        
        public DbSet<Processo> processos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=EFCoreWebDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}