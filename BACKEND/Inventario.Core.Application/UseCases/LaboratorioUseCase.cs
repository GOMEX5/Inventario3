using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;

namespace Inventario.Core.Application.UseCases
{
    public class LaboratorioUseCase : IBaseUseCase<Laboratorios, Guid>
    {
        private readonly IBaseRepository<Laboratorios, Guid> repository;

        public LaboratorioUseCase(IBaseRepository<Laboratorios, Guid> repository)
        {
            this.repository = repository;
        }

        public Laboratorios Create(Laboratorios entity)
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

        public List<Laboratorios> GetAll()
        {
            return repository.GetAll();
        }

        public Laboratorios GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Laboratorios Update(Laboratorios entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}

