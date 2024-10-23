using System.ComponentModel.DataAnnotations;

namespace WebMoHinh.Models
{
    public class CustomerInfo
    {
        [Display (Name = "Họ Tên Khách Hàng")]
        public string CustomerName { get; set; }

        [Display(Name = "Địa Chỉ Email")]
        public string Email { get; set; }

        [Display(Name = "Phản Hồi Của Khách Hàng")]
        public string Describe { get; set; }
    }
}
