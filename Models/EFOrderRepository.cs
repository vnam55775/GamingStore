using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamingStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private GamingStoreDbContext context;
        public EFOrderRepository(GamingStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Gaming);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Gaming));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }

}
