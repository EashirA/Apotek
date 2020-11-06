using Apotek.DbContext;
using Apotek.Models;
using Apotek.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Apotek.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product


        public ActionResult Product(string sort)
        {
            var model = new ProductIndexVm();
            using (var database = new ApotekDbContext())
            {
                model.Products.AddRange(database.ProductsTable.ToList().Select(p => new ProductIndexVm.ProductListVm
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    ProductDetail = p.ProductDetail,
                    Price = p.ProductPrice,
                    CategoryName = p.Category.CategoryName,
                    CategoryId = p.CategoryId

                }));
            }

            model = Sort(model, sort);
            return View(model);
        }


        public ActionResult Search(string searchString, string sort)
        {
            var model = new ProductIndexVm();
            using (var database = new ApotekDbContext())
            {
                if (!string.IsNullOrEmpty(searchString))
                {
                    var products = database.ProductsTable.Where(p => p.ProductName.Contains(searchString));
                    foreach (var product in products)
                    {
                        var pModel = new ProductIndexVm.ProductListVm
                        {
                            ProductId = product.ProductId,
                            ProductName = product.ProductName,
                            ProductDetail = product.ProductDetail,
                            Price = product.ProductPrice,
                            CategoryName = product.Category.CategoryName

                        };
                        model.Products.Add(pModel);
                    }
                    model = Sort(model, sort);
                }
                return View(model);
            }
        }

        public ActionResult View(int id, string sort)
        {
            var model = new ProductIndexVm();

            using (var database = new ApotekDbContext())
            {
                model.CategoryName = string.Join("", database.CategoriesTable.Where(c => c.CategoryId == id).Select(c => c.CategoryName));
                model.CategoryId = id;
                model.Products.AddRange(database.ProductsTable
                    .Select(p => new ProductIndexVm.ProductListVm
                    {
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        ProductDetail = p.ProductDetail,
                        Price = p.ProductPrice,
                        CategoryId = p.CategoryId
                    }).Where(c => c.CategoryId == id));

                model = Sort(model, sort);

                return View(model);
            }
        }

        public ProductIndexVm Sort(ProductIndexVm model, string sort)
        {
            if (sort == "ProductNameAsc")
                model.Products = model.Products.OrderBy(r => r.ProductName).ToList();
            else if (sort == "ProductNameDesc")
                model.Products = model.Products.OrderByDescending(r => r.ProductName).ToList();


            if (sort == "ProductPriceAsc")
                model.Products = model.Products.OrderBy(r => r.Price).ToList();
            else if (sort == "ProductPriceDesc")
                model.Products = model.Products.OrderByDescending(r => r.Price).ToList();
            model.CurrentSort = sort;
            return model;
        }

        public ActionResult ViewSingleProduct(int? id)
        {
            var model = new ProductIndexVm.ProductListVm();
            using (var database = new ApotekDbContext())
            {
                var c = database.ProductsTable.Find(id);
                model.ProductId = c.ProductId;
                model.ProductName = c.ProductName;
                model.ProductDetail = c.ProductDetail;
                model.Price = c.ProductPrice;
                model.CategoryName = c.Category.CategoryName;
                return View(model);
            }
        }



        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Edit(int? id)
        {
            using (var database = new ApotekDbContext())
            {
                var product = database.ProductsTable.Find(id);
                var model = new EditProductVm
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductDetail = product.ProductDetail,
                    ProductPrice = product.ProductPrice,
                    CategoryId = product.CategoryId
                };
                DropDownCategories(model);
                return View(model);
            }
        }


        public void DropDownCategories(EditProductVm model)
        {
            model.CategoryDropDownList = new List<SelectListItem>();
            using (var database = new ApotekDbContext())
            {
                foreach (var c in database.CategoriesTable)
                {
                    model.CategoryDropDownList.Add(new SelectListItem
                    {
                        Value = c.CategoryId.ToString(),
                        Text = c.CategoryName

                    });
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Edit(EditProductVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var database = new ApotekDbContext())
            {
                var product = database.ProductsTable.FirstOrDefault(r => r.ProductId == model.ProductId);
                product.ProductId = model.ProductId;
                product.ProductName = model.ProductName;
                product.ProductDetail = model.ProductDetail;
                product.ProductPrice = model.ProductPrice;
                product.CategoryId = model.CategoryId;

                database.SaveChanges();
                return RedirectToAction("Product", new { id = model.CategoryId });
            }
        }



        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Create(int id)
        {
            var model = new EditProductVm { CategoryId = id };
            using (var database = new ApotekDbContext())
            {
                model.CategoryName = string.Join("", database.CategoriesTable.Where(x => x.CategoryId == id).Select(x => x.CategoryName));
                model.CategoryId = id;
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Create(EditProductVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var database = new ApotekDbContext())
            {
                var product = new Product
                {
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    ProductDetail = model.ProductDetail,
                    ProductPrice = model.ProductPrice,
                    CategoryId = model.CategoryId,
                };
                database.ProductsTable.Add(product);
                database.SaveChanges();
            }
            return RedirectToAction("Product");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,ProductManager")]
        public ActionResult Delete(int id)
        {
            using (var database = new ApotekDbContext())
            {
                var product = database.ProductsTable.Find(id);
                if (product != null)
                    database.ProductsTable.Remove(product);

                database.SaveChanges();
            }
            return RedirectToAction("Product");
        }
    }
}
