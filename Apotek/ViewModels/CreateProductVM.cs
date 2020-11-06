using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apotek.ViewModels
{
    public class CreateProductVm
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Invalid")]
        public string ProductName { get; set; }
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Invalid")]
        public string ProductDetail { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
    }
}