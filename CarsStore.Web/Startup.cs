using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarsStore.Web.Startup))]
namespace CarsStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
