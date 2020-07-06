using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCCApplication.Startup))]
namespace MCCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
