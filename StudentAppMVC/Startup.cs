using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentAppMVC.Startup))]
namespace StudentAppMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
