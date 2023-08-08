using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cinemax.Startup))]
namespace Cinemax
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
