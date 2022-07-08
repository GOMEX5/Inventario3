using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Mantenimientorepository : IBaseRepository<Mantenimiento, Guid>
    {
        private InventarioDB db;

        public Mantenimientorepository(InventarioDB db)
        {
            this.db = db;
        }

        public Mantenimiento Create(Mantenimiento mantenimiento)
        {
            mantenimiento.user_id = Guid.NewGuid();
            db.Mantenimiento.Add(mantenimiento);
            return mantenimiento;
        }

        public void Delete(Guid entityId)
        {
            var selectedMantenimiento = db.Mantenimiento
                .Where(u => u.user_id == entityId).FirstOrDefault();
            if (selectedMantenimiento != null)
                db.Mantenimiento.Remove(selectedMantenimiento);
        }

        public List<Mantenimiento> GetAll()
        {
            return db.Mantenimiento.ToList();
        }

        public Mantenimiento GetById(Guid entityId)
        {
            var selectedMantenimiento = db.Mantenimiento
                .Where(u => u.user_id == entityId).FirstOrDefault();
            return selectedMantenimiento;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Mantenimiento Update(Mantenimiento mantenimiento)
        {
            var selectedMantenimiento = db.Mantenimiento
                .Where(u => u.user_id == mantenimiento.user_id)
                .FirstOrDefault();
            if (selectedMantenimiento != null)
            {
                selectedMantenimiento.lab_id = mantenimiento.lab_id;
                selectedMantenimiento.user_id= mantenimiento.user_id;
                selectedMantenimiento.fecha = DateTime.Now;
                selectedMantenimiento.info = mantenimiento.info;


                db.Entry(selectedMantenimiento).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedMantenimiento;

        }
    }
}