using AspNetCoreExample.Entities;
using AspNetCoreExample.Services;
using AspNetCoreExample.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExample.Controllers
{
    public class HomeController : Controller
    {
        private IGreeter _greeter;
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

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
            return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
        }
    }
}
