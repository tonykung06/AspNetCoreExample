using AspNetCoreExample.Entities;
using System.Collections.Generic;

namespace AspNetCoreExample.ViewModels
{
    public class HomePageViewModel
    {
        public string CurrentMessage { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
    }
}
