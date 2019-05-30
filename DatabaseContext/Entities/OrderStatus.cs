using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseContext.Entities
{
    public enum OrderStatus
    {
        Ordered = 1,
        Scheduled = 2,
        InTransit = 3,
        Delivered = 4
    }
}
