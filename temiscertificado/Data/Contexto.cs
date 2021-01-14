
using Microsoft.EntityFrameworkCore;
using temis.Core.Models;

namespace temis.Data
{
    public class TemisContext : DbContext
    {
        public DbSet<Certificado> Certificados { get; set; }

        public TemisContext(DbContextOptions<TemisContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

    }
}
