using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SubmissionDojo.Startup))]
namespace SubmissionDojo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
