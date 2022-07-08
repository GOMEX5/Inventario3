using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Interfaces;

namespace Inventario.Core.Application.Interfaces
{
    public interface IBaseUseCase<Entity, EntityId> : ICreate<Entity>,
        IRead<Entity, EntityId>, IUpdate<Entity>, IDelete<EntityId>
    {

    }
}
