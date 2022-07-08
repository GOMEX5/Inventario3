using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Adoptors.SQLServerDataAccess.Entities
{
    public class EUsuarios : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("tb_Usuarios");
            builder.HasKey(u => u.user_id);
        }
    }
}
