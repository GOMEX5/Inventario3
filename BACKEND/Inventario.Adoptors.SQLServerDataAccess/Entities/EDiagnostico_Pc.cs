using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    public class EDiagnostico_Pc : IEntityTypeConfiguration<Diagnostico_Pc>
    {
        public void Configure(EntityTypeBuilder<Diagnostico_Pc> builder)
        {
            builder.ToTable("tb_diagnostico_pc");
            builder.HasKey(d => d.diagnostico_pc_id);
            builder.HasOne(d => d.Pc);
        }
    }
}
