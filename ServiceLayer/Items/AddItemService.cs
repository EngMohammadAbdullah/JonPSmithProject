using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Items
{
    public class AddItemService
    {

        readonly EntitiesContext _Context;
        public string CustomerName { get; set; }
        public AddItemService(EntitiesContext context)
        {
            _Context = context;
        }

        public Item GetBlankItem(Guid key)
        {
            CustomerName = _Context.Orders.Where(o => o.Key.Equals(key))
                            .Include(c => c.Client).Select(c => c.Client.FirstName).Single();

            return new Item
            {

                OrderKey = key

            };

        }

        public Order AddItemToOrder(Item item)
        {

            var order = _Context.Orders.Include(o => o.Items)
                   .Where(o => o.Key == item.OrderKey)

                   .Single();

            order.Items.Add(item);
            _Context.SaveChanges();
            return order;

        }


    }
}
