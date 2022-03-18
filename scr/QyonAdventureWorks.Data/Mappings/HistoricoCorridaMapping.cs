using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QyonAdventureWorks.Business.Models;

namespace QyonAdventureWorks.Data.Mappings
{
    public class HistoricoCorridaMapping : IEntityTypeConfiguration<HistoricoCorrida>
    {
        public void Configure(EntityTypeBuilder<HistoricoCorrida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(f => f.CompetidorId)
                .IsRequired()
            .HasColumnType("int");

            builder.Property(f => f.PistaCorridaId)
                .IsRequired()
            .HasColumnType("int");

            builder.Property(c => c.TempoGasto)
                .IsRequired()
                .HasColumnType("decimal");

            builder.Property(c => c.DataCorrida)
                .IsRequired()
                .HasColumnType("datetime");

            builder.HasOne(c => c.PistaCorrida)
              .WithOne(e => e.HistoricoCorrida);


            builder.ToTable("HistoricoCorridas");
        }
    }
}
