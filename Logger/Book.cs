using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public record class Book(Guid Id, string BookTitle) : IEntity
    {
        //implemented implicitly because there is no need for explicit implementation
        public string Name => BookTitle;
    }
}
