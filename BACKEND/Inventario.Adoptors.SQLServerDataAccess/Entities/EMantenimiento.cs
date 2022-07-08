using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    public class EMantenimiento : IEntityTypeConfiguration<Mantenimiento>
    {
        public void Configure(EntityTypeBuilder<Mantenimiento> builder)
        {
            builder.ToTable("tb_mantenimiento");
            builder.HasKey(m => new { m.user_id, m.lab_id});
            builder
                .HasOne(m => m.usuarios);
            builder
                .HasOne(m => m.laboratorios);

        }
    }
}