using System.ComponentModel.DataAnnotations;

namespace WebMoHinh.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        [Required, StringLength(50)]
        public required string CategoryName { get; set; }
        public List<Product>? Products { get; set; }
        
    }
}
