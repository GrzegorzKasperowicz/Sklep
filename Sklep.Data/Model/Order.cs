using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sklep.Data.Model
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id Zamowienia")]
        public int IdOrder { get; set; }
        [Display(Name = "Data zamównienia")]
        public System.DateTime OrderDate { get; set; }

        [Display(Name = "Razem")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [Display(Name = "Imię")]
        [MaxLength(69, ErrorMessage = "Imię powinno zawierać max 69 znaków")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [Display(Name = "Nazwisko")]
        [MaxLength(69, ErrorMessage = "Nazwisko powinno zawierać max 69 znaków")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Ulica jest wymagana")]
        [Display(Name = "Ulica")]
        [MaxLength(69, ErrorMessage = "Ulica powinna zawierać max 69 znaków")]
        public string Street { get; set; }


        [Required(ErrorMessage = "Numer domu jest wymagany")]
        [Display(Name = "Nuemr Domu")]
        [MaxLength(20, ErrorMessage = "Numer domu powinien zawierać max 20 znaków")]
        public string HouseNumber { get; set; }

        [StringLength(20)]
        [Display(Name = "Numer Mieszkania")]

        public string ApartmentNumber { get; set; }

        [Required(ErrorMessage = "Miasto jest wymagane")]
        [Display(Name = "Miasto")]
        [MaxLength(69, ErrorMessage = "Nawa miasta powinna zawierać max 69 znaków")]
        public string City { get; set; }

        [Required(ErrorMessage = "Wojewodztwo jest wymagane")]
        [MaxLength(69, ErrorMessage = "Nawa miasta powinna zawierać max 69 znaków")]
        [Display(Name = "Województwo")]
        public string Province { get; set; }

        [Required(ErrorMessage = "Kod Pocztowy jest wymagany")]
        [Display(Name = "Kod Pocztowy")]
        [MaxLength(10, ErrorMessage = "Kod Pocztowy powninien zawierać max 10 znaków")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Państwo jest wymagane")]
        [MaxLength(69, ErrorMessage = "Nawa państwa powinna zawierać max 69 znaków")]
        [Display(Name = "Państwo")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Numer telefonu")]
        [MaxLength(15, ErrorMessage = "Numer telefonu powninien zawierać max 15 znaków")]
        [Display(Name = "Numer telefonu")]
        public string PhoneNumer { get; set; }

        [Required(ErrorMessage = "Email jest wymagany")]
        [Display(Name = "Adres email")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
            ErrorMessage = "Email nie jest prawidłowy.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<OrderItem>? OrderItem { get; set; }
    }
}
