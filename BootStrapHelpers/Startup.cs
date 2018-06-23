using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootStrapHelpers.Startup))]
namespace BootStrapHelpers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
