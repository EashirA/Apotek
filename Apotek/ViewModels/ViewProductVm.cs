using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotek.ViewModels
{
    public class ViewProductVm
    {
        public ViewProductVm()
        {
            ProductCat = new List<CategoryProductVm>();
        }
        public class CategoryProductVm
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public string ProductDetail { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
        }
        public List<CategoryProductVm> ProductCat { get; set; }
        public string CurrentSort { get; set; }
    }
}