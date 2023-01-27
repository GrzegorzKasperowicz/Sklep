using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Element Zamównienia")]
        public int IdOrderItem { get; set; }
        [Display(Name = "Ilość")]
        public decimal Quantity { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        public int? IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product? Product { get; set; }

        public int? IdOrder { get; set; }
        [ForeignKey("IdOrder")]
        public virtual Order? Order { get; set; }
    }
}
