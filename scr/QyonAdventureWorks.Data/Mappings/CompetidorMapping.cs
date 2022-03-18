using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QyonAdventureWorks.Business.Models;

namespace QyonAdventureWorks.Data.Mappings
{
    public class CompetidorMapping : IEntityTypeConfiguration<Competidor>
    {
        public void Configure(EntityTypeBuilder<Competidor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(c => c.Sexo)
                .IsRequired()
                .HasColumnType("char(1)");

            builder.Property(c => c.TemperaturaMediaCorpo)
               .IsRequired()
               .HasColumnType("decimal");

            builder.Property(c => c.Peso)
              .IsRequired()
              .HasColumnType("decimal");

            builder.Property(c => c.Altura)
              .IsRequired()
              .HasColumnType("decimal");

            builder.HasMany(h => h.HistoricoCorridas)
                .WithOne(c => c.Competidor)
                .HasForeignKey(c => c.CompetidorId);

            builder.ToTable("Competidores");
        }
    }
}
