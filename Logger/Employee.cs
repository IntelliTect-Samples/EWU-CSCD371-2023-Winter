﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record Employee(FullName FullName, string PositionTitle, string Company) : Person(FullName)
    {
    }
}