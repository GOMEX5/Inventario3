using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;


namespace Inventario.Core.Application.UseCases
{
    public class PcUseCase : IBaseUseCase<Pc, Guid>
    {
        private readonly IBaseRepository<Pc, Guid> repository;

        public PcUseCase(IBaseRepository<Pc, Guid> repository)
        {
            this.repository = repository;
        }

        public Pc Create(Pc entity)
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

        public List<Pc> GetAll()
        {
            return repository.GetAll();
        }

        public Pc GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Pc Update(Pc entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}
