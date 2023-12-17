using System.ComponentModel.DataAnnotations;

namespace RestaurantAPI.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name="Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Display(Name = "Dowóz")]
        public bool HasDelivery { get; set; }
        [Display(Name = "Email")]
        public string ContactEmail { get; set; }
        [Display(Name = "Numer kontaktowy")]
        public string ContactNumber { get; set; }

        public int AddressId { get; set; }
        public virtual Address Address { get; set; }
        
        public virtual List<Dish> Dishes { get; set; }
    }
}
