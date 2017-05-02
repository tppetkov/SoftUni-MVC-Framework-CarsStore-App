using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Web.Areas.Admin.Controllers
{
    using CarsStore.Data;
    using CarsStore.Models.EntityModels;
    using CarsStore.Web.Controllers;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class RolesController : Controller
    {
        protected CarsStoreContext Context { get; }

        public RolesController()
        {
            this.Context=new CarsStoreContext();
        }
        [HttpGet]
        [Route("roles")]
        public ActionResult Index()
        {
            var roles = this.Context.Roles.ToList();
            return this.View(roles);
        }

        [HttpGet]
        [Route("roles/add")]
        public ActionResult Create()
        {
            return this.View();
        }

        //
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
                this.ViewBag.ResultMessage = "Role created successfully !";
                return this.RedirectToAction("Index");
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
            var thisRole = this.Context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));

            return this.View(thisRole);
        }

        [HttpPost]
        [Route("roles/edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Microsoft.AspNet.Identity.EntityFramework.IdentityRole role)
        {
            try
            {
                this.Context.Entry(role).State = System.Data.Entity.EntityState.Modified;
                this.Context.SaveChanges();

                return this.RedirectToAction("Index");
            }
            catch
            {
                return this.View();
            }
        }

        
        public ActionResult Delete(string roleName)
        {
            var thisRole = this.Context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            this.Context.Roles.Remove(thisRole);
            this.Context.SaveChanges();
            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("roles/manage")]
        public ActionResult ManageUserRoles()
        {
            var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            this.ViewBag.Roles = list;
            return this.View();
        }

        [HttpPost]
        [Route("roles/manage/addrole")]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string userName, string roleName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
            var userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var addRoleResult = userManager.AddToRole(currentUser.Id, roleName);
            if (addRoleResult.Succeeded)
            {
                this.ViewBag.ResultMessage = "Role created successfully !";
            }

            var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            this.ViewBag.Roles = list;

            return this.View("ManageUserRoles");
        }

        [HttpPost]
        [Route("roles/manage/getroles")]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName))
            {
                ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));
                var userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

                this.ViewBag.RolesForThisUser = userManager.GetRoles(user.Id);

                var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
                this.ViewBag.Roles = list;
            }

            return this.View("ManageUserRoles");
        }

        [HttpPost]
        [Route("roles/manage/remove")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteRoleForUser(string userName, string roleName)
        {
            var userManager = this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase));

            if (userManager.IsInRole(user.Id, roleName))
            {
                userManager.RemoveFromRole(user.Id, roleName);
                this.ViewBag.ResultMessage = "Role removed from this user successfully !";
            }
            else
            {
                this.ViewBag.ResultMessage = "This user doesn't belong to selected role.";
            }
            var list = this.Context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            this.ViewBag.Roles = list;

            return this.View("ManageUserRoles");
        }
    }
}