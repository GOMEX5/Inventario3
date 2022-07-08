using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Models;
using Inventario.Core.Application.Interfaces;
using Inventario.Core.Infraestructure.Repository.Abstract;

namespace Inventario.Core.Application.UseCases
{
    public class DiagnosticoUseCase : IBaseUseCase<Diagnostico_Pc, Guid>
    {
        private readonly IBaseRepository<Diagnostico_Pc, Guid> repository;

        public DiagnosticoUseCase(IBaseRepository<Diagnostico_Pc, Guid> repository)
        {
            this.repository = repository;
        }

        public Diagnostico_Pc Create(Diagnostico_Pc entity)
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

        public List<Diagnostico_Pc> GetAll()
        {
            return repository.GetAll();
        }

        public Diagnostico_Pc GetById(Guid entityId)
        {
            return repository.GetById(entityId);
        }

        public Diagnostico_Pc Update(Diagnostico_Pc entity)
        {
            repository.Update(entity);
            repository.SaveAllChanges();
            return entity;
        }
    }

}
