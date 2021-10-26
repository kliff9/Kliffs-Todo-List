using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KliffsTodo.Startup))]
namespace KliffsTodo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
