using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GamingStore.Models
{
    public class Gaming
    {
        public long GamingID { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please specify a genre")]
        public string Genre { get; set; }
    }
}