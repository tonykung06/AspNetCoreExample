using AspNetCoreExample.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AspNetCoreExample.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant{ Id = 1, Name = "My Restaurant 1" },
                new Restaurant{ Id = 2, Name = "My Restaurant 2" },
                new Restaurant{ Id = 3, Name = "My Restaurant 3" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        //non-thread-safe
        private static List<Restaurant> _restaurants;
    }
}
