using RestaurantAPI.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestaurantAPI.Models
{
    public class RestaurantDto
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Display(Name = "Dowóz")]
        public bool HasDelivery { get; set; }
        [Display(Name = "Miasto")]
        public string City { get; set; }
        [Display(Name = "Ulica")]
        public string Street { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        public List<DishDto> Dishes { get; set; }
    }
}
