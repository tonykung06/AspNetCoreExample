using System.ComponentModel.DataAnnotations;

namespace AspNetCoreExample.Entities
{
    public enum CuisineType
    {
        none,
        Italian,
        French,
        Japanese,
        American
    }
    public class Restaurant
    {
        public int Id { get; set; }

        [Required, MaxLength(80)]
        [DataType(DataType.Text)]
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}
