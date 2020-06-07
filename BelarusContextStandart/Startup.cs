using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BelarusContextStandart.Startup))]
namespace BelarusContextStandart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
