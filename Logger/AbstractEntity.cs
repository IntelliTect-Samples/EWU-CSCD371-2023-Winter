﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public abstract record class AbstractEntity : IEntity
    {   

        public Guid Id { get; init; } = Guid.NewGuid();
        public abstract string Name { get;}

    }
}
