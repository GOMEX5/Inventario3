using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;

namespace Inventario.Core.Application.UseCases
{
    public class UsuariosUseCase : IBaseUseCase<Usuarios, Guid>
    {
        private readonly IBaseRepository<Usuarios, Guid> repository;

        public UsuariosUseCase(IBaseRepository<Usuarios, Guid> repository)
        {
            this.repository = repository;
        }

        public Usuarios Create(Usuarios entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("error el usuario no puede ser nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Usuarios> GetAll()
        {
            return repository.GetAll();
        }

        public Usuarios GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Usuarios Update(Usuarios entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
