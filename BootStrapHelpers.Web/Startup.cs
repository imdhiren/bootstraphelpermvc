using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootStrapHelpers.Web.Startup))]
namespace BootStrapHelpers.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
