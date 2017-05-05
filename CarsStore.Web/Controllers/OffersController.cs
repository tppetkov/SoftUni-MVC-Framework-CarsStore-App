using System.Web.Mvc;

namespace CarsStore.Web.Controllers
{
    using System.Net;
    using System.Web;

    using CarsStore.Models.BindingModels;
    using CarsStore.Models.BindingModels.Blog;
    using CarsStore.Models.EntityModels;
    using CarsStore.Models.ViewModels.Users;

    using Models.ViewModels.Adverts;
    using CarsStore.Service;
    using CarsStore.Service.Interfaces;

    [Authorize(Roles = "User")]
    [RoutePrefix("adverts")]
    public class OffersController : Controller
    {
        private IOffersService service;

        public OffersController(IOffersService service)
        {
            this.service=service;
        }

        [AllowAnonymous]
        [HttpGet, Route("details/{id}")]
        public ActionResult Details(int id)
        {
            DetailsOfferVm vm = this.service.GetDetails(id);
            if (vm == null)
            {
                return this.HttpNotFound();
            }
            return this.View(vm);
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("add")]
        public ActionResult AddOffer()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("add")]
        public ActionResult AddOffer(AddOfferBm bind, HttpPostedFileBase file)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.AddNewOffer(bind, file, currentUserName);
                return this.RedirectToAction("Index","Home");
            }
            return this.View();
        }

        [AllowAnonymous]
        public ActionResult OfferImage(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarOffer offer = this.service.GetAttractionImage((int)id);

            return this.PartialView(offer);
        }
        [AllowAnonymous]
        public ActionResult OfferImageSmall(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CarOffer offer = this.service.GetAttractionImage((int)id);

            return this.PartialView(offer);
        }

    } 
}