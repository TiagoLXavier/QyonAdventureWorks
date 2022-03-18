using Microsoft.EntityFrameworkCore;
using QyonAdventureWorks.Business.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }
        public DbSet<Competidor> Competidores { get; set; }
        public DbSet<HistoricoCorrida> HistoricoCorridas { get; set; }
        public DbSet<PistaCorrida> PistaCorridas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCorrida") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCorrida").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCorrida").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
