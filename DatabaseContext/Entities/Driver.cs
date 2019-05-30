using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Driver:User
    {
        public Guid JourneyKey { get; set; }
        public Journey Journey { get; set; }

        public virtual ICollection<Journey> Journeies { get; set; }

    }
}
