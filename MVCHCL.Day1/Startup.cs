using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCHCL.Day1.Startup))]
namespace MVCHCL.Day1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
