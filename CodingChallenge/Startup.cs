using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CodingChallenge.Startup))]
namespace CodingChallenge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
