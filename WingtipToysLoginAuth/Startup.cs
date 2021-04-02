using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WingtipToysLoginAuth.Startup))]
namespace WingtipToysLoginAuth
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
