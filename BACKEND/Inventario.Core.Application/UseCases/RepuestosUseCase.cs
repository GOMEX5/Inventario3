using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;


namespace Inventario.Core.Application.UseCases
{
    public class RepuestosUseCase : IBaseUseCase<Repuestos, Guid>
    {
        private readonly IBaseRepository<Repuestos, Guid> repository;

        public RepuestosUseCase(IBaseRepository<Repuestos, Guid> repository)
        {
            this.repository = repository;
        }

        public Repuestos Create(Repuestos entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("errorel campo no puede quedar nulo");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Repuestos> GetAll()
        {
            return repository.GetAll();
        }

        public Repuestos GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Repuestos Update(Repuestos entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}

