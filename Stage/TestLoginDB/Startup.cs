using Microsoft.Owin;
using Owin;
using System;

[assembly: OwinStartupAttribute(typeof(TestLoginDB.Startup))]
namespace TestLoginDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
