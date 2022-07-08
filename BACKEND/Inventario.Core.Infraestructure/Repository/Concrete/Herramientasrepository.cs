using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Herramientasrepository : IBaseRepository<Herramientas, Guid>
    {
        private InventarioDB db;

        public Herramientasrepository(InventarioDB db)
        {
            this.db = db;
        }

        public Herramientas Create(Herramientas herramientas)
        {
            herramientas.herramienta_id = Guid.NewGuid();
            db.Herramientas.Add(herramientas);
            return herramientas;
        }

        public void Delete(Guid entityId)
        {
            var selectedHerramientas = db.Herramientas
                .Where(u => u.herramienta_id == entityId).FirstOrDefault();
            if (selectedHerramientas != null)
                db.Herramientas.Remove(selectedHerramientas);
        }

        public List<Herramientas> GetAll()
        {
            return db.Herramientas.ToList();
        }

        public Herramientas GetById(Guid entityId)
        {
            var selectedHerramientas = db.Herramientas
                .Where(u => u.herramienta_id == entityId).FirstOrDefault();
            return selectedHerramientas;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Herramientas Update(Herramientas herramientas)
        {
            var selectedHerramientas = db.Herramientas
                .Where(u => u.herramienta_id == herramientas.herramienta_id)
                .FirstOrDefault();
            if (selectedHerramientas != null)
            {
                selectedHerramientas.nombre = herramientas.nombre;
                selectedHerramientas.tipo = herramientas.tipo;
                selectedHerramientas.estado = herramientas.estado;
                selectedHerramientas.cantidad = herramientas.cantidad;
                selectedHerramientas.usuarios = herramientas.usuarios;
                selectedHerramientas.created_at = DateTime.Now;
                selectedHerramientas.updated_at = DateTime.Now;
                db.Entry(selectedHerramientas).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedHerramientas;

        }
    }
}