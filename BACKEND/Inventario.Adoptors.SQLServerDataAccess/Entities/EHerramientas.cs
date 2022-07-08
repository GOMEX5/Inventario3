using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    class EHerramientas : IEntityTypeConfiguration<Herramientas>
    {
        public void Configure(EntityTypeBuilder<Herramientas> builder)
        {
            builder.ToTable("tb_herramientas");
            builder.HasKey(h => h.herramienta_id);
            builder
                .HasOne(h => h.usuarios);
        }
    }
}
