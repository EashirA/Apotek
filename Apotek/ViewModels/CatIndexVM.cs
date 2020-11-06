using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apotek.ViewModels
{
    public class CatIndexVm
    {
        public CatIndexVm()
        {
            Categories = new List<CatListVm>();
        }

        public class CatListVm
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
            public string CategoryDescription { get; set; }
        }
        public List<CatListVm> Categories { get; set; }
        public string CurrentSort { get; set; }

    }

}
