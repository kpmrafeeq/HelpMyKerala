using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RescueHandymans.Startup))]
namespace RescueHandymans
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            
        }

    }
}
