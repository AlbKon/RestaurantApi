using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }
        
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Krótki opis",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "Wings",
                            Price = 10.30M
                        },
                        new Dish
                        {
                            Name = "Zinger",
                            Price = 7.20M
                        },
                        new Dish
                        {
                            Name = "Koorczak",
                            Price = 2.0M
                        }
                    },
                    Address = new Address
                    {
                        City = "Konin",
                        Street = "GalerianskoNadJeziorna 43",
                        PostalCode = "62-510"
                    }
                },
                new Restaurant
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "Krótki opis, ale dłuższy",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish
                        {
                            Name = "WieśMac",
                            Price = 5.0M
                        },
                        new Dish
                        {
                            Name = "McCiken",
                            Price = 10.80M
                        }
                    },
                    Address = new Address
                    {
                        City = "Konin",
                        Street = "Przemyslowa 8a",
                        PostalCode = "62-510"
                    }
                }
            };

            return restaurants;
        }
    }
}
