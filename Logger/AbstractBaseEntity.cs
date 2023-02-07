using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract class AbstractBaseEntity : IEntity
    {
        public abstract string Name { get; }
        public Guid Id { get; init; }
    }
}
