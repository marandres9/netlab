using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using TP04_EntityFramework.Entity;

namespace TP04_EntityFramework.Data
{
    public partial class NorthwindContext: DbContext
    {
        public NorthwindContext()
            : base("name=NorthwindContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<Territories> Territories { get; set; }
        public virtual DbSet<Region> Region { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>()
                .Property(r => r.RegionDescription)
                .IsFixedLength();

            modelBuilder.Entity<Territories>()
                .Property(t => t.TerritoryDescription)
                .IsFixedLength();

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Territories)
                .WithRequired(e => e.Region);
        }
    }
}
