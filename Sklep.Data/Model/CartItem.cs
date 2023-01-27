using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class CartItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Elementu Koszyka")]
        public int IdCartItem { get; set; }
        [Display(Name = "Id Sesji Koszyka")]
        public string IdCartSession { get; set; }

        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [Required]

        [Display(Name = "Ilość")]
        public decimal Quantity { get; set; }

        [Display(Name = "Data utworzenia")]
        public DateTime Created { get; set; }
    }
}
