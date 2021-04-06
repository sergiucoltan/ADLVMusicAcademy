using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADLVMusicAcademy.Startup))]
namespace ADLVMusicAcademy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
