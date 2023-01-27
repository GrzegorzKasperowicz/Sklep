using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class News
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNews { get; set; }
        [Required(ErrorMessage = "Wpisz tytuł aktualności")]
        [MaxLength(20, ErrorMessage = "Tytuł powinien zawierać max 20 znaków")]
        [Display(Name = "Tytuł odnośnika")]
        public string TitleLink { get; set; }
        [Required(ErrorMessage = "Wpisz tytuł aktualności")]
        [MaxLength(60, ErrorMessage = "Tytuł aktualności powinien zawierać max 60 znaków")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Treść")]
        [Column(TypeName = "nvarchar(MAX)")]

        public string Description { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Picture { get; set; }
        [Display(Name = "Pozycja Wyswietlania")]
        [Required(ErrorMessage = "Wpisz pozycję wyświetlania")]
        public int Position { get; set; }
        [Display(Name = "Czy Aktywny?")]
        public bool IsActive { get; set; }
    }
}
