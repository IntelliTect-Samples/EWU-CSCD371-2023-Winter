﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Student(FullName FullName, string Degree, string SchoolName) : Entity { 
        public override string Name { get => FullName.ToString(); }
    }
  
}
