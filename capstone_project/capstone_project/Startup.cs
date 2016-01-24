using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(capstone_project.Startup))]
namespace capstone_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
