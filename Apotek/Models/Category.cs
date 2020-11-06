using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apotek.Models
{
    [Table("tblCategories")]

    public class Category
    {
            [Key]
            [Required]
            public int CategoryId { get; set; }
            [Required]
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }

            public ICollection<Product> Products { get; set; }
    }
    
}