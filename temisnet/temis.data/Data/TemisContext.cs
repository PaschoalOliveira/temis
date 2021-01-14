
using Microsoft.EntityFrameworkCore;
using temis.Core.Models;
using System.Collections.Generic;

namespace temis.data.Data
{
    public class TemisContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<Process> Process { get; set; }
        public DbSet<Judgment> Judgment { get; set; }
        
        public TemisContext(DbContextOptions<TemisContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Member>().ToTable("member");
            // builder.Entity<Member>().HasNoKey();
            builder.Entity<Judgment>().HasKey(p => new {p.JudgmentInstanceId, p.ProcessId});
            // builder.Entity<Member>().HasBaseType<PessoaFisica>();
        }

    }
}
