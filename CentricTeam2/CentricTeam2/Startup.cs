using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CentricTeam2.Startup))]
namespace CentricTeam2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
