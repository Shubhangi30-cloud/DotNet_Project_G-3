using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(E_trading.StartupOwin))]

namespace E_trading
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
