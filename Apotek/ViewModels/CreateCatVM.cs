using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apotek.ViewModels
{
    public class CreateCatVm
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Required")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Invalid")]
        public string CategoryName { get; set; }
        [StringLength(400, MinimumLength = 10, ErrorMessage = "Invalid")]
        public string Description { get; set; }
    }
}