using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcGarageGroup.Startup))]
namespace MvcGarageGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
