using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeeTest.Startup))]
namespace EmployeeTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
