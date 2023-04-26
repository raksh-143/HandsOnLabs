using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookCatalogApplication.Startup))]
namespace BookCatalogApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
