using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Produktu")]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Kod towaru jest wymagany")]
        [Display(Name = "Kod")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Nazwa towaru jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Cena towaru jest wymagana")]
        [Column(TypeName = "money")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        [Display(Name = "Zdjęcie")]
        public string Picture { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }

        [Display(Name = "Czy ten towar jest promocyjny?")]
        public bool Sale { get; set; }
        [Required]
        [Display(Name = "Data utworzenia")]
        public System.DateTime Created { get; set; }
        [Required]
        [Display(Name = "Data modyfikacj")]
        public System.DateTime Modified { get; set; }
        [Required]
        [Display(Name = "Czy Aktywny?")]
        public bool IsActive { get; set; }
        public int IdProductType { get; set; }
        [ForeignKey("IdProductType")]
        public virtual ProductType? ProductType { get; set; }

        public int IdProductCategory { get; set; }
        [ForeignKey("IdProductCategory")]
        public virtual ProductCategory? ProductCategory { get; set; }

        public int IdProductProducer { get; set; }
        [ForeignKey("IdProductProducer")]
        public virtual ProductProducer? ProductProducer { get; set; }

        public virtual ICollection<OrderItem>? OrderItem { get; set; }
    }
}
