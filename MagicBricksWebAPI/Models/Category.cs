using MagicBricksWebAPI.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MagicBricksWebAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Category name can't be null or empty")]
        public PropertyCategory propertyCategory { get; set; }

        [Required(ErrorMessage = "Image url can't be null or empty")]
        public string ImageUrl { get; set; }
        public ICollection<Property> Properties { get; set; }

    }
}
