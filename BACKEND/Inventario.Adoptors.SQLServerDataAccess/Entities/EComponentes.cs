using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    public class EComponentes : IEntityTypeConfiguration<Componentes>
    {
        public void Configure(EntityTypeBuilder<Componentes> builder)
        {
            builder.ToTable("tb_componentes");
            builder.HasKey(c => c.componenete_id);
            builder
                .HasOne(c => c.pc);
        }
    }
}
