using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TreeOfLifeDB.Startup))]
namespace TreeOfLifeDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
