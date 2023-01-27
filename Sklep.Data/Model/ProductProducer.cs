using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class ProductProducer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Producenta Produktu")]
        public int IdProductProducer { get; set; }

        [Required(ErrorMessage = "Nazwa producenta jest wymagana")]
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
        public bool IsActicve { get; set; }
        public virtual ICollection<Product>? Product { get; set; }
    }
}
