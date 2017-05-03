using System.Web.Mvc;

namespace CarsStore.Web.Controllers
{
    using System.Collections.Generic;

    using Service;
    using Attributes;

    using Models.ViewModels.Adverts;

    [MyAuthorize(Roles="User")]
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return this.View();
        }
        [AllowAnonymous]
        public ActionResult GetAll()
        {
            IEnumerable<OfferVm> avm = this.service.GetAllAdverts();
            return this.PartialView("GetAll",avm);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return this.View();
        }

        //public ActionResult Contact()
        //{
        //    this.ViewBag.Message = "Your contact page.";
        //
        //    return this.View();
        //}
    }
}