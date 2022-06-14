using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace GamingStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Vui lòng điền họ tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng điền địa chỉ")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Vui lòng điền thành phố")]
        public string City { get; set; }
        [Required(ErrorMessage = "Vui lòng điền tỉnh")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Vui lòng điền số điện thoại")]
        public string Country { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}