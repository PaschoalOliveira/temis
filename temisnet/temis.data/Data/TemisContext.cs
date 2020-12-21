
using Microsoft.EntityFrameworkCore;
using temis.Core.Models;

namespace temis.data.Data
{
    public class TemisContext : DbContext
    {
        public DbSet<Member> Membros { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Judgment> Judgment { get; set; }
        
        public TemisContext(DbContextOptions<TemisContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Member>().ToTable("member");
            builder.Entity<Member>().HasNoKey();
            builder.Entity<Member>().Property(t => t.Id).HasColumnName("Id");
            builder.Entity<Judgment>().HasNoKey();


        }

    }
}
