using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Employee : User
    {

        public ICollection<Order> Orders { get; set; }

    }
}
