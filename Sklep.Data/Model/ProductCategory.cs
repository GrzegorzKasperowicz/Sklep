using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Kategorii Produktu")]
 
        public int IdProductCategory { get; set; }
        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        [Display(Name = "Nazwa")]
        public string Title { get; set; }
        [Display(Name = "Opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string? Description { get; set; }
        [Display(Name = "Data utworzenia")]
        public System.DateTime Created { get; set; }
        [Display(Name = "Data modyfikacji")]
        public System.DateTime Modified { get; set; }


        [Display(Name = "Czy Aktywny?")]
        public bool IsActive { get; set; }
        public virtual ICollection<Product>? Product { get; set; }
    }
}
