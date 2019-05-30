using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Car : EntityBase
    {
        public string Name { get; set; }
        public string model { get; set; }
        public string Number { get; set; }
        public Guid JourneyKey { get; set; }

        public virtual ICollection<Journey> Journeies  { get; set; }

    }
}
