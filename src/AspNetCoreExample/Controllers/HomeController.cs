﻿using AspNetCoreExample.Entities;
using AspNetCoreExample.Services;
using AspNetCoreExample.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExample.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel
            {
                Restaurants = _restaurantData.GetAll(),
                CurrentMessage = _greeter.GetGreeting()
            };
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newRestaurant = new Restaurant();
            newRestaurant.Cuisine = model.Cuisine;
            newRestaurant.Name = model.Name;
            newRestaurant = _restaurantData.Add(newRestaurant);
            _restaurantData.Commit();
            return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, RestaurantEditViewModel model)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(restaurant);
            }

            restaurant.Cuisine = model.Cuisine;
            restaurant.Name = model.Name;
            _restaurantData.Commit();
            return RedirectToAction(nameof(Details), new { id = restaurant.Id });
        }
    }
}
