using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace WebMoHinh.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên san pham"), StringLength(100)]
        public string? Name { get; set; }       

        [Required,Range(1.000, 10000.00)]
        public decimal Price { get; set; }
      
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public List<ProductImage>? Images { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
