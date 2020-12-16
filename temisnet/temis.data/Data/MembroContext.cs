
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using temis.Core.Models;

namespace temis.data.Data
{
    public class MembroContext : DbContext
    {
        public DbSet<User> Membros { get; set; }
        public MembroContext(DbContextOptions<MembroContext> options) : base(options)
        {
            
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)

        {​​

            base.OnModelCreating(modelBuilder);

        }​​

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=151.106.96.101;Port=3306;Database=u590093429_temis;Uid=u590093429_temisuser;Pwd=TemisUser1;");
        }*/
    }
}
