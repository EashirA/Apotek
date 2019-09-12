using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Apotek.Startup))]
namespace Apotek
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
