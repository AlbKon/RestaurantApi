using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant/{restaurantId}/dish")]
    [ApiController]
    public class DishController : ControllerBase
    {
        private readonly IDishService _dishService;
        public DishController(IDishService dishService)
        {
            _dishService = dishService;
        }

        [HttpPost]
        public ActionResult Post([FromRoute]int restaurantId, [FromBody]CreateDishDto dto)
        {
            var dishId = _dishService.Create(restaurantId, dto);

            return Created($"api/restaurant/{restaurantId}/dish/{dishId}", null);
        }

        [HttpGet("{dishId}")]
        public ActionResult<DishDto> Get([FromRoute] int restaurantId, [FromRoute]int dishId)
        {
            var dishDto = _dishService.GetById(restaurantId, dishId);

            return Ok(dishDto);
        }

        [HttpGet()]
        public ActionResult<List<DishDto>> Get([FromRoute] int restaurantId)
        {
            var dishDtos = _dishService.GetAll(restaurantId);

            return Ok(dishDtos);
        }
    }
}
