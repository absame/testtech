using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examen.UI.Startup))]
namespace Examen.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
