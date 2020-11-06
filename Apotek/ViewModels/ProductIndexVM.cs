using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotek.ViewModels
{
    public class ProductIndexVm
    {
        public ProductIndexVm()
        {
            Products = new List<ProductListVm>();
        }
        public class ProductListVm
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDetail { get; set; }
            public decimal Price { get; set; }
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }

        }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public List<ProductListVm> Products { get; set; }
        public string CurrentSort { get; set; }
    }
}