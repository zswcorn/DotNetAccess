using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetAccess.Startup))]
namespace DotNetAccess
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
