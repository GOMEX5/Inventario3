using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;


namespace Inventario.Core.Application.UseCases
{
    public class MantenimientoUseCase : IBaseUseCase<Mantenimiento, Guid>
    {
        private readonly IBaseRepository<Mantenimiento, Guid> repository;

        public MantenimientoUseCase(IBaseRepository<Mantenimiento, Guid> repository)
        {
            this.repository = repository;
        }

        public Mantenimiento Create(Mantenimiento entity)
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

        public List<Mantenimiento> GetAll()
        {
            return repository.GetAll();
        }

        public Mantenimiento GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Mantenimiento Update(Mantenimiento entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }
}