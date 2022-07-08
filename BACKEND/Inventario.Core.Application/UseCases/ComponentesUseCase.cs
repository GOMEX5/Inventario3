using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;

namespace Inventario.Core.Application.UseCases
{
    public class ComponentesUseCase : IBaseUseCase<Componentes, Guid>
    {
        private readonly IBaseRepository<Componentes, Guid> repository;

        public ComponentesUseCase(IBaseRepository<Componentes, Guid> repository)
        {
            this.repository = repository;
        }

        public Componentes Create(Componentes entity)
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

        public List<Componentes> GetAll()
        {
            return repository.GetAll();
        }

        public Componentes GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Componentes Update(Componentes entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}

