using GVSU.Azure;
using GVSU.BusinessLogic;
using GVSU.Contracts;
using GVSU.Simulators;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Web.Startup))]
namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            InitializeFactories();
        }

        public void InitializeFactories()
        {
            Factory.Register<IVolunteerService>(() => new AzureVolunteerService(new VolunteerServiceSimulator()));
        }
    }
}