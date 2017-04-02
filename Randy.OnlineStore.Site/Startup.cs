using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Randy.OnlineStore.Site.Startup))]
namespace Randy.OnlineStore.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
