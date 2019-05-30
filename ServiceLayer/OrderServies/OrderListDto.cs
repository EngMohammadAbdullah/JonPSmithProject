using DatabaseContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.OrderServies
{
    public class OrderListDTO
    {
        public Guid OrderKey { get; set; }
        public string ClientName { get; set; }
        public DateTime OrderCreated { get; set; }
        public IEnumerable<Item> OrerItems { get; set; }
        public IEnumerable<Item> OrerItemsToBeFacoted
        { get; set; }
        public string DelieryAddress { set; get; }
    }
}
