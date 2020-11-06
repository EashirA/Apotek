using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apotek.Models
{
    [Table("tblProducts")]
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDetail { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; internal set; }

    }
}