using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;
namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Pcrepository : IBaseRepository<Pc, Guid>
    {

        private InventarioDB db;

        public Pcrepository (InventarioDB db)
        {
            this.db = db;
        }

        public Pc Create(Pc pc)
        {
            pc.pc_id = Guid.NewGuid();
            db.Pc.Add(pc);
            return pc;
        }

        public void Delete(Guid entityId)
        {
            var selectedPc = db.Pc
                .Where(u => u.pc_id == entityId).FirstOrDefault();
            if (selectedPc != null)
                db.Pc.Remove(selectedPc);
        }

        public List<Pc> GetAll()
        {
            return db.Pc.ToList();
        }

        public Pc GetById(Guid entityId)
        {
            var selectedUser = db.Pc
                .Where(u => u.pc_id == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Pc Update(Pc pc)
        {
            var selectedPc = db.Pc
                .Where(u => u.pc_id == pc.pc_id)
                .FirstOrDefault();
            if (selectedPc != null)
            {
                selectedPc.modelo = pc.modelo;
                selectedPc.lab_id = pc.lab_id;
                
               
                db.Entry(selectedPc).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedPc;

        }
    }
}
