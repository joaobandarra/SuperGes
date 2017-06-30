using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperGes.Startup))]
namespace SuperGes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
