using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    class ERepuestos : IEntityTypeConfiguration<Repuestos>
    {
        public void Configure(EntityTypeBuilder<Repuestos> builder)
        {
            builder.ToTable("tb_repuestos");
            builder.HasKey(r => r.repuesto_id);
        }
    }
}
