
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore;
using temis.Core.Models;

namespace temis.data.Data
{
    public class MembroContext : DbContext
    {
        public DbSet<Member> Membros { get; set; }
        public MembroContext(DbContextOptions<MembroContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>().ToTable("member");
            builder.Entity<Member>().HasNoKey();
            builder.Entity<Member>().Property(t => t.Id).HasColumnName("Id");

        }

    }
}
