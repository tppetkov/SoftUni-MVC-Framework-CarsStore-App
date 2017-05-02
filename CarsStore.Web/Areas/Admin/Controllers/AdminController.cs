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
       
        public AdminController()
        {
            this.service=new AdminService();
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

        [Route("offers/delete/{id}")]
        public ActionResult DeleteOffer(int id)
        {
            this.service.DeleteOffer(id);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            return this.View();
        }
    }
}