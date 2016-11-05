using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PW_TP.Startup))]
namespace PW_TP
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
