using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarritoDeCompras.Startup))]
namespace CarritoDeCompras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
