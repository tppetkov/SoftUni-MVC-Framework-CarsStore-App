using System.Web.Mvc;

namespace CarsStore.Web.Controllers
{
    using System.Collections.Generic;

    using Service;
    using Attributes;

    using CarsStore.Service.Interfaces;

    using Models.ViewModels.Adverts;

    [MyAuthorize(Roles="User")]
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service =service;
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

        [Route("home/error")]
        public ActionResult Error()
        {
            
        
            return this.View();
        }
    }
}