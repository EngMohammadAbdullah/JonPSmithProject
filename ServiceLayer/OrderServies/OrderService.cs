using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.OrderServies
{
    public class OrderService
    {
        readonly EntitiesContext _context;
        public OrderService(EntitiesContext context)
        {
            _context = context;
        }

        public List<Order> GetOrders()
        {

            return _context.Orders.ToList();
        }
    }
}
