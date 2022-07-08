using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    public class ELaboratorios : IEntityTypeConfiguration<Laboratorios>
    {
        public void Configure(EntityTypeBuilder<Laboratorios> builder)
        {
            builder.ToTable("tab_Laboratorios");
            builder.HasKey(l => l.lab_id);

        }
    }

}
