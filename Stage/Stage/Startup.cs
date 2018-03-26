using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Stage.Startup))]
namespace Stage
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
