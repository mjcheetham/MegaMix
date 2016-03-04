using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CS_ASPNET45.Startup))]
namespace CS_ASPNET45
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
