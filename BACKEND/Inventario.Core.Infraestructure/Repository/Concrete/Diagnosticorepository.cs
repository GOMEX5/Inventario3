using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;
namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Diagnosticorepository : IBaseRepository<Diagnostico_Pc, Guid>
    {

        private InventarioDB db;

        public Diagnosticorepository(InventarioDB db)
        {
            this.db = db;
        }

        public Diagnostico_Pc Create(Diagnostico_Pc diagnostico_Pc)
        {
            diagnostico_Pc.diagnostico_pc_id = Guid.NewGuid();
            db.Diagnostico_Pc.Add(diagnostico_Pc);
            return diagnostico_Pc;
        }

        public void Delete(Guid entityId)
        {
            var selectedDiagnostico_pc = db.Diagnostico_Pc
                .Where(u => u.diagnostico_pc_id == entityId).FirstOrDefault();
            if (selectedDiagnostico_pc != null)
                db.Diagnostico_Pc.Remove(selectedDiagnostico_pc);
        }

        public List<Diagnostico_Pc> GetAll()
        {
            return db.Diagnostico_Pc.ToList();
        }

        public Diagnostico_Pc GetById(Guid entityId)
        {
            var selectedDiagnostico_Pc = db.Diagnostico_Pc
                .Where(u => u.diagnostico_pc_id == entityId).FirstOrDefault();
            return selectedDiagnostico_Pc;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Diagnostico_Pc Update(Diagnostico_Pc diagnostico_Pc)
        {
            var selectedDiagnostico_Pc = db.Diagnostico_Pc
                .Where(u => u.diagnostico_pc_id == diagnostico_Pc.diagnostico_pc_id)
                .FirstOrDefault();
            if (selectedDiagnostico_Pc != null)
            {
                selectedDiagnostico_Pc.Pc = diagnostico_Pc.Pc;
                selectedDiagnostico_Pc.estado = diagnostico_Pc.estado;
                selectedDiagnostico_Pc.updated_at = DateTime.Now;
                selectedDiagnostico_Pc.detalle = diagnostico_Pc.detalle;
                selectedDiagnostico_Pc.soluccion_asignada = diagnostico_Pc.soluccion_asignada;
                selectedDiagnostico_Pc.created_at = diagnostico_Pc.created_at;

                selectedDiagnostico_Pc.fecha_hora = DateTime.Now;
                db.Entry(selectedDiagnostico_Pc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedDiagnostico_Pc;

        }
    }
}