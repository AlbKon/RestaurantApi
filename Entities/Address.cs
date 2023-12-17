using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestaurantAPI.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Display(Name = "Miasto")]
        [MaxLength(50)]
        public string City { get; set; }
        [Display(Name = "Ulica")]
        [MaxLength(50)]
        public string Street { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        public virtual Restaurant Restaurant { get; set; }
    }
}
