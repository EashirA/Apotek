using Apotek.Models;
using Apotek.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apotek.Controllers
{
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get { return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { _userManager = value; }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var model = new UserVm();

            using (var db = new ApplicationDbContext())
            {
                model.Users.AddRange(db.Users.Select(u => new UserVm.UserListVm
                {
                    UserId = u.Id,
                    Email = u.Email,
                    UserName = u.UserName
                }));
                foreach (var item in model.Users)
                {
                    item.UserRoles = UserManager.GetRoles(item.UserId).SingleOrDefault();
                }
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            var model = new ManageUserVm();
            var user = UserManager.FindById(id);
            using (var db = new ApplicationDbContext())
            {
                model.UserId = user.Id;
                model.Email = user.Email;
                model.UserName = user.UserName;
                model.UserRoles = UserManager.GetRoles(user.Id).SingleOrDefault();
                model.UsersInSystem = new List<SelectListItem>();
                foreach (var item in db.Roles)
                {
                    model.UsersInSystem.Add(new SelectListItem { Value = item.Name, Text = item.Name });
                }

                return View(model);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(ManageUserVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ApplicationDbContext())
            {
                var user = UserManager.FindById(model.UserId);
                user.Id = model.UserId;
                user.UserName = model.UserName;
                user.Email = model.Email;
                UserManager.RemoveFromRole(user.Id, model.UserRoles);
                UserManager.AddToRole(user.Id, model.DropDown);

                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var user = UserManager.FindById(id);
                if (user != null)
                    UserManager.Delete(user);

                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}