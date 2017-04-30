using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Web.Areas.Admin.Controllers
{
    using CarsStore.Data;
    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Admin;
    using CarsStore.Service;
    using CarsStore.Web.Controllers;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private AdminService service;
        protected CarsStoreContext Context { get; }
        public AdminController()
        {
            this.service=new AdminService();
            this.Context = new CarsStoreContext();
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            AdminPageVm vm=this.service.GetAdminPage();
            return View(vm);
        }

        [HttpGet]
        [Route("offers/{id}/edit")]
        public ActionResult EditOfffer(int id)
        {
            return this.View();
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            return this.View();
        }

        [HttpGet]
        [Route("roles/add")]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [Route("roles/add")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                this.Context.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
                {
                    Name = collection["RoleName"]
                });
                this.Context.SaveChanges();
                ViewBag.ResultMessage = "Role created successfully !";
                return RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }

        [HttpGet]
        [Route("roles/edit")]
        public ActionResult Edit(string roleName)
        {
            var thisRole = this.Context.Roles.Where(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            return View(thisRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("roles/edit")]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                this.Context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Route("roles")]
        public ActionResult ManageUserRoles()
        {
            var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr =>

            new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            this.ViewBag.Roles = list;
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("roles")]
        public ActionResult ManageUserRoles(string userName, string roleName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
            var userManager=this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var addRoleResult = userManager.AddToRole(currentUser.Id, roleName);
            if (addRoleResult.Succeeded)
            {
                this.ViewBag.ResultMessage = "Role created successfully !";
            }
            var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            this.ViewBag.Roles = list;

            return this.View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //
        //public ActionResult GetRoles(string userName)
        //{
        //    if (!string.IsNullOrWhiteSpace(userName))
        //    {
        //        ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
        //        var account = new AccountController();
        //
        //        this.ViewBag.RolesForThisUser = account.UserManager.GetRoles(currentUser.Id);
        //
        //        var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
        //        this.ViewBag.Roles = list;
        //    }
        //
        //    return this.View("ManageUserRoles");
        //}
        //
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Route("roles")]
        //public ActionResult DeleteRoleForUser(string userName, string roleName)
        //{
        //    var account = new AccountController();
        //    ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
        //
        //    if (account.UserManager.IsInRole(currentUser.Id, roleName))
        //    {
        //        account.UserManager.RemoveFromRole(currentUser.Id, roleName);
        //        this.ViewBag.ResultMessage = "Role removed from this user successfully !";
        //    }
        //    else
        //    {
        //        this.ViewBag.ResultMessage = "This user doesn't belong to selected role.";
        //    }
        //    // prepopulat roles for the view dropdown
        //    var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
        //    this.ViewBag.Roles = list;
        //
        //    return this.View("ManageUserRoles");
        //}
    }
}