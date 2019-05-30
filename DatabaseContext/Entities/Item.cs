using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Item : EntityBase
    {

        public string Name { get; set; }
        public double Height { get; set; }
        public double width { get; set; }
        public string Color { get; set; }
        public Guid OrderKey { get; set; }

        public Order CustomerOrder { get; set; }
    }
}
