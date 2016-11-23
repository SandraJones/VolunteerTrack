using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VolunteerTrack.Startup))]
namespace VolunteerTrack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
