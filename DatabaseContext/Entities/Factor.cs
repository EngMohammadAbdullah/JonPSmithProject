using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Factor : EntityBase
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<ItemToBeFactored> FactoredItems { get; set; }

    }
}
