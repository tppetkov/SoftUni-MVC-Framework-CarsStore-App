using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CarsStore.Web
{
    using System;

    using AutoMapper;

    using CarsStore.Models.BindingModels;
    using CarsStore.Models.BindingModels.Blog;
    using CarsStore.Models.ViewModels.Admin;

    using Models.BindingModels.Users;
    using Models.EntityModels;
    using Models.ViewModels.Adverts;
    using Models.ViewModels.Blog;
    using Models.ViewModels.Users;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigreMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigreMappings()
        {
           Mapper.Initialize(
               expresion =>
                   {
                       expresion.CreateMap<CarOffer, OfferVm>();
                       expresion.CreateMap<CarOffer, DetailsOfferVm>();
                       expresion.CreateMap<AddOfferBm,CarOffer>();
                       expresion.CreateMap<CarOffer, AddOfferVm>();
                       expresion.CreateMap<ApplicationUser, ProfileVm>();
                       expresion.CreateMap<ApplicationUser, EditUserVm>();
                       expresion.CreateMap<ApplicationUser, EditUserBm>();
                       expresion.CreateMap<Article, ArticleVm>();
                       expresion.CreateMap<ApplicationUser, ArticleAuthorVm>();
                       expresion.CreateMap<AddArticleBm,Article>();
                       expresion.CreateMap<RegularUser, AdminUserVm>().ForMember(vm=>vm.Name,configureExpresion => 
                       configureExpresion.MapFrom(regUser=> regUser.User.Name))
                       .ForMember(vm => vm.Email, configureExpresion =>
                          configureExpresion.MapFrom(regUser => regUser.User.Email));
                   });
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Server.ClearError();
        //    Response.Redirect("/Home/Error");
        //}
    }
}
