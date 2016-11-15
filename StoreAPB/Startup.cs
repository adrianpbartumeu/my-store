using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StoreAPB.Startup))]
namespace StoreAPB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
