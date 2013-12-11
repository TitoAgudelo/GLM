using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IntranetGLM2013.Startup))]
namespace IntranetGLM2013
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
