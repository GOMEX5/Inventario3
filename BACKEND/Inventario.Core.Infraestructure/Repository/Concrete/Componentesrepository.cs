using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;
namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Componentesrepository : IBaseRepository<Componentes, Guid>
    {

        private InventarioDB db;

        public Componentesrepository(InventarioDB db)
        {
            this.db = db;
        }

        public Componentes Create(Componentes componentes)
        {
            componentes.componenete_id = Guid.NewGuid();
            db.Componentes.Add(componentes);
            return componentes;
        }

        public void Delete(Guid entityId)
        {
            var selectedComponentes = db.Componentes
                .Where(u => u.componenete_id== entityId).FirstOrDefault();
            if (selectedComponentes != null)
                db.Componentes.Remove(selectedComponentes);
        }

        public List<Componentes> GetAll()
        {
            return db.Componentes.ToList();
        }

        public Componentes GetById(Guid entityId)
        {
            var selectedComponente = db.Componentes
                .Where(u => u.componenete_id == entityId).FirstOrDefault();
            return selectedComponente;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Componentes Update(Componentes componentes)
        {
            var selectedComponente = db.Componentes
                .Where(u => u.componenete_id == componentes.componenete_id)
                .FirstOrDefault();
            if (selectedComponente != null)
            {
                selectedComponente.tipo = componentes.tipo;
                selectedComponente.marca = componentes.marca;
                selectedComponente.pc = componentes.pc;
                selectedComponente.estado = componentes.estado;
                selectedComponente.modelo= componentes.modelo;


                db.Entry(selectedComponente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedComponente;

        }
    }
}