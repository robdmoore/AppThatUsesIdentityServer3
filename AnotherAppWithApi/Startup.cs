using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(AnotherAppWithApi.Startup))]

namespace AnotherAppWithApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
