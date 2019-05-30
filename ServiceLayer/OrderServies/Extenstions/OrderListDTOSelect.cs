using DatabaseContext.Entities;
using DatabaseContext.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.OrderServies.Extenstions
{
    public static class OrderListDTOSelect
    {
        //static EntitiesContext context = new EntitiesContext();
        public static IQueryable<OrderListDTO> MakeOrderToDTO(
            this IQueryable<Order> orders)
        {
            var oo = orders.Select(o => new OrderListDTO
            {
                OrderKey = o.Key,
                DelieryAddress = o.Address==null  ? "  " : o.Address.ToString(),
                ClientName = o.Client.ToString(),
                OrderCreated = o.CreatedOn,
                OrerItems = o.Items
            }
            );


            return oo;

        }



        public static IQueryable<OrderListDTO> SortOrdersByItemsCount(this IQueryable<OrderListDTO> orders)
        {

            return orders.OrderBy(i => i.OrerItems.Count());

        }
    }
}
