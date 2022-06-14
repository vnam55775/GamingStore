using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace GamingStore.Models
{
    public class MyCart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Gaming gaming, int quantity)
        {
            CartLine line = Lines
            .Where(b => b.Gaming.GamingID == gaming.GamingID)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Gaming = gaming,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Gaming gaming) =>
        Lines.RemoveAll(l => l.Gaming.GamingID == gaming.GamingID);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Gaming.Price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Gaming Gaming { get; set; }
        public int Quantity { get; set; }
    }
}
