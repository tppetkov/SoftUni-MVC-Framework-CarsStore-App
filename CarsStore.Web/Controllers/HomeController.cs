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
            IEnumerable<OfferVm> avm = this.service.GetAllAdverts();
            return View(avm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}