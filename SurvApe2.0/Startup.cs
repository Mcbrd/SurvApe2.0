using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SurvApe2._0.Startup))]
namespace SurvApe2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
