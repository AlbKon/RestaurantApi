﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.MiddleWare;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;
        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public int Create(int restaurantId, CreateDishDto dto)
        {
            var restaurant = _context.Restaurants.
                FirstOrDefault(r => r.Id == restaurantId);

            if (restaurant == null) { throw new NotFoundException("Nie znaleziono takiej restauracji"); }

            var dishEntity = _mapper.Map<Dish>(dto);

            dishEntity.RestaurantId = restaurantId;

            _context.Dishes.Add(dishEntity);
            _context.SaveChanges();

            return dishEntity.Id;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            var restaurant = _context.Restaurants.
                FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant == null) { throw new NotFoundException("Nie znaleziono takiej restauracji"); }

            var dish = _context.Dishes.
                FirstOrDefault(d => d.Id == dishId);
            if (dish == null || dish.RestaurantId!= restaurantId) { throw new NotFoundException("Nie znaleziono takiego dania"); }

            var dishDto = _mapper.Map<DishDto>(dish);

            return dishDto;
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            var restaurant = _context.Restaurants
                .Include(r=>r.Dishes)
                .FirstOrDefault(r => r.Id == restaurantId);
            if (restaurant == null) { throw new NotFoundException("Nie znaleziono takiej restauracji"); }

            var dishDtos = _mapper.Map<List<DishDto>>(restaurant.Dishes);

            return dishDtos;
        }
    }
}
