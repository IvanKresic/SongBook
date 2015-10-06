using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MP3HRCloud.Startup))]
namespace MP3HRCloud
{
    public partial class Startup
    {

        
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
