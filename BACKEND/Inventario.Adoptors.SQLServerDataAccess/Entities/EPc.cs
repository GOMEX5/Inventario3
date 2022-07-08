using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    public class EPc : IEntityTypeConfiguration<Pc>
    {
        public void Configure(EntityTypeBuilder<Pc> builder)
        {
            builder.ToTable("tb_pc");
            builder.HasKey(p => p.pc_id);
            builder
                .HasOne(p => p.lab_id);
        }
    }
}
