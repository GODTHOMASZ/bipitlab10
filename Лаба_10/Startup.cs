using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Лаба_10.Startup))]
namespace Лаба_10
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
