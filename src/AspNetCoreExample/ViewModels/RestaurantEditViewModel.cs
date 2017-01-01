using AspNetCoreExample.Entities;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExample.ViewModels
{
    public class RestaurantEditViewModel
    {
        [Required, MaxLength(80)]
        [DataType(DataType.Text)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
