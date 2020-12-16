
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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("member_tbl");
            builder.Entity<User>().HasNoKey();
            builder.Entity<User>().Property(t => t.Id).HasColumnName("Id");

        }

    }
}
