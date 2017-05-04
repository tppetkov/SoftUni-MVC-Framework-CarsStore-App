using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsStore.Web.Areas.Admin.Controllers
{
    using CarsStore.Data;
    using CarsStore.Models.BindingModels.Offers;
    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Admin;
    using CarsStore.Models.ViewModels.Adverts;
    using CarsStore.Models.ViewModels.Users;
    using CarsStore.Service;
    using CarsStore.Service.Interfaces;
    using CarsStore.Web.Attributes;
    using CarsStore.Web.Controllers;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;

    [Authorize(Roles = "Admin")]
    [RouteArea("admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

       
        public AdminController(IAdminService service)
        {
            this.service=service;
        }

        [HttpGet]
        [Route]
        public ActionResult Index()
        {
            AdminPageVm vm=this.service.GetAdminPage();
            return View(vm);
        }

        [HttpGet]
        [Route("offers/edit/{id}")]
        public ActionResult GetEditOffer(int id)
        {
            EditOfferVm vm = this.service.GetEditVm(id);

            return this.View("EditOffer",vm);
        }

        [HttpPost]
        [Route("offers/edit/{id}")]
        public ActionResult EditOfffer(EditOfferBm bind,int id)
        {
            if (this.ModelState.IsValid)
            {
                this.service.EditOffer(bind, id);
                return this.RedirectToAction("Index");
            }

            EditOfferVm vm = this.service.GetEditVm(id);

            return this.View(vm);
        }

        [Route("offers/delete/{id}")]
        public ActionResult DeleteOffer(int id)
        {
            this.service.DeleteOffer(id);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        [Route]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteUser(string username)
        {
            this.service.DeleteUser(username);
            
            return this.RedirectToAction("Index");
        }
    }
}