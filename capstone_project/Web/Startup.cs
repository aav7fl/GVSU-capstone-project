using GVSU.BusinessLogic;
using GVSU.Contracts;
using GVSU.Data;
using GVSU.Data.Services;
using GVSU.Simulators;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using System.Web;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitializeFactories(app);
        }

        public void InitializeFactories(IAppBuilder app)
        {
            /**Factory.Register<IVolunteerService>(() =>
                new SQLVolunteerService(
                new VolunteerServiceSimulator(),
                HttpContext.Current.GetOwinContext().Get<ApplicationDbContext>()
            ));**/
        }
    }
}