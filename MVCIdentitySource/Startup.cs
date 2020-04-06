using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCIdentitySource.Startup))]
namespace MVCIdentitySource
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
