using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public class Address : EntityBase
    {

       
        public string Country { get; set; }
        public string StreetName { get; set; }
        public string StreetNo { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public ICollection<Order> Orders { get; set; }
        public override string ToString()
        {
            string ss = $"{Country} {City} ";
            return ss;
        }
        public Address()
        {
            Orders = new HashSet<Order>();
        }

    }
}
