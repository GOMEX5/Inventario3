using System;
using System.Collections.Generic;
using System.Text;
using Inventario.Core.Domain.Interfaces;

namespace Inventario.Core.Infraestructure.Repository.Abstract
{
    public interface IDetailRepository<Entity, ITraITransactionID> : ICreate<Entity>, ITransaction<Entity>
    {
        List<Entity> GetDetailsByTransaction(ITraITransactionID transactionId);
    }
}
