using System.Web.Mvc;

namespace CarsStore.Web.Controllers
{
    using CarsStore.Service.Interfaces;

    using Models.BindingModels.Users;
    using Models.ViewModels.Users;

    using Service;

    public class UsersController : Controller
    {
        private IUsersService service;

        public UsersController(IUsersService service)
        {
            this.service=service;
        }
        [Route("profile")]
        public ActionResult Profile() 
        {
            string userName = this.User.Identity.Name;
            ProfileVm vm=this.service.GetProfileVm(userName);

            return this.View(vm);
        }

        [HttpGet]
        [Route("edit")]
        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            EditUserVm vm = this.service.GetEditVm(userName);

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(EditUserBm bind)
        {
            if (this.ModelState.IsValid)
            {
                string currentUserName = this.User.Identity.Name;
                this.service.EditUser(bind, currentUserName);
                return this.RedirectToAction("Profile");
            }
            string userName = this.User.Identity.Name;
            EditUserVm vm = this.service.GetEditVm(userName);

            return this.View(vm);
        }
    }
}