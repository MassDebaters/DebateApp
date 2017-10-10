using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.SignalR;
using System.Web.Routing;

[assembly: OwinStartup(typeof(CientWebsite.Startup))]

namespace CientWebsite
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfiguration = new HubConfiguration();
            hubConfiguration.EnableDetailedErrors = true;
            hubConfiguration.EnableJavaScriptProxies = true;

            app.MapSignalR("/signalr", hubConfiguration);

            //app.MapSignalR();
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
