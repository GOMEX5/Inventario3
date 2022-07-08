using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Inventario.Adoptors.SQLServerDataAccess.Entities;
using Inventario.Adoptors.SQLServerDataAccess.Utils;


namespace Inventario.Adoptors.SQLServerDataAccess.Contexts
{
    public class InventarioDB : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Repuestos> Repuestos { get; set; }
        public DbSet<Pc> Pc { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }
        public DbSet<Laboratorios> Laboratorios { get; set; }
        public DbSet<Herramientas> Herramientas { get; set; }
        public DbSet<Diagnostico_Pc> Diagnostico_Pc { get; set; }
        public DbSet<Componentes> Componentes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EUsuarios());
            modelBuilder.ApplyConfiguration(new ELaboratorios());
            modelBuilder.ApplyConfiguration(new EPc());
            modelBuilder.ApplyConfiguration(new ERepuestos());
            modelBuilder.ApplyConfiguration(new EComponentes());
            modelBuilder.ApplyConfiguration(new EDiagnostico_Pc());
            modelBuilder.ApplyConfiguration(new EHerramientas());
            modelBuilder.ApplyConfiguration(new EMantenimiento());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GlobalSetting.SqlServerConnectionString);
        }
    }


}
