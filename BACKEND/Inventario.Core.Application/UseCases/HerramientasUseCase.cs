using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;

namespace Inventario.Core.Application.UseCases
{
    public class HerramientasUseCase : IBaseUseCase<Herramientas, Guid>
    {
        private readonly IBaseRepository<Herramientas, Guid> repository;

        public HerramientasUseCase(IBaseRepository<Herramientas, Guid> repository)
        {
            this.repository = repository;
        }

        public Herramientas Create(Herramientas entity)
        {
            if (entity != null)
            {
                var result = repository.Create(entity);
                repository.SaveAllChanges();
                return result;
            }
            else
                throw new Exception("error el campo no puede quedar basio");
        }

        public void Delete(Guid entityId)
        {
            repository.Delete(entityId);
            repository.SaveAllChanges();
        }

        public List<Herramientas> GetAll()
        {
            return repository.GetAll();
        }

        public Herramientas GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Herramientas Update(Herramientas entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}

