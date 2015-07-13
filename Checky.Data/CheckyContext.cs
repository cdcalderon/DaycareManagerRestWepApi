using Checky.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checky.Data
{
    public partial class CheckyContext : DbContext
    {
        public CheckyContext() : base("name=CheckyContext") { }

        public virtual DbSet<Kid> Kids { get; set; }

        public virtual DbSet<Parent> Parents { get; set; }

        public virtual DbSet<UserUnity> UserUnitys { get; set; }

        public virtual DbSet<AssistanceSheet> AssistanceSheets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kid>()
                .HasMany(e => e.Parents);

            modelBuilder.Entity<Parent>()
                .HasMany(e => e.Kids);
        }
    }
}
