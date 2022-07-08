using System;
using System.Collections.Generic;
using System.Text;

namespace Inventario.Core.Domain.Interfaces
{
    public interface IDelete<Entity>
    {
        void Delete(Entity entity);
    }
}
