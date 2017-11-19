using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OrangeHouse.Startup))]
namespace OrangeHouse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
