using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QyonAdventureWorks.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QyonAdventureWorks.Data.Mappings
{
    public class PistaCorridaMapping : IEntityTypeConfiguration<PistaCorrida>
    {
        public void Configure(EntityTypeBuilder<PistaCorrida> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(c => c.Descricao)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("PistaCorridas");
        }
    }
}
