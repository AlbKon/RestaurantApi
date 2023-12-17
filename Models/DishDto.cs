using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RestaurantAPI.Models
{
    public class DishDto
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
    }
}
