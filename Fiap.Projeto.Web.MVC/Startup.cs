using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fiap.Projeto.Web.MVC.Startup))]
namespace Fiap.Projeto.Web.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
