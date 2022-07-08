using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Infraestructure.Repository.Abstract;
using Inventario.Adoptors.SQLServerDataAccess.Contexts;
using System.Linq;

namespace Inventario.Core.Infraestructure.Repository.Concrete
{
    public class Usuariorepository : IBaseRepository<Usuarios, Guid>
    {
        private InventarioDB db;

        public Usuariorepository(InventarioDB db) {
            this.db = db;
        }

        public Usuarios Create(Usuarios usuarios)
        {
            usuarios.user_id = Guid.NewGuid();
            db.Usuarios.Add(usuarios);
            return usuarios;
        }

        public void Delete(Guid entityId)
        {
            var selectedUser = db.Usuarios
                .Where(u => u.user_id == entityId).FirstOrDefault();
            if (selectedUser != null)
                db.Usuarios.Remove(selectedUser);
        }

        public List<Usuarios> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public Usuarios GetById(Guid entityId)
        {
            var selectedUser = db.Usuarios
                .Where(u => u.user_id == entityId).FirstOrDefault();
            return selectedUser;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }

        public Usuarios Update(Usuarios usuarios)
        {
            var selectedUser = db.Usuarios
                .Where(u => u.user_id == usuarios.user_id)
                .FirstOrDefault();
            if (selectedUser != null) 
            {
                selectedUser.nombre = usuarios.nombre;
                selectedUser.apellido = usuarios.apellido;
                selectedUser.cargo = usuarios.cargo;
                selectedUser.telefono = usuarios.telefono;
                selectedUser.direccion = usuarios.direccion;
                selectedUser.correo = usuarios.correo;
                selectedUser.password = usuarios.password;
                selectedUser.updated_at = DateTime.Now;
                db.Entry(selectedUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            return selectedUser;

        }
    }
}
