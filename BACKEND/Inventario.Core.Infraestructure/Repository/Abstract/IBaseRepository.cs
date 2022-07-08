using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Interfaces;

namespace Inventario.Core.Infraestructure.Repository.Abstract
{
    public interface IBaseRepository<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>, ITransaction<Entity>
    {

    }
}
