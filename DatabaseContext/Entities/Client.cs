using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Client :EntityBase
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


        public override string ToString()
        {
            var ff = $"{this.FirstName}  {this.LastName}";
            return this.FirstName + " " + this.LastName;
        }
      
        

        public Client()
        {
            Orders = new HashSet<Order>();
        }
    }
}
