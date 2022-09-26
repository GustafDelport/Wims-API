using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wims.Domain.Interfaces
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual Guid Id { get => Guid.NewGuid(); }
    }
}
