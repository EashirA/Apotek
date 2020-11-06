using Apotek.DbContext;
using Apotek.Models;
using Apotek.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Apotek.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var myModel = new CatIndexVm();
            using (var database = new ApotekDbContext())
            {
                myModel.Categories.AddRange(database.CategoriesTable.ToList().Select(c => new CatIndexVm.CatListVm
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    CategoryDescription = c.CategoryDescription
                }));
            }
            return View(myModel);
        }




        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateCatVm();
            return View(model);
        }





        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateCatVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var database = new ApotekDbContext())
            {
                var category = new Category
                {
                    CategoryName = model.CategoryName,
                    CategoryDescription = model.Description
                };
                database.CategoriesTable.Add(category);
                database.SaveChanges();
            }
            return RedirectToAction("Index");

        }





        [HttpGet]
        [Authorize]
        public ActionResult Edit(int id)
        {
            using (var database = new ApotekDbContext())
            {

                var category = database.CategoriesTable.FirstOrDefault(p => p.CategoryId == id);

                var model = new EditCatVm();
                model.CategoryId = category.CategoryId;
                model.CategoryName = category.CategoryName;
                model.Description = category.CategoryDescription;
                return View(model);
            }

        }



        [HttpPost]
        [Authorize]
        public ActionResult Edit(EditCatVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var database = new ApotekDbContext())
            {
                var category = database.CategoriesTable.FirstOrDefault(r => r.CategoryId == model.CategoryId);
                category.CategoryId = model.CategoryId;
                category.CategoryName = model.CategoryName;
                category.CategoryDescription = model.Description;

                database.SaveChanges();
            }
            return RedirectToAction("Index");
        }





        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            using (var database = new ApotekDbContext())
            {
                var category = database.CategoriesTable.Find(id);
                if (category != null)
                    database.CategoriesTable.Remove(category);

                database.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

