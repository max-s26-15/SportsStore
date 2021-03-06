using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        
        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Please enter a description")]
        public string Description { get; set; }
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive price")]
        [DataType(DataType.Currency, ErrorMessage = "Please enter a valid value")]
        public double Price { get; set; }
        
        [Required(ErrorMessage = "Please specify a category")]
        [StringLength(20)]
        public string Category { get; set; }
        
        [Required]
        [DataType(DataType.Url)]
        public string ImageUrl { get; set; }
    }
}