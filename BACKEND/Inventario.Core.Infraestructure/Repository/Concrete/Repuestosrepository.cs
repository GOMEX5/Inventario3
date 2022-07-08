using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Repuestosrepository : IBaseRepository<Repuestos, Guid>
    {
        private InventarioDB db;

        public Repuestosrepository(InventarioDB db)
        {
            this.db = db;
        }

        public Repuestos Create(Repuestos repuestos)
        {
            repuestos.repuesto_id = Guid.NewGuid();
            db.Repuestos.Add(repuestos);
            return repuestos;
        }

        public void Delete(Guid entityId)
        {
            var selectedRepuestos = db.Repuestos
                .Where(u => u.repuesto_id == entityId).FirstOrDefault();
            if (selectedRepuestos != null)
                db.Repuestos.Remove(selectedRepuestos);
        }

        public List<Repuestos> GetAll()
        {
            return db.Repuestos.ToList();
        }

        public Repuestos GetById(Guid entityId)
        {
            var selectedRepuestos = db.Repuestos
                .Where(u => u.repuesto_id == entityId).FirstOrDefault();
            return selectedRepuestos;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Repuestos Update(Repuestos repuestos)
        {
            var selectedRepuestos = db.Repuestos
                .Where(u => u.repuesto_id == repuestos.repuesto_id)
                .FirstOrDefault();
            if (selectedRepuestos != null)
            {
                selectedRepuestos.nombre = repuestos.nombre;
                selectedRepuestos.serie = repuestos.serie;
                selectedRepuestos.estado = repuestos.estado;
                selectedRepuestos.cantidad = repuestos.cantidad;
                selectedRepuestos.info = repuestos.info;
                selectedRepuestos.created_at = DateTime.Now;
                selectedRepuestos.updated_at = DateTime.Now;
                db.Entry(selectedRepuestos).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedRepuestos;

        }
    }
}