using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Interfaces;

namespace Inventario.Core.Application.Interfaces
{
    public interface IDetailUseCase<Entity, EntityId> : ICreate<Entity>
    {
        void Cancel(EntityId entityId);
    }
}
