using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Laboratoriorepository : IBaseRepository<Laboratorios, Guid>
    {
        private InventarioDB db;

        public Laboratoriorepository(InventarioDB db)
        {
            this.db = db;
        }

        public Laboratorios Create(Laboratorios laboratorios)
        {
            laboratorios.lab_id = Guid.NewGuid();
            db.Laboratorios.Add(laboratorios);
            return laboratorios;
        }

        public void Delete(Guid entityId)
        {
            var selectedLaboratorios = db.Laboratorios
                .Where(u => u.lab_id == entityId).FirstOrDefault();
            if (selectedLaboratorios != null)
                db.Laboratorios.Remove(selectedLaboratorios);
        }

        public List<Laboratorios> GetAll()
        {
            return db.Laboratorios.ToList();
        }

        public Laboratorios GetById(Guid entityId)
        {
            var selectedLaboratorio = db.Laboratorios
                .Where(u => u.lab_id == entityId).FirstOrDefault();
            return selectedLaboratorio;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Laboratorios Update(Laboratorios laboratorios)
        {
            var selectedLaboratorio = db.Laboratorios
                .Where(u => u.lab_id == laboratorios.lab_id)
                .FirstOrDefault();
            if (selectedLaboratorio != null)
            {
                selectedLaboratorio.num_pc = laboratorios.num_pc;
                selectedLaboratorio.Estado = laboratorios.Estado;
                selectedLaboratorio.created_at = DateTime.Now;
                selectedLaboratorio.updated_at = DateTime.Now;

                db.Entry(selectedLaboratorio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedLaboratorio;

        }
    }
}