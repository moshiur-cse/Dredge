using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DredgingCodeFastApp.Startup))]
namespace DredgingCodeFastApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
