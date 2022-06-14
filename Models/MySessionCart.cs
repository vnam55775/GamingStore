using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GamingStore.MyTagHelper;
namespace GamingStore.Models
{
    public class MySessionCart : MyCart
    {
        public static MyCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            MySessionCart mycart = session?.GetJson<MySessionCart>("MyCart")
            ?? new MySessionCart();
            mycart.Session = session;
            return mycart;
        }
        [JsonIgnore]
        public ISession Session { get; set; }
        public override void AddItem(Gaming gaming, int quantity)
        {
            base.AddItem(gaming, quantity);
            Session.SetJson("MyCart", this);
        }
        public override void RemoveLine(Gaming gaming)
        {
            base.RemoveLine(gaming);
            Session.SetJson("MyCart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("MyCart");
        }
    }
}