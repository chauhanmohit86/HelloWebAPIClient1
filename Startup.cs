using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelloWebAPIClient1.Startup))]
namespace HelloWebAPIClient1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
